using System;
using System.Threading.Tasks;
using HaveYourSay.Model;

namespace HaveYourSay.Service
{
    public class RestManager
    {
        IRestService restService;

        public RestManager (IRestService service)
        {
            restService = service;
        }

        public Task<string> SaveEntryAsync(Entry item)
        {
            return restService.SaveEntryAsync(item);
        }

    }
}
