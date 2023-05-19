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
    public interface IStudentRepository : IRepository<Student>
    {

    }
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(EXDbContext context) : base(context)
        {
        }
    }
}
