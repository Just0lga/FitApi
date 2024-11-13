using System.ComponentModel.DataAnnotations;

public class TrainingMovementDto
{
    //Training movement's infos
    public int TrainingId { get; set; }
    [AllowedValues("Push1", "Push2", "Pull1", "Pull2", "Legs", ErrorMessage = "Business Type can be one of the following values: Push1, Push2, Pull1, Pull2, Legs")]
    public string TrainingType { get; set; }
    public string MovementName { get; set; }
    public string Date { get; set; }

    // S E T S
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
