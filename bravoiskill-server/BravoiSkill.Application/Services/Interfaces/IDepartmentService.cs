using BravoiSkill.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;
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
