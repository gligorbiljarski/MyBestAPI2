﻿using System.Text.Json.Serialization;

namespace MyBestAPI2.Models
{
    public class Worker
    {
        public int Id { get; set; }

        [JsonPropertyName("employee_name")]
        public string EmployeeName { get; set; }

        [JsonPropertyName("employee_salary")]
        public decimal EmployeeSalary { get; set; }

        [JsonPropertyName("employee_age")]
        public int EmployeeAge { get; set; }

        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; set; }
    }
}
