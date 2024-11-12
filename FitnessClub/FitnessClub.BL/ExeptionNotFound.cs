namespace FitnessClub.FitnessClub.BL;

public class ExeptionNotFound: ApplicationException
{
    public ExeptionNotFound() { }

    public ExeptionNotFound(string message) : base(message) { }

    public ExeptionNotFound(string message, Exception innerException) : base(message, innerException) { }
}