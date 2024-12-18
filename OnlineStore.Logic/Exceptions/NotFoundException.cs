namespace OnlineStrore.Logic.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Guid id) : base($"Object with {id} wasn't found!")
        { }
        public NotFoundException() : base($"Object wasn't found!")
        { }
        //public NotFoundException(string email) : base($"Object with {email} wasn't found!")
        //{ }
    }
}
