using Acedemy.API.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Acedemy.Mvc.UI.ApiServices
{
    public class InstructorApiService
    {
        private HttpClient _httpClient { get; set; }
        public InstructorApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<InstructorDto>> FindByName(string path, string accessToken, string key)
        {
            List<InstructorDto> ınstructorDtos = null;
            var stringcontent = new StringContent(JsonConvert.SerializeObject(key), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            HttpResponseMessage response = await _httpClient.PostAsync(path, stringcontent);
            if (response.IsSuccessStatusCode)
            {
                ınstructorDtos = JsonConvert.DeserializeObject<List<InstructorDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                ınstructorDtos = null;
            }
            return ınstructorDtos;
        }

        public async Task<List<InstructorDto>> GetAllInstructor(string path, string accessToken)
        {
            List<InstructorDto> instructors = new List<InstructorDto>();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                instructors = JsonConvert.DeserializeObject<List<InstructorDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                instructors = null;
            }
            return instructors;

        }

        public async Task<InstructorDto> Get(string path, string accessToken)
        {
            InstructorDto ınstructorDto = new InstructorDto();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                ınstructorDto = JsonConvert.DeserializeObject<InstructorDto>(await response.Content.ReadAsStringAsync());
                return ınstructorDto;
            }
            else
            {
                ınstructorDto = null;
            }
            return ınstructorDto;
        }

        public async Task<Boolean> AddInstructor(InstructorDto ınstructor, string path, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            var stringcontent = new StringContent(JsonConvert.SerializeObject(ınstructor), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(path, stringcontent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Boolean> UpdateInstructor(InstructorDto ınstructorDto, string path, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(
                path, ınstructorDto);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<HttpStatusCode> DeleteInstructor(string path, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _httpClient.DeleteAsync(path);
            return response.StatusCode;
        }
    }
}