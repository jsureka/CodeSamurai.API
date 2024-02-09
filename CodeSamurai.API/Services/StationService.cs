using AutoMapper;
using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;

namespace CodeSamurai.API.Services
{
    public class StationService : IStationService
    {
        private readonly IGenericRepository<Station> _repository;

        public StationService(IGenericRepository<Station> repository, IMapper mapper)
        {
            _repository = repository;
        }

        public Task<Station> AddStationAsync(Station station)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Station>> GetAllStationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Station> GetStationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Station>> SearchStationsAsync(QueryParameters queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<Station> UpdateStationAsync(int id, Station updatedStation)
        {
            throw new NotImplementedException();
        }
    }
}
