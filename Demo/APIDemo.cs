using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class APIDemo<T>
    {
        public ListOfUserDTO GetUsers(string endpoint)
        {
            var user = new APIHelper<ListOfUserDTO>();
            var url = user.setUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
            ListOfUserDTO content = user.GetContent<ListOfUserDTO>(response);
            return content;

        }

        public CreatUserDTO CreateUsers(string endpoint,dynamic payload)
        {
            var user = new APIHelper<CreatUserDTO>();
            var url = user.setUrl(endpoint);
            var request = user.CreatePostRequest(payload);
            var response = user.GetResponse(url, request);
            CreatUserDTO content = user.GetContent<CreatUserDTO>(response);
            return content;
        }
    }
}
