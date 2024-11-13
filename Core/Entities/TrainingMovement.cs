using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TrainingMovement : BaseEntity
    {
        //Training movement's infos
            public int TrainingId { get; set; }
            public string TrainingType { get; set; }
            public string MovementName { get; set; }
            public string Date { get; set; }

            //S E T S
            public double Set1_kg { get; set; }
            public double Set1_reps { get; set; }
            public double Set2_kg { get; set; }
            public double Set2_reps { get; set; }
            public double Set3_kg { get; set; }
            public double Set3_reps { get; set; }
            public double? Set4_kg { get; set; }
            public double? Set4_reps { get; set; }
            public double? Set5_kg { get; set; }
            public double? Set5_reps { get; set; }
            public double? Set6_kg { get; set; }
            public double? Set6_reps { get; set; }
        }

    }
