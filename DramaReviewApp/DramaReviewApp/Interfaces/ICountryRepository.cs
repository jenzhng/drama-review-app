using DramaReviewApp.Models;

namespace DramaReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();

        Country GetCountry(int id);

        Country GetCountryByDirector(int directorId);

        ICollection<Director> GetDirectorsFromACountry(int countryId);

        bool CountryExists(int id);
    }
}
