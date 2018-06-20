﻿using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Extensions;
using RestSharp.Serializers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SimpleJson;

namespace Harvest.Net.Serialization
{
    public class HarvestJsonDeserializer : IDeserializer
    {
        public string RootElement { get; set; }

        public string Namespace { get; set; }

        public string DateFormat { get; set; }

        public CultureInfo Culture { get; set; }

        public HarvestJsonDeserializer()
        {
            Culture = CultureInfo.InvariantCulture;
        }

        public T Deserialize<T>(IRestResponse response)
        {
            var target = Activator.CreateInstance<T>();

            if (string.IsNullOrWhiteSpace(response.Content))
                return target;

            if (target is IList)
            {
                var objType = target.GetType();

                if (RootElement.HasValue())
                {
                    var root = FindRoot(response.Content);
                    target = (T)BuildList(objType, root);
                }
                else
                {
                    var data = SimpleJson.SimpleJson.DeserializeObject(response.Content);
                    target = (T)BuildList(objType, data);
                }
            }
            else if (target is IDictionary)
            {
                var root = FindRoot(response.Content);
                target = (T)BuildDictionary(target.GetType(), root);
            }
            else
            {
                var root = FindRoot(response.Content);
                Map(target, (IDictionary<string, object>)root);
            }

            return target;
        }

        private object FindRoot(string content)
        {
            var data = (IDictionary<string, object>)SimpleJson.SimpleJson.DeserializeObject(content);
            if (RootElement.HasValue() && data.ContainsKey(RootElement))
            {
                return data[RootElement];
            }

            return data;
        }

        private void Map(object target, IDictionary<string, object> data)
        {
            var objType = target.GetType();
            var props = objType.GetProperties().Where(p => p.CanWrite).ToList();

            foreach (var prop in props)
            {
                var type = prop.PropertyType;

                string name = string.Empty;

                var attributes = prop.GetCustomAttributes(typeof(DeserializeAsAttribute), false);
                if (attributes.Length > 0)
                {
                    var attribute = (DeserializeAsAttribute)attributes[0];
                    name = attribute.Name;
                }
                else
                {
                    name = prop.Name;
                }

                var parts = name.Split('.');
                var currentData = data;
                object value = null;
                for (var i = 0; i < parts.Length; ++i)
                {
                    var actualName = parts[i].GetNameVariants(Culture).FirstOrDefault(currentData.ContainsKey);
                    if (actualName == null)
                        break;
                    if (i == parts.Length - 1)
                        value = currentData[actualName];
                    else
                        currentData = (IDictionary<string, object>)currentData[actualName];
                }

                if (value != null)
                    prop.SetValue(target, ConvertValue(type, value), null);
            }
        }

        private IDictionary BuildDictionary(Type type, object parent)
        {
            var dict = (IDictionary)Activator.CreateInstance(type);
            var valueType = type.GetGenericArguments()[1];
            foreach (var child in (IDictionary<string, object>)parent)
            {
                var key = child.Key;
                object item = null;
                if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    item = BuildList(valueType, child.Value);
                }
                else
                {
                    item = ConvertValue(valueType, child.Value);
                }

                dict.Add(key, item);
            }

            return dict;
        }

        private IList BuildList(Type type, object parent)
        {
            var list = (IList)Activator.CreateInstance(type);
            var listType = type.GetInterfaces().First(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IList<>));
            var itemType = listType.GetGenericArguments()[0];

            if (parent is IList)
            {
                foreach (var element in (IList)parent)
                {
                    if (itemType.IsPrimitive)
                    {
                        var value = element.ToString();
                        list.Add(value.ChangeType(itemType, Culture));
                    }
                    else if (itemType == typeof(string))
                    {
                        if (element == null)
                        {
                            list.Add(null);
                            continue;
                        }

                        list.Add(element.ToString());
                    }
                    else
                    {
                        if (element == null)
                        {
                            list.Add(null);
                            continue;
                        }

                        var item = ConvertValue(itemType, element);
                        list.Add(item);
                    }
                }
            }
            else
            {
                list.Add(ConvertValue(itemType, parent));
            }

