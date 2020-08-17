using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.EntityFramework.Errors
{
    public class ErrorModel
    {
        public ErrorModel()
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }
    }
}