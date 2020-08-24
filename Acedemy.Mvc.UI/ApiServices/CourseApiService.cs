using Academy.EntityFramework.Concrete;
using Acedemy.API.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Acedemy.Mvc.UI.ApiService
{
    public class CourseApiService
    {
        private HttpClient _httpClient { get; set; }
        public CourseApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<CourseDto>> GetAllAsync(string path,string accessToken)
        {

            List<CourseDto> courseModels = null;
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                courseModels =  JsonConvert.DeserializeObject<List<CourseDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                courseModels = null;
            }
            return  courseModels;
        }

        public async Task<CourseDto> GetById(string path, string accessToken)
        {

            CourseDto courseModel = null;
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                courseModel = JsonConvert.DeserializeObject<CourseDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                courseModel = null;
            }
            return courseModel;
        }

        public async Task Add(CourseDto courseModel, string path,string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
                path, courseModel);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<CourseDto>> GetAllWithStudentAsync(string path, string accessToken)
        {

            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            List<CourseDto> courseModels = null;
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                courseModels = JsonConvert.DeserializeObject<List<CourseDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                courseModels = null;
            }
            return courseModels;

        }

        public async Task<CourseDto> UpdateCourseAsync(CourseDto courseModel, string path, string accessToken)
        {
            //_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(
                path, courseModel);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            courseModel = await response.Content.ReadAsAsync<CourseDto>();
            return courseModel;
        }


        public async Task<HttpStatusCode> DeleteCourseAsync(string path, string accessToken)
        {
            //_httpClient.DeleteAsync(new HttpRequestMessage()
            //{
            //    RequestUri = new Uri(path),
            //    Method = HttpMethod.Post,
            //    Content = new StringContent("Deelete"),
            //    Headers = new HttpRequestHeaders() { new AuthenticationHeaderValue("Bearer", accessToken) }
            //});

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _httpClient.DeleteAsync(path);
            return response.StatusCode;
        }
    }
}