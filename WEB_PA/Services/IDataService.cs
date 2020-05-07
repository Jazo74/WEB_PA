using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public interface IDataService
    {
        // users

        string GetNickname(string email);

    }
}
