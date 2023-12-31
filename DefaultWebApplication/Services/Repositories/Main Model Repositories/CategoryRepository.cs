﻿using DefaultWebApplication.Attributes;
using DefaultWebApplication.Database;
using DefaultWebApplication.Extensions;
using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Models.Domain_Models.Main_Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultWebApplication.Services.Repositories.Main_Model_Repositories
{
    [CustomService(Lifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
    public class CategoryRepository : IRepository<Category, CategoryCommandModel>
    {
        #region Properties and Service Instances
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Interface Methods
        public async Task<Category> CreateEntity(CategoryCommandModel command)
        {
            var category = new Category
            {
                Name = command.CategoryName,
                TagName = command.CategoryTagName ?? GenerateCategoryTagName(command)
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task DeleteEntityCollection(Func<Category, bool> criteria)
        {
            var matchingCategories = await _context.Categories.ToListAsync();
            matchingCategories = matchingCategories.Where(criteria).ToList();

            foreach (var matchingCategory in matchingCategories)
            {
                matchingCategory.Deleted = true;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetEntityCollection(
            Func<Category, bool> criteria, bool includeItemList = false)
        {
            var matchingCategoriesQueryable = _context.Categories.AsQueryable();

            if (includeItemList is true)
                matchingCategoriesQueryable = matchingCategoriesQueryable.Include(c => c.ItemList);

            var matchingCategories = await matchingCategoriesQueryable.ToListAsync();
            return matchingCategories.Where(criteria);
        }

        public async Task<Category> UpdateEntity(Func<Category, bool> criteriaUnique, CategoryCommandModel command)
        {
            var matchingCategories = await _context.Categories.ToListAsync();
            matchingCategories = matchingCategories.Where(criteriaUnique).ToList();

            if (matchingCategories.Count > 1)
                throw new Exception("Given criteria does not uniquely define a single entity from the context.");
            if (!matchingCategories.Any())
                throw new Exception("Given criteria is not satisfied by any entity from the context.");

            var category = matchingCategories.First();

            category.Name = command.CategoryName;
            category.TagName = command.CategoryTagName ?? GenerateCategoryTagName(command);

            await _context.SaveChangesAsync();
            return category;
        }
        #endregion

        #region Specific Methods
        public async Task<Category> CreateCategory(CategoryCommandModel command)
            => await CreateEntity(command);

        public async Task DeleteCategoryById(int categoryId)
        {
            await DeleteEntityCollection(category => category.CategoryId == categoryId);
        }

        public async Task<Category> GetCategoryById(int categoryId, bool includeItemList = false)
        {
            var enumerableCategoryList = await GetEntityCollection(
                category => category.CategoryId == categoryId, includeItemList);
            return enumerableCategoryList.First();
        }

        public async Task<Category> UpdateCategoryById(int categoryId, CategoryCommandModel command)
            => await UpdateEntity(category => category.CategoryId == categoryId, command);

        #endregion

        #region Helper Methods
        private string GenerateCategoryTagName(CategoryCommandModel command)
        {
            return command.CategoryName[0..3];
        }
        #endregion
    }
}
