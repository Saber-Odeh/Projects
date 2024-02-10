using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Models
{
    public class CallsLogSummary
    {

        public int CallsLogSummaryId { get; set; }
        public DateTime Upload { get; set; }
        
        public string Path { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
