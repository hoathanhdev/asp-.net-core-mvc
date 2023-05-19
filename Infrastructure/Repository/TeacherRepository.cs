using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EF;
using Infrastructure.Entities;
using Infrastructure.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public interface ITeacherRepository : IRepository<Teacher>
    {

    }
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(EXDbContext context) : base(context)
        {
        }
    }
}
