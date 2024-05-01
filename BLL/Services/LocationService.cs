using BLL.Interfaces;
using DLL.DbContext;
using DLL.Dtos.LocationDtos;
using Domain.Entities.LocationEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LocationService: ILocation
    {
        private readonly AppDbContext _context;

        public LocationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCountryAsync(CountryDto countryDto)
        {
            var country = new Country
            {
                CountryName = countryDto.CountryName
            };
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
        }

        public async Task AddLocationsAsync(List<LocationDto> locationDtos) // Add multiple locations
        {
            var locations = locationDtos.Select(locationDto => new Location
            {
                LocationName = locationDto.LocationName,
                PostalCode = locationDto.PostalCode,
                CountryId = locationDto.CountryId
            }).ToList();

            _context.Locations.AddRange(locations); // Add all at once
            await _context.SaveChangesAsync();
        }
    }
}
