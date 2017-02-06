using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZindeBlog.Web.Entities.Blog;
using ZindeBlog.Web.Infrastructure.Core;
using ZindeBlog.Web.Infrastructure.Extensions;
using ZindeBlog.Web.ViewModels.Category;

namespace ZindeBlog.Web.Infrastructure.Services
{
    public class CategoryService
    {
        private ZindeBlogContext BlogContext { get; set; }

        public CategoryService(ZindeBlogContext blogContext)
        {
            BlogContext = blogContext;
        }

        public async Task<List<CategoryModel>> All()
        {
            List<CategoryModel> list = BlogContext.QueryAllCategoryFromCache();
            return await Task.FromResult(list);
        }

        public async Task<OperationResult<int>> Add(string name, string description)
        {
            if (await BlogContext.Categories.AnyAsync(t => t.Name == name))
            {
                return OperationResult<int>.Failure("Category Add failure");
            }

            var entity = new Category
            {
                Description = description,
                Name = name
            };
            BlogContext.Categories.Add(entity);
            await BlogContext.SaveChangesAsync();

            BlogContext.RemoveCategoryCache();

            return new OperationResult<int>(entity.ID);
        }

        public async Task<OperationResult> Edit(int id, string name, string description)
        {
            if (await BlogContext.Categories.AnyAsync(t => t.Name == name && t.ID != id))
            {
                return OperationResult.Failure("Category Edit Failure");
            }

            Category entity = await BlogContext.Categories.SingleOrDefaultAsync(t => t.ID == id);
            if (entity == null)
            {
                return OperationResult.Failure("Category Edit Failure");
            }

            entity.Name = name;
            entity.Description = description;
            await BlogContext.SaveChangesAsync();

            BlogContext.RemoveCategoryCache();

            return new OperationResult();
        }

        public async Task Remove(int[] idList)
        {
            List<CategoryTopic> categoryTopics = await BlogContext.CategoryTopics.Where(t => idList.Contains(t.CategoryID)).ToListAsync();
            List<Category> categories = await BlogContext.Categories.Where(t => idList.Contains(t.ID)).ToListAsync();

            BlogContext.RemoveRange(categoryTopics);
            BlogContext.RemoveRange(categories);

            await BlogContext.SaveChangesAsync();

            BlogContext.RemoveCategoryCache();
        }
    }
}
