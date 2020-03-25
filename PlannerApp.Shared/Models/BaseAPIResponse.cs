using System;
using System.Collections.Generic;
using System.Text;

namespace PlannerApp.Shared.Models
{
    public abstract class BaseAPIResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
