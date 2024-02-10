using System;

namespace Task1.Models
{
    public class CallsLogDetails
    {
        public int CallsLogDetailsId { get; set; }
        public int CallsLogSummaryId { get; set; }
        public string PhoneNumber  { get; set; }
        public string AgentID  { get; set; }
        public string Extension { get; set; }
        public DateTime CallDateTime { get; set; }
        public double CallDuration { get; set; }
        public string Type { get; set; }
        public bool Answered { get; set; }
        public CallsLogSummary CallsLogSummary { get; set; }
    }
}
