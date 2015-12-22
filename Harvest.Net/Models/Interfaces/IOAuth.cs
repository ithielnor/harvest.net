using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models.Interfaces
{
    public interface IOAuth
    {
        string AccessToken { get; set; }

        string RefreshToken { get; set; }

        int? ExpiresIn { get; set; }

        string TokenType { get; set; }
    }
}
