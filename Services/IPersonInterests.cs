using API_Models;
using Labb_4_API.DTO;

namespace Labb_4_API.Services
{
    public interface IPersonInterests
    {
        Task <IEnumerable<Person>> GetAllPeople();
        Task<IEnumerable<Interests>> GetInterestByPersonID(int personID);
        Task<IEnumerable<LinksDTO>> GetLinksById(int personID);
        Task<PersonInterest> AddIntersest(int personID, int interestID);
        Task<Link> AddLink(string url,string personName, string interestName);


    }
}
