using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Http;

namespace Task1.ViewsModel
{
    public class CallsLogSummaryModel
    {
        public int CallsLogSummaryId { get; set; }
        public DateTime Upload { get; set; }
        public string Path { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public IFormFile File { get; set; }

    }
}
