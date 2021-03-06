﻿using Academy.EntityFramework.Concrete;
using Academy.EntityFramework.Concrete.ComplexTypes;
using Academy.EntityFramework.Concrete.DTOs;
using Academy.EntityFramework.Messages;
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

        public async Task<List<MessagesObj>> Add(AttendanceDto attendanceDto, string path, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            List<MessagesObj> messagesObjs = new List<MessagesObj>();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
                path, attendanceDto);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                messagesObjs = JsonConvert.DeserializeObject <List<MessagesObj>> (await response.Content.ReadAsStringAsync());
            }
            return messagesObjs;
        }

       

        public async Task<List<AttendanceReport>> GetAttendanceReport(ReportDto reportDto, string path, string accessToken)
        {
           
            var stringContent = new StringContent(JsonConvert.SerializeObject(reportDto), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            List<AttendanceReport> attendanceReports = new List<AttendanceReport>();
            HttpResponseMessage response = await _httpClient.PostAsync(
                 path, stringContent);
            if (response.IsSuccessStatusCode)
            {
                attendanceReports = JsonConvert.DeserializeObject<List<AttendanceReport>>(await response.Content.ReadAsStringAsync());
            }
            return attendanceReports;
        }

        public async Task<HttpStatusCode> Delete(string path, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _httpClient.DeleteAsync(path);
            return response.StatusCode;
        }





    }
}