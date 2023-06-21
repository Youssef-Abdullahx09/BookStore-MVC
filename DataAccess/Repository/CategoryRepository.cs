using DataAccess.Repository.IRepository;
using Models;
using MVC_Project.Data;

namespace DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext  _appDbContext;

        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }


        public void Update(Category category)
        {
            _appDbContext.Categories.Update(category);
        }
    }
}
