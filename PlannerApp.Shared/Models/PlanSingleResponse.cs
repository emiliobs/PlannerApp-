using System;
using System.Collections.Generic;
using System.Text;

namespace PlannerApp.Shared.Models
{
    public class PlanSingleResponse : BaseAPIResponse
    {
        public Plan Record { get; set; }
    }
}
