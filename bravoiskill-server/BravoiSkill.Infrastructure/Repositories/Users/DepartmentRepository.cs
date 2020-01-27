using BravoiSkill.Domain.Entities.Users;
using BravoiSkill.Domain.Interfaces.Repositories.Users;
using BravoiSkill.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BravoiSkill.Infrastructure.Repositories.Users
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private BravoiSkillDbContext _context;

        public DepartmentRepository(BravoiSkillDbContext context)
        {
            _context = context;
        }

        public IQueryable<Department> GetListOfDepartments()
        {
            var rez = from d in _context.Departments
                      select d;
            return rez;
        }

        public Department GetDepartmentById(int id)
        {
            var rez = from d in _context.Departments
                      where d.DepartmentId == id
                      select d;
            return rez.FirstOrDefault();
        }

        public Department Create(Department department)
        {
            _context.Set<Department>().Add(department);
            _context.SaveChanges();
            return department;
        }

        public Department Update(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            _context.SaveChanges();
            return department;
        }

        public void Delete(Department department)
        {
            _context.Set<Department>().Remove(department);
            _context.SaveChanges();
        }
    }
}
