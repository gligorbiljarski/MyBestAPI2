using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MyBestAPI2.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyBestAPI2.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly HttpClient _httpClient;

        public WorkerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Worker>> GetWorkersAsync(decimal? maxSalary = null)
        {
            var response = await _httpClient.GetAsync("http://dummy.restapiexample.com/api/v1/employees");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var workerApiResponse = JsonSerializer.Deserialize<WorkerApiResponse>(responseBody, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            if (workerApiResponse.Status == "success")
            {
                var workers = workerApiResponse.Data;

                if (maxSalary.HasValue)
                {
                    workers = workers.Where(worker => worker.EmployeeSalary <= maxSalary.Value).ToList();
                }

                return workers.OrderByDescending(worker => worker.EmployeeSalary).ToList();
            }

            throw new Exception("Failed to fetch workers from external API");
        }
    }
}
