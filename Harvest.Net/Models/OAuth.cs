using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Serializers;
using Harvest.Net.Models.Interfaces;

namespace Harvest.Net.Models
{
    public class OAuth:IOAuth
    {
        [SerializeAs(Name = "access_token")]
        public string AccessToken { get; set; }
        [SerializeAs(Name = "refresh_token")]
        public string RefreshToken { get; set; }
        [SerializeAs(Name = "expires_in")]
        public int? ExpiresIn { get; set; }
        [SerializeAs(Name = "token_type")]
        public string TokenType { get; set; }
    }
}
