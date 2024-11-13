using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hipertrofi.Controllers
{
    [Route("api/Trainings")]
    [ApiController]
    public class TrainingController(ITrainingRepository trainingRepository) : ControllerBase
    {  

        //Create training
        [HttpPost]
        public IActionResult AddTraining(TrainingDto trainingDto)
        {
            var training = new Training
            { 
                Date = trainingDto.Date,
                TrainingType = trainingDto.TrainingType,   
            };
            trainingRepository.CreateTraining(training);
            return Ok(training);
        }

        //Get all trainings list
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Training>>> GetAllTrainings([FromQuery]TrainingMovementParameters trainingParameters)
        {
            var trainings = await trainingRepository.GetAllTrainings(trainingParameters);
            return Ok(trainings);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTraining(TrainingDto trainingDto)
        {
            var newTraining = await trainingRepository.GetTrainingByDate(trainingDto.Date);

            if (newTraining == null)
                return NotFound($"Training with date not found.");

            newTraining.TrainingType = trainingDto.TrainingType;

            await trainingRepository.UpdateTraining(newTraining);

            return Ok(newTraining);
        }


        //Get training by date
        [HttpGet("{Date}")]
        public async Task<Training> GetTrainingByDate(string Date)
        {
            var training = await trainingRepository.GetTrainingByDate(Date);
            if (training == null) return null;
            return training;
        }



    }
}
