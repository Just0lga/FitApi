using Core.Entities;
using Core.Interfaces;
using Core.RequestFeatures;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GurayAydin.Controllers
{
    [Route("api/Trainings/Movements")]
    [ApiController]
    public class TrainingMovementController(ITrainingMovementRepository trainingMovementRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateTrainingMovement(TrainingMovementDto trainingMovementDto)
        {
            // Map DTO to the entity model
            var trainingMovement = new TrainingMovement
            {
                TrainingId = trainingMovementDto.TrainingId,
                TrainingType = trainingMovementDto.TrainingType,
                MovementName = trainingMovementDto.MovementName,
                Date = trainingMovementDto.Date,

                // Set1 to Set3 are required, so we always assign them
                Set1_kg = trainingMovementDto.Set1_kg,
                Set1_reps = trainingMovementDto.Set1_reps,
                Set2_kg = trainingMovementDto.Set2_kg,
                Set2_reps = trainingMovementDto.Set2_reps,
                Set3_kg = trainingMovementDto.Set3_kg,
                Set3_reps = trainingMovementDto.Set3_reps
            };

            // Only assign Set4 to Set6 if they are included in the request
            if (trainingMovementDto.Set4_kg.HasValue && trainingMovementDto.Set4_reps.HasValue)
            {
                trainingMovement.Set4_kg = trainingMovementDto.Set4_kg;
                trainingMovement.Set4_reps = trainingMovementDto.Set4_reps;
                if (trainingMovementDto.Set5_kg.HasValue && trainingMovementDto.Set5_reps.HasValue)
                {
                    trainingMovement.Set5_kg = trainingMovementDto.Set5_kg;
                    trainingMovement.Set5_reps = trainingMovementDto.Set5_reps;
                    if (trainingMovementDto.Set6_kg.HasValue && trainingMovementDto.Set6_reps.HasValue)
                    {
                        trainingMovement.Set6_kg = trainingMovementDto.Set6_kg;
                        trainingMovement.Set6_reps = trainingMovementDto.Set6_reps;
                    }
                }
            
            }
            // Save to database
            trainingMovementRepository.CreateTrainingMovement(trainingMovement);

            return Ok(trainingMovement);
        }

        //Get all training movements
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Training>>> GetAllTrainingMovements([FromQuery]TrainingMovementParameters trainingMovementParameters)
        {
            var movements = await trainingMovementRepository.GetAllTrainingSets(trainingMovementParameters);
            return Ok(movements);
        }

        //Get all training movement info
        [HttpGet("{movement}")]
        public async Task<ActionResult<IReadOnlyList<Training>>> GetAllTrainingMovementsByMovementType(string movement, [FromQuery]TrainingMovementParameters trainingMovementParameters)
        {
            var movements = await trainingMovementRepository.GetAllMovementInfo(movement,trainingMovementParameters);
            return Ok(movements);
        }

        //Get movement of training by infos
        [HttpGet("{TrainingType}/{Movement}/{Date}")]
        public async Task<TrainingMovement> GetOneMovementByDate(string TrainingType, string Movement, string Date)

        {
            var movement = await trainingMovementRepository.GetAllTrainingMovementByDate(TrainingType, Movement, Date);

            return movement;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTrainingMovement(TrainingMovementDto trainingMovementDto)
        {
            // Retrieve existing movement from the database
            var training = await trainingMovementRepository.GetAllTrainingMovementByDate(trainingMovementDto.TrainingType, trainingMovementDto.MovementName, trainingMovementDto.Date);

            // If no movement is found, return a NotFound result
            if (training == null)
                return NotFound("Training movement not found.");

            // Update all properties
            training.TrainingId = trainingMovementDto.TrainingId;
            training.TrainingType = trainingMovementDto.TrainingType;
            training.MovementName = trainingMovementDto.MovementName;
            training.Date = trainingMovementDto.Date;

            // Set1 to Set3 are required, so we always assign them
            training.Set1_kg = trainingMovementDto.Set1_kg;
            training.Set1_reps = trainingMovementDto.Set1_reps;
            training.Set2_kg = trainingMovementDto.Set2_kg;
            training.Set2_reps = trainingMovementDto.Set2_reps;
            training.Set3_kg = trainingMovementDto.Set3_kg;
            training.Set3_reps = trainingMovementDto.Set3_reps;

            if (trainingMovementDto.Set4_kg.HasValue && trainingMovementDto.Set4_reps.HasValue && training.Set4_kg.HasValue && training.Set4_reps.HasValue)
            {
                training.Set4_kg = trainingMovementDto.Set4_kg;
                training.Set4_reps = trainingMovementDto.Set4_reps;
                if (trainingMovementDto.Set5_kg.HasValue && trainingMovementDto.Set5_reps.HasValue && training.Set5_kg.HasValue && training.Set5_reps.HasValue)
                {
                    training.Set5_kg = trainingMovementDto.Set5_kg;
                    training.Set5_reps = trainingMovementDto.Set5_reps;
                    if (trainingMovementDto.Set6_kg.HasValue && trainingMovementDto.Set6_reps.HasValue && training.Set6_kg.HasValue && training.Set6_reps.HasValue)
                    {
                        training.Set6_kg = trainingMovementDto.Set6_kg;
                        training.Set6_reps = trainingMovementDto.Set6_reps;
                    }
                }

            }

            // Save changes
            await trainingMovementRepository.UpdateTrainingMovement(training);

            return Ok(training);
        }



    }
}