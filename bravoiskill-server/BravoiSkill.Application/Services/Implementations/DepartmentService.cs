using AutoMapper;
using BravoiSkill.Application.DTO.Users;
using BravoiSkill.Application.Services.Interfaces;
using BravoiSkill.Domain.Interfaces.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BravoiSkill.Application.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;
        private IMapper _mapper;

        public DepartmentService( IDepartmentRepository departmentRepository,
            IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public IEnumerable<Department> GetAll()
        {
            var departmentsDb = _departmentRepository.GetListOfDepartments();
            var departmentsDto = departmentsDb
                .Select(departmentDb => _mapper.Map<Department>(departmentDb))
                .ToList();

            return departmentsDto;
        }

        public Department GetById(int id)
        {
            var departmentDb = _departmentRepository.GetDepartmentById(id);
            return _mapper.Map<Department>(departmentDb);
        }

        public void Create(Department department)
        {
            var departmentEntity = _mapper.Map<Domain.Entities.Users.Department>(department);
            _departmentRepository.Create(departmentEntity);
        }

        public async Task Edit(int id, Department department)
        {
            department.Validate();
            if (department.HasErrors)
                throw new Exception(department.Errors[0]);

            var departmentEntity = _departmentRepository.GetDepartmentById(id);
            if (departmentEntity == null)
                throw new Exception("Department does not exist in database");
            department.DepartmentId = departmentEntity.DepartmentId;

            _mapper.Map<Department, Domain.Entities.Users.Department>(department, departmentEntity);
            _departmentRepository.Update(departmentEntity);
        }

        public void Delete(int id)
        {
            var departmentEntity = _departmentRepository.GetDepartmentById(id);
            if (departmentEntity == null)
                throw new Exception("Department does not exist in database");

            _departmentRepository.Delete(departmentEntity);
        }
    }
}

