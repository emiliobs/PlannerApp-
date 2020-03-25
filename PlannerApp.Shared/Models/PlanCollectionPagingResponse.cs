using System;
using System.Collections.Generic;
using System.Text;

namespace PlannerApp.Shared.Models
{
    public class PlanCollectionPagingResponse : BaseAPIResponse
    {
        public Plan[] Records { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public int Page { get; set; }
        public int  PageSize { get; set; }
        public int? NextPage { get; set; }
    }
}
