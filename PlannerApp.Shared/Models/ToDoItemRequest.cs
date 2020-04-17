using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlannerApp.Shared.Models
{
    public class ToDoItemRequest
    {
        public string Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public string PlanId { get; set; }
    }
}
