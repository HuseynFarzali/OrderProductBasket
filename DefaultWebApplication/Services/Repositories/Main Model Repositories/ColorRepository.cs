﻿using DefaultWebApplication.Attributes;
using DefaultWebApplication.Database;
using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Models.Domain_Models.Main_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DefaultWebApplication.Services.Repositories.Main_Model_Repositories
{
    [CustomService(Lifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
    public class ColorRepository : IRepository<Color, ColorCommandModel>
    {
        #region Properties and Service Instances
        private readonly AppDbContext _context;

        public ColorRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Interface Methods
        public async Task<Color> CreateEntity(ColorCommandModel command)
        {
            var color = new Color
            {
                Name = command.ColorName,
                TagName = command.ColorTagName ?? GenerateColorTagName(command),
                RgbCode = command.ColorRgbCode
            };

            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();
            
            return color;
        }

        public async Task DeleteEntityCollection(Func<Color, bool> criteria)
        {
            var matchingColors = await _context.Colors.ToListAsync();
            matchingColors = matchingColors.Where(criteria).ToList();

            foreach (var matchingColor in matchingColors)
            {
                matchingColor.Deleted = true;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Color>> GetEntityCollection(
            Func<Color, bool> criteria, bool includeItemList = false)
        {
            var matchingColorsQueryable = _context.Colors.AsQueryable();

            if (includeItemList is true)
                matchingColorsQueryable = matchingColorsQueryable.Include(c => c.ItemList);

            var matchingColors = await matchingColorsQueryable.ToListAsync();
            return matchingColors.Where(criteria);
        }

        public async Task<Color> UpdateEntity(Func<Color, bool> criteriaUnique, ColorCommandModel command)
        {
            var matchingColors = await _context.Colors.ToListAsync();
            matchingColors = matchingColors.Where(criteriaUnique).ToList();

            if (matchingColors.Count > 1)
                throw new Exception("Given criteria does not uniquely define a single entity from the context.");
            if (!matchingColors.Any())
                throw new Exception("Given criteria is not satisfied by any entity from the context.");

            var color = matchingColors.First();

            color.Name = command.ColorName;
            color.TagName = command.ColorTagName ?? GenerateColorTagName(command);
            color.RgbCode = command.ColorRgbCode;

            await _context.SaveChangesAsync();
            return color;
        }
        #endregion

        #region Specific Methods
        public async Task<Color> CreateColor(ColorCommandModel command)
            => await CreateEntity(command);

        public async Task DeleteColorById(int colorId)
        {
            await DeleteEntityCollection(color => color.ColorId == colorId);
        }

        public async Task<Color> GetColorById(int colorId, bool includeItemList = false)
        {
            var enumerableColorList = await GetEntityCollection(
                color => color.ColorId == colorId, includeItemList);
            return enumerableColorList.First();
        }

        public async Task<Color> UpdateColorById(int colorId, ColorCommandModel command)
        {
            return await UpdateEntity(color => color.ColorId == colorId, command);
        }
        #endregion

        #region Helper Methods
        private string GenerateColorTagName(ColorCommandModel command)
        {
            return command.ColorName[0..3];
        }
        #endregion
    }
}
