using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;

namespace CodeSamurai.API.Services
{
    public interface IStationService
    {
        Task<Station> AddStationAsync(Station station);
        Task<Station> UpdateStationAsync(int id, Station updatedStation);
        Task<IEnumerable<Station>> GetAllStationsAsync();
        Task<Station> GetStationByIdAsync(int id);
        Task<IEnumerable<Station>> SearchStationsAsync(QueryParameters queryParams);
    }
}
