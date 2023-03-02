using System.Runtime.Serialization;

namespace Assignment3_WebAPI.Exceptions
{
    [Serializable]
    internal class FranchiseNotFoundException : Exception
    {
        public FranchiseNotFoundException(int id) : base($"Franchise with id {id} was not found")
        {

        }
    }
}