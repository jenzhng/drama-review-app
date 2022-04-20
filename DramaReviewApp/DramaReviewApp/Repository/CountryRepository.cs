using AutoMapper;
using DramaReviewApp.Data;
using DramaReviewApp.Interfaces;
using DramaReviewApp.Models;

namespace DramaReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByDirector(int directorId)
        {
            return _context.Directors.Where(o => o.Id == directorId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Director> GetDirectorsFromACountry(int countryId)
        {
            return _context.Directors.Where(c => c.Country.Id == countryId).ToList();
        }
    }
}
