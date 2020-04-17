using System;
using System.Collections.Generic;
using System.Text;

namespace PlannerApp.Shared.Models
{
    public class ToDoItemSingleResponse  : BaseAPIResponse
    {
        public ToDoItem Record { get; set; }
    }
}
