using Core.Dtos;
using Core.Entities;
using Core.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces;
    public interface ITrainingRepository
    {
        Task<IReadOnlyList<Training>> GetAllTrainings(TrainingMovementParameters trainingParameters);
        Task<Training> GetTrainingByDate(string date);

        void CreateTraining(Training training);
        void DeleteTraining(Training training);
        Task UpdateTraining(Training training);
    }

