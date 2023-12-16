using DefaultWebApplication.Attributes;
using DefaultWebApplication.Database;
using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Models.Domain_Models.Main_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DefaultWebApplication.Services.Repositories.Main_Model_Repositories
{
    [CustomService(Lifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
    public class SizeRepository : IRepository<Size, SizeCommandModel>
    {
        #region Properties and Service Instances
        private readonly AppDbContext _context;

        public SizeRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Interface Methods
        public async Task<Size> CreateEntity(SizeCommandModel command)
        {
            var size = new Size
            {
                Name = command.SizeName,
                TagName = command.SizeTagName ?? GenerateSizeTagName(command)
            };

            await _context.Sizes.AddAsync(size);
            await _context.SaveChangesAsync();

            return size;
        }

        public async Task DeleteEntityCollection(Func<Size, bool> criteria)
        {
            var matchingSizes = await _context.Sizes.ToListAsync();
            matchingSizes = matchingSizes.Where(criteria).ToList();
            foreach (var matchingSize in matchingSizes)
            {
                matchingSize.Deleted = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Size>> GetEntityCollection(
            Func<Size, bool> criteria, bool includeItemList = false)
        {
            var matchingSizesQueryable = _context.Sizes.AsQueryable();

            if (includeItemList is true)
                matchingSizesQueryable = matchingSizesQueryable.Include(s => s.ItemList);

            var matchingSizes = await matchingSizesQueryable.ToListAsync();
            return matchingSizes.Where(criteria);
        }

        public async Task<Size> UpdateEntity(Func<Size, bool> criteriaUnique, SizeCommandModel command)
        {
            var matchingSizes = await _context.Sizes.ToListAsync();
            matchingSizes = matchingSizes.Where(criteriaUnique).ToList();

            if (matchingSizes.Count > 1)
                throw new Exception("Given criteria does not uniquely define a single entity from the context.");
            if (!matchingSizes.Any())
                throw new Exception("Given criteria is not satisfied by any entity from the context.");

            var size = matchingSizes.First();

            size.Name = command.SizeName;
            size.TagName = command.SizeTagName ?? GenerateSizeTagName(command);

            await _context.SaveChangesAsync();
            return size;
        }
        #endregion

        #region Specific Methods
        public async Task<Size> CreateSize(SizeCommandModel command)
        {
            return await CreateEntity(command);
        }

        public async Task DeleteSizeById(int sizeId)
        {
            await DeleteEntityCollection(size => size.SizeId == sizeId);
        }
        
        public async Task<Size> GetSizeById(int sizeId, bool includeItemList = false)
        {
            var enumerableSizeList = await GetEntityCollection(size => size.SizeId == sizeId, includeItemList);
            return enumerableSizeList.First();
        }

        public async Task<Size> UpdateSizeById(int sizeId, SizeCommandModel command)
        {
            return await UpdateEntity(size => size.SizeId == sizeId, command);
        }
        #endregion

        #region Helper Methods
        private string GenerateSizeTagName(SizeCommandModel command)
        {
            return command.SizeName[0..3];
        }
        #endregion
    }
}
