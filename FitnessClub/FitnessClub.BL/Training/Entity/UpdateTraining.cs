namespace FitnessClub.FitnessClub.BL.Training.Entity;

public class UpdateTraining
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Cost { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }   
}