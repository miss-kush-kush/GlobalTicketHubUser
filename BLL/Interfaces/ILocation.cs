using DLL.Dtos.LocationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILocation
    {
        Task AddCountryAsync(CountryDto countryDto);
        Task AddLocationsAsync(List<LocationDto> locationDtos);
    }
}
