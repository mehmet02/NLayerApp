﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core.Model;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories;

public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Category> GetSingleCategoryByIdWithProductAsync(int categoryid)
    {
        return await _context.Categories.Include(x => x.Products).Where(x => x.Id == categoryid).SingleOrDefaultAsync();
    }
}