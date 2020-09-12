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

namespace Acedemy.Mvc.UI.ApiService
{
    public class StudentApiService
    {
        private HttpClient _httpClient { get; set; }
        public StudentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<StudentDto>> GetAllAsync(string path, string accessToken)
        {

            List<StudentDto> studentModels = null;
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                studentModels = JsonConvert.DeserializeObject<List<StudentDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                studentModels = null;
            }
            return studentModels;
        }

        public async Task<List<StudentDto>> FindByName(string path, string accessToken, string key)
        {
            List<StudentDto> studentDtos = null;
            var stringcontent = new StringContent(JsonConvert.SerializeObject(key), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            HttpResponseMessage response = await _httpClient.PostAsync(path, stringcontent);
            if (response.IsSuccessStatusCode)
            {
                studentDtos = JsonConvert.DeserializeObject<List<StudentDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                studentDtos = null;
            }
            return studentDtos;
        }

        public async Task<Boolean> AddStudent(StudentDto studentDto, string path, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            var stringcontent = new StringContent(JsonConvert.SerializeObject(studentDto), Encoding.UTF8, "application/json");
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
        public async Task<HttpStatusCode> DeleteStudent(string path, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _httpClient.DeleteAsync(path);
            return response.StatusCode;
        }

        public async Task<StudentDto> Get(string path, string accessToken)
        {
            StudentDto ınstructorDto = new StudentDto();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                ınstructorDto = JsonConvert.DeserializeObject<StudentDto>(await response.Content.ReadAsStringAsync());
                return ınstructorDto;
            }
            else
            {
                ınstructorDto = null;
            }
            return ınstructorDto;
        }
        public async Task<Boolean> UpdateStudent(StudentDto studentDto, string path, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(
                path, studentDto);
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

    }
}