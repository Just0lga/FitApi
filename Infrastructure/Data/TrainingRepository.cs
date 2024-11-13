using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.RequestFeatures;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Data
{
    public class TrainingRepository(DataContext context) : ITrainingRepository
    {
        public async Task<IReadOnlyList<Training>> GetAllTrainings(TrainingMovementParameters trainingParameters)
        {
            var trainings = context.Trainings.Skip((trainingParameters.PageNumber-1)*trainingParameters.PageSize).Take(trainingParameters.PageSize).ToList();
            return trainings;
        }

        public async Task<Training> GetTrainingByDate(string date)
        {
            var training = await context.Trainings.FirstOrDefaultAsync(x => x.Date == date);
            return training;
        }

        public async Task UpdateTraining(Training training)
        {
            context.Trainings.Update(training);
            context.SaveChanges();
        }
        public void CreateTraining(Training training)
        {
            context.Add(training);
            context.SaveChanges();
        }

        public void DeleteTraining(Training training)
        {
            context.Remove(training);
            context.SaveChanges();
        }
    }
}
