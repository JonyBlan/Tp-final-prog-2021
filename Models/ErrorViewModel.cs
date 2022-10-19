using System;
using TP11.Models;
using System.Data.SqlClient;

namespace TP11.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
