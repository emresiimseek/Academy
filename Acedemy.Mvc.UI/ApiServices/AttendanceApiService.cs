using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Concrete.ComplexTypes;
using Academy.EntityFramework.Concrete.DTOs;
using Acedemy.API.Models.Dto;
using Acedemy.Business;
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
    public class AttendanceApiService
    {
        private HttpClient _httpClient { get; set; }
        public AttendanceApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BusinessLayerResult<AttendanceModelDto>> Add(AttendanceModelDto attendanceModelDto, string path)
        {

            BusinessLayerResult<AttendanceModelDto> result = new BusinessLayerResult<AttendanceModelDto>();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
                path, attendanceModelDto);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<BusinessLayerResult<AttendanceModelDto>>(await response.Content.ReadAsStringAsync());
            }
            return result;
        }

        public async Task<List<AttendanceReport>> GetAttendanceReport(ReportDto reportDto, string path)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(reportDto), Encoding.UTF8, "application/json");
            List<AttendanceReport> attendanceReports = new List<AttendanceReport>();
            HttpResponseMessage response = await _httpClient.PostAsync(
                 path, stringContent);
            if (response.IsSuccessStatusCode)
            {
                attendanceReports = JsonConvert.DeserializeObject<List<AttendanceReport>>(await response.Content.ReadAsStringAsync());
            }
            return attendanceReports;
        }

        public async Task<HttpStatusCode> Delete(string path)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(path);
            return response.StatusCode;
        }

    



    }
}