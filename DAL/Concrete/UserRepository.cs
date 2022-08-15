using DAL.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class UserRepository : BaseRepository<TblUser, Guid>, IUserRepository
    {

        public UserRepository(ProjectHRMContext dbContext) : base(dbContext)
        {
        }

        public TblUser GetById(Guid id)
        {
            var user = context.Where(a => a.UserId == id).FirstOrDefault();
            return user;
        }


    }


}
