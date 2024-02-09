using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;

namespace CodeSamurai.API.Services
{
    public interface ITrainService
    {
        Task<Train> AddTrainAsync(Train train);
        Task<Train> UpdateTrainAsync(int id, Train updatedTrain);
        Task<IEnumerable<Train>> GetAllTrainsAsync();
        Task<Train> GetTrainByIdAsync(int id);
        Task<IEnumerable<Train>> SearchTrainsAsync(QueryParameters queryParams);
    }
}
