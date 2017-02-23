using DexCMS.Core.Models;
using System.Collections.Generic;

namespace DexCMS.Core.Interfaces
{
    public interface ICountryRepository:IRepository<Country>
    {
        IEnumerable<Country> CountryItems { get; }
    }
}
