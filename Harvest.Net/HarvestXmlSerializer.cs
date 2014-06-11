using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using RestSharp.Extensions;
using System.Collections;
using System.Globalization;

namespace Harvest.Net
{
    public class HarvestXmlSerializer : ISerializer
    {
        private ISerializer _defaultSerializer;
        public HarvestXmlSerializer()
        {
            _defaultSerializer = new XmlSerializer();
        }

        #region Wrapper

        public string ContentType
        {
            get
            {
                return _defaultSerializer.ContentType;
            }
            set
            {
                _defaultSerializer.ContentType = value;
            }
        }

        public string DateFormat
        {
            get
            {
                return _defaultSerializer.DateFormat;
            }
            set
            {
                _defaultSerializer.DateFormat = value;
            }
        }

        public string Namespace
        {
            get
            {
                return _defaultSerializer.Namespace;
            }
            set
            {
                _defaultSerializer.Namespace = value;
            }
        }

        public string RootElement
        {
            get
            {
                return _defaultSerializer.RootElement;
            }
            set
            {
                _defaultSerializer.RootElement = value;
            }
        }

        #endregion

        // The following code was copied from the RestSharp source
        // I've modified the name serialization to match Harvest's naming
        public string Serialize(object obj)
        {
            var doc = new XDocument();

            var t = obj.GetType();
            var name = t.Name.ToLower();

            //var options = t.GetAttribute<SerializeAsAttribute>();
            //if (options != null)
            //{
            //    name = options.TransformName(options.Name ?? name);
            //}

            var root = new XElement(name.AsNamespaced(Namespace));

            if (obj is IList)
            {
                var itemTypeName = "";
                foreach (var item in (IList)obj)
                {
                    var type = item.GetType();
                    var opts = type.GetAttribute<SerializeAsAttribute>();
                    if (opts != null)
                    {
                        itemTypeName = opts.TransformName(opts.Name ?? name);
                    }
                    if (itemTypeName == "")
                    {
                        itemTypeName = type.Name;
                    }
                    var instance = new XElement(itemTypeName.AsNamespaced(Namespace));
                    Map(instance, item);
                    root.Add(instance);
                }
            }
            else
                Map(root, obj);

            if (RootElement.HasValue())
            {
                var wrapper = new XElement(RootElement.AsNamespaced(Namespace), root);
                doc.Add(wrapper);
            }
            else
            {
                doc.Add(root);
            }

            return doc.ToString();
        }

        private void Map(XElement root, object obj)
        {
            var objType = obj.GetType();

            var props = from p in objType.GetProperties()
                        let indexAttribute = p.GetAttribute<SerializeAsAttribute>()
                        where p.CanRead && p.CanWrite
                        orderby indexAttribute == null ? int.MaxValue : indexAttribute.Index
                        select p;

            var globalOptions = objType.GetAttribute<SerializeAsAttribute>();

            foreach (var prop in props)
            {
                var name = prop.Name.AddDashes().ToLower(); // added this to convert names to dashed-lowercase
                var rawValue = prop.GetValue(obj, null);

                if (rawValue == null)
                {
                    continue;
                }

                var value = GetSerializedValue(rawValue);
                var propType = prop.PropertyType;

                var useAttribute = false;
                var settings = prop.GetAttribute<SerializeAsAttribute>();
                if (settings != null)
                {
                    //name = settings.Name.HasValue() ? settings.Name : name;
                    useAttribute = settings.Attribute;
                }

                //var options = prop.GetAttribute<SerializeAsAttribute>();
                //if (options != null)
                //{
                //    name = options.TransformName(name);
                //}
                //else if (globalOptions != null)
                //{
                //    name = globalOptions.TransformName(name);
                //}

                var nsName = name.AsNamespaced(Namespace);
                var element = new XElement(nsName);

                if (propType.IsPrimitive || propType.IsValueType || propType == typeof(string))
                {
                    if (useAttribute)
                    {
                        root.Add(new XAttribute(name, value));
                        continue;
                    }

                    element.Value = value;
                }
                else if (rawValue is IList)
                {
                    var itemTypeName = "";
                    foreach (var item in (IList)rawValue)
                    {
                        if (itemTypeName == "")
                        {
                            var type = item.GetType();
                            var setting = type.GetAttribute<SerializeAsAttribute>();
                            itemTypeName = setting != null && setting.Name.HasValue()
                                ? setting.Name
                                : type.Name;
                        }
                        var instance = new XElement(itemTypeName.AsNamespaced(Namespace));
                        Map(instance, item);
                        element.Add(instance);
                    }
                }
                else
                {
                    Map(element, rawValue);
                }

                root.Add(element);
            }
        }

        private string GetSerializedValue(object obj)
        {
            var output = obj;

            if (obj is DateTime && DateFormat.HasValue())
            {
                output = ((DateTime)obj).ToString(DateFormat, CultureInfo.InvariantCulture);
            }
            if (obj is bool)
            {
                output = ((bool)obj).ToString(CultureInfo.InvariantCulture).ToLower();
            }
            if (IsNumeric(obj))
            {
                return SerializeNumber(obj);
            }

            return output.ToString();
        }

        static string SerializeNumber(object number)
        {
            if (number is long)
                return ((long)number).ToString(CultureInfo.InvariantCulture);
            else if (number is ulong)
                return ((ulong)number).ToString(CultureInfo.InvariantCulture);
            else if (number is int)
                return ((int)number).ToString(CultureInfo.InvariantCulture);
            else if (number is uint)
                return ((uint)number).ToString(CultureInfo.InvariantCulture);
            else if (number is decimal)
                return ((decimal)number).ToString(CultureInfo.InvariantCulture);
            else if (number is float)
                return ((float)number).ToString(CultureInfo.InvariantCulture);
            else
                return (Convert.ToDouble(number, CultureInfo.InvariantCulture).ToString("r", CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Determines if a given object is numeric in any way
        /// (can be integer, double, null, etc).
        /// </summary>
        static bool IsNumeric(object value)
        {
            if (value is sbyte) return true;
            if (value is byte) return true;
            if (value is short) return true;
            if (value is ushort) return true;
            if (value is int) return true;
            if (value is uint) return true;
            if (value is long) return true;
            if (value is ulong) return true;
            if (value is float) return true;
            if (value is double) return true;
            if (value is decimal) return true;
            return false;
        }
    }
}
