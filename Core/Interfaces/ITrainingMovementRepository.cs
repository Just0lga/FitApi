using Core.Entities;
using Core.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITrainingMovementRepository
    {
        //Bütün antrenman bilgileri gelecek
        Task<IReadOnlyList<TrainingMovement>> GetAllTrainingSets(TrainingMovementParameters trainingMovementParameters);

        //Bütün bench bilgileri gelecek
        Task<IReadOnlyList<TrainingMovement>> GetAllMovementInfo(string Movement, TrainingMovementParameters trainingMovementParameters);

        //Tolga/Push/10.25.2024
        //Tarihe göre hareketin bilgisi gelcek
        Task<TrainingMovement> GetAllTrainingMovementByDate(string TrainingType, string Movement, string Date);
        void CreateTrainingMovement(TrainingMovement trainingMovement);

        void DeleteTrainingMovement(TrainingMovement trainingMovement);
        Task UpdateTrainingMovement(TrainingMovement trainingMovement);
    }
}
