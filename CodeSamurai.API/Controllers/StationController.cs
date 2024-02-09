using CodeSamurai.API.Core.Framework;
using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;
using CodeSamurai.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CodeSamurai.API.Controllers
{
    [Route("api/stations")]
    public class StationController : BaseApiController
    {
        private readonly IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService ?? throw new ArgumentNullException(nameof(stationService));
        }

        [HttpPost]
        public async Task<IActionResult> AddStation(Station Station)
        {
            try
            {
                var addedStation = await _stationService.AddStationAsync(Station);
                return Created(nameof(addedStation));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStation(int id, Station updatedStation)
        {
            try
            {
                var Station = await _stationService.UpdateStationAsync(id, updatedStation);
                return Ok(Station);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStations()
        {
            try
            {
                var stations = await _stationService.GetAllStationsAsync();
                return Ok(stations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStationById(int id)
        {
            try
            {
                var station = await _stationService.GetStationByIdAsync(id);
                if (station == null)
                {
                    return NotFound();
                }
                return Ok(station);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchStationsAsync([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var Stations = await _stationService.SearchStationsAsync(queryParameters);
                if (Stations == null)
                {
                    return NotFound();
                }
                var responseModel = new ResponseListModel<Station>
                {
                    Data = Stations.ToList(),
                };

                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
