using System;
using System.Threading.Tasks;
using HaveYourSay.Model;
using System.Collections.Generic;

namespace HaveYourSay.Service
{
    public interface IRestService
    {
            Task SaveEntryAsync(Entry item);
    }
}
