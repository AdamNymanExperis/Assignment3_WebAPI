namespace Assignment3_WebAPI.Exceptions
{
    public class CharacterNotFoundException : Exception
    {
        public CharacterNotFoundException(int id) : base($"Character with id {id} was not found")
        {

        }
    }
}
