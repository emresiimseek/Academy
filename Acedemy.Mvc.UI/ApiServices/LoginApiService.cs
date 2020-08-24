using Academy.EntityFramework.Concrete;
using Acedemy.Mvc.UI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Acedemy.Mvc.UI.ApiServices
{
    public class LoginApiService
    {
        private HttpClient _httpClient { get; set; }
        public LoginApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public  async Task<TokenContent> Authenticate(string path, LoginUserModel loginUserModel)
        {

            var client = new RestClient("http://academy.emresimsek.info/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
             request.AddParameter("application/x-www-form-urlencoded", $"grant_type=password&username={loginUserModel.Username}&password={loginUserModel.Password}", ParameterType.RequestBody);
            IRestResponse response =  client.Execute(request);
            TokenContent tokenContent = JsonConvert.DeserializeObject<TokenContent>(response.Content);
            return tokenContent;

        }
    }
}