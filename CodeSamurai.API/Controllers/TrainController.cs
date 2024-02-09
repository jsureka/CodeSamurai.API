using CodeSamurai.API.Core.Framework;
using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;
using CodeSamurai.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CodeSamurai.API.Controllers
{
    [Route("api/trains")]
    public class TrainController : BaseApiController
    {
        private readonly ITrainService _trainService;

        public TrainController(ITrainService trainService)
        {
            _trainService = trainService ?? throw new ArgumentNullException(nameof(trainService));
        }

        [HttpPost]
        public async Task<IActionResult> AddTrain(Train train)
        {
            try
            {
                var addedTrain = await _trainService.AddTrainAsync(train);
                return Created(nameof(addedTrain));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrain(int id, Train updatedTrain)
        {
            try
            {
                var Train = await _trainService.UpdateTrainAsync(id, updatedTrain);
                return Ok(Train);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrains()
        {
            try
            {
                var trains = await _trainService.GetAllTrainsAsync();
                return Ok(trains);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainById(int id)
        {
            try
            {
                var train = await _trainService.GetTrainByIdAsync(id);
                if (train == null)
                {
                    return NotFound();
                }
                return Ok(train);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchTrainsAsync([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var Trains = await _trainService.SearchTrainsAsync(queryParameters);
                if (Trains == null)
                {
                    return NotFound();
                }
                var responseModel = new ResponseListModel<Train>
                {
                    Data = Trains.ToList(),
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
