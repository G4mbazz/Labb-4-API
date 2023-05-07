using API_Models;
using Labb_4_API.DTO;
using Labb_4_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_4_API.Services
{
    public class PersonInterestsRepository : IPersonInterests
    {
        private AppDBContext _context;
        public PersonInterestsRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<PersonInterest> AddIntersest(int personID, int interestID)
        {
            var person = await _context.Persons.FindAsync(personID);
            var interest = await _context.Interests.FindAsync(interestID);
            if (person == null || interest == null)
            {
                return null;
            }
            var toAdd = new PersonInterest()
            {
                InterestID = interestID,
                PersonID = personID
            };
            await _context.PersonInterests.AddAsync(toAdd);
            await _context.SaveChangesAsync();
            return toAdd;
        }

        public async Task<Link> AddLink(string url, string personName, string interestName)
        {
            var result = await _context.PersonInterests.FirstOrDefaultAsync(p =>
             p.Person.Name.ToLower() == personName.ToLower() &&
             p.Interest.Title.ToLower() == interestName.ToLower());
            if (result == null)
            {
                return null;
            }
            var link = new Link()
            {
                URL = url,
                PersonInterestID = result.ID
            };
            await _context.Links.AddAsync(link);
            await _context.SaveChangesAsync();
            return link;
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<IEnumerable<Interests>> GetInterestByPersonID(int personID)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.PersonID == personID);
            if (person != null)
            {
                var interest = await _context.PersonInterests.Where(p => p.PersonID == personID).Select(n => n.Interest).ToListAsync();
                return interest;
            }

            return null;
        }

        public async Task<IEnumerable<LinksDTO>> GetLinksById(int personID)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.PersonID == personID);

            if (person != null)
            {
                var links = await _context.Links.Where(p => p.PersonInterest.PersonID == personID).Select(x => new LinksDTO
                {
                    InterestName = x.PersonInterest.Interest.Title,
                    PersonName = x.PersonInterest.Person.Name,
                    URL = x.URL

                }).ToListAsync();
                if (links != null)
                {
                    return links;

                }
            }


            return null;
        }
    }
}