            return list;
        }

        private object ConvertValue(Type type, object value)
        {
            var stringValue = Convert.ToString(value, Culture);

            // check for nullable and extract underlying type
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // Since the type is nullable and no value is provided return null
                if (string.IsNullOrEmpty(stringValue))
                    return null;

                type = type.GetGenericArguments()[0];
            }

            if (type == typeof(object) && value != null)
            {
                type = value.GetType();
            }

            if (type.IsPrimitive)
            {
                return value.ChangeType(type, Culture);
            }
            else if (type.IsEnum)
            {
                // first try to get the value using the SerializeAsAttribute
                var match = Enum.GetValues(type)
                    .Cast<Enum>()
                    .FirstOrDefault(v =>
                    {
                        var attr = type.GetMember(v.ToString())[0].GetAttribute<DescriptionAttribute>();
                        if (attr != null && attr.Description == stringValue)
                            return true;
                        return false;
                    });

                if (match != null)
                    return match;
                else
                    return type.FindEnumValue(stringValue, Culture);
            }
            else if (type == typeof(Uri))
            {
                return new Uri(stringValue, UriKind.RelativeOrAbsolute);
            }
            else if (type == typeof(string))
            {
                return stringValue;
            }

#if !PocketPC
            else if (type == typeof(DateTime) || type == typeof(DateTimeOffset))
#else
            else if (type == typeof(DateTime))
#endif
            {
                DateTime dt;
                if (DateFormat.HasValue())
                {
                    dt = DateTime.ParseExact(stringValue, DateFormat, Culture);
                }
                else
                {
                    // try parsing instead
                    dt = stringValue.ParseJsonDate(Culture);
                }

#if PocketPC
            return dt;
#else
                if (type == typeof(DateTime))
                {
                    return dt;
                }
                else if (type == typeof(DateTimeOffset))
                {
                    return (DateTimeOffset)dt;
                }
#endif
            }
            else if (type == typeof(decimal))
            {
                if (value is double)
                    return (decimal)((double)value);

                return decimal.Parse(stringValue, Culture);
            }
            else if (type == typeof(Guid))
            {
                return string.IsNullOrEmpty(stringValue) ? Guid.Empty : new Guid(stringValue);
            }
            else if (type == typeof(TimeSpan))
            {
                return TimeSpan.Parse(stringValue);
            }
            else if (type.IsGenericType)
            {
                var genericTypeDef = type.GetGenericTypeDefinition();
                if (genericTypeDef == typeof(List<>))
                {
                    return BuildList(type, value);
                }
                else if (genericTypeDef == typeof(Dictionary<,>))
                {
                    var keyType = type.GetGenericArguments()[0];

                    // only supports Dict<string, T>()
                    if (keyType == typeof(string))
                    {
                        return BuildDictionary(type, value);
                    }
                }
                else
                {
                    // nested property classes
                    return CreateAndMap(type, value);
                }
            }
            else if (type.IsSubclassOfRawGeneric(typeof(List<>)))
            {
                // handles classes that derive from List<T>
                return BuildList(type, value);
            }
            else if (type == typeof(JsonObject))
            {
                // simplify JsonObject into a Dictionary<string, object>
                return BuildDictionary(typeof(Dictionary<string, object>), value);
            }
            else
            {
                // nested property classes
                return CreateAndMap(type, value);
            }

            return null;
        }

        private object CreateAndMap(Type type, object element)
        {
            var instance = Activator.CreateInstance(type);

            var data = (IDictionary<string, object>)element;
            var options = type.GetAttribute<SerializeAsAttribute>();
            if (options != null)
            {
                var name = options.Name ?? type.Name.GetNameVariants(Culture).FirstOrDefault(x => data.ContainsKey(x));

                if (name != null)
                    data = (IDictionary<string, object>)data[name];
            }

            Map(instance, data);

            return instance;
        }
    }
}
