using AutoMapper;
using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;

namespace CodeSamurai.API.Services
{
    public class TrainService : ITrainService
    {
        private readonly IGenericRepository<Train> _repository;

        public TrainService(IGenericRepository<Train> repository, IMapper mapper)
        {
            _repository = repository;
        }

        public Task<Train> AddTrainAsync(Train train)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Train>> GetAllTrainsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Train> GetTrainByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Train>> SearchTrainsAsync(QueryParameters queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<Train> UpdateTrainAsync(int id, Train updatedTrain)
        {
            throw new NotImplementedException();
        }
    }
}
