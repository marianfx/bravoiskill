using BravoiSkill.Application.DTO.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BravoiSkill.Application.Services.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll();

        Department GetById(int id);

        void Create(Department department);

        Task Edit(int id, Department department);

        void Delete(int id);
    }   
}
