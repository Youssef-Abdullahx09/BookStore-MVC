using DataAccess.Repository.IRepository;
using Models;
using MVC_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly AppDbContext _appDbContext;

        public CoverTypeRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }
        public void Update(CoverType coverType)
        {
            _appDbContext.CoverTypes.Update(coverType);
        }
    }
}
