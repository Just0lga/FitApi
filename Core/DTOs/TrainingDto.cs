using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class TrainingDto
    {
        public required string Date { get; set; }
        [AllowedValues("Push1", "Push2", "Pull1", "Pull2", "Legs", ErrorMessage = "Business Type can be one of the following values: Push1, Push2, Pull1, Pull2, Legs")]
        public required string TrainingType { get; set; }
    }
}
