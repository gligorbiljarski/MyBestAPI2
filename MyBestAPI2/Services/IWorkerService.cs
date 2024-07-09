using MyBestAPI2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBestAPI2.Services
{
    public interface IWorkerService
    {
        Task<IEnumerable<Worker>> GetWorkersAsync(decimal? maxSalary = null);
    }

}
