using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Helpers;

namespace WebAPI.Interfaces
{
    public interface IApiUrl
    {
        string GetUrl(string api, List<Parameters> param, bool key = true);
    }
}
