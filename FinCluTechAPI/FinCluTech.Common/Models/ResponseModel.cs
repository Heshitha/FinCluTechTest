using System;
using System.Collections.Generic;
using System.Text;

namespace FinCluTech.Common.Models
{
    public class ResponseModel
    {
        public int RecordCount { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}
