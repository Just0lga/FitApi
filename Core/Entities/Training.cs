using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Training : BaseEntity
    {
        public required string Date { get; set; }
        public required string TrainingType { get; set; }
    }
}
