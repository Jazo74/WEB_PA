using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public interface IDataService
    {
        // users

        string GetUserId(string email);

        void AccepAnswer(string answerId);

        string GetUserFromQuestion(string questionId);

        string GetUserFromAnswer(string answerId);

    }
}
