
using Core.Entities;
using Core.Interfaces;
using Core.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TrainingMovementRepository(DataContext context) : ITrainingMovementRepository
    {
        public void CreateTrainingMovement(TrainingMovement trainingMovement)
        {
            context.Add(trainingMovement);
            context.SaveChanges();
        }

        public void DeleteTrainingMovement(TrainingMovement trainingMovement)
        {
            context.Remove(trainingMovement);
            context.SaveChanges();
        }

        public async Task<IReadOnlyList<TrainingMovement>> GetAllMovementInfo(string Movement, TrainingMovementParameters trainingMovementParameters)
        {
            var trainings = await context.TrainingMovements.Skip((trainingMovementParameters.PageNumber - 1) * trainingMovementParameters.PageSize).Take(trainingMovementParameters.PageSize)
        .Where(t => t.MovementName == Movement).ToListAsync();
            return trainings;
        }

        public async Task<TrainingMovement> GetAllTrainingMovementByDate(string TrainingType, string Movement, string Date)
        {
            var training = await context.TrainingMovements.Where(t => t.TrainingType == TrainingType && t.Date == Date && t.MovementName == Movement).FirstOrDefaultAsync();
            return training;
        }

        public async Task<IReadOnlyList<TrainingMovement>> GetAllTrainingSets(TrainingMovementParameters trainingMovementParameters)
        {
            var trainings = context.TrainingMovements.Skip((trainingMovementParameters.PageNumber - 1) * trainingMovementParameters.PageSize).Take(trainingMovementParameters.PageSize).ToList();
            return trainings;
        }

        public async Task UpdateTrainingMovement(TrainingMovement trainingMovement)
        {
            context.TrainingMovements.Update(trainingMovement);
            await context.SaveChangesAsync(); // Use async save
        }

    }
}
