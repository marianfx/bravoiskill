using BravoiSkill.Domain.Entities.Users;
using System.Linq;

namespace BravoiSkill.Domain.Interfaces.Repositories.Users
{
   public interface IDepartmentRepository
    {
        
        IQueryable<Department> GetListOfDepartments();

        Department GetDepartmentById(int id);

       Department Create(Department department);

        Department Update(Department department);
    }
}
