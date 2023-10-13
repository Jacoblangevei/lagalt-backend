namespace Lagalt_Backend.Data.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string type, Guid id)
            : base($"Entity '{type}' with ID '{id}' was not found.")
        {
        }
    }
}
