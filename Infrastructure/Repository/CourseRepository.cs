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
    public interface ICourseRepository : IRepository<Course>
    {

    }
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(EXDbContext context) : base(context)
        {
        }
    }
}
