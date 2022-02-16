using AutoMapper;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;
using TaskManagement.Managing.UnitOfWorks;

namespace TaskManagement.Managing.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IManagingUnitOfWork _managingUnitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IManagingUnitOfWork managingUnitOfWork,
            IMapper mapper)
        {
            _managingUnitOfWork = managingUnitOfWork;
            _mapper = mapper;
        }

        public IList<Employee> GetAllEmployee()
        {
            var employeeEntities = _managingUnitOfWork.Employees.GetAll();
            var employees = new List<Employee>();

            foreach (var entity in employeeEntities)
            {
                var employee = _mapper.Map<Employee>(entity);
                employees.Add(employee);
            }

            return employees;
        }
        public Employee GetEmployee(int id)
        {
            var employee = _managingUnitOfWork.Employees.GetById(id);

            if (employee == null) return null;

            return _mapper.Map<Employee>(employee);
        }

        public void CreateEmployee(Employee employee)
        {
            if (employee == null)
                throw new InvalidParameterException("Employee was not provided");

            if (IsNIDAlreadyUsed(employee.NationalId))
                throw new InvalidParameterException("NationalId already exists");

            if (IsMobileAlreadyUsed(employee.Mobile))
                throw new InvalidParameterException("Mobile already exists");

            if (IsEmailAlreadyUsed(employee.Email))
                throw new InvalidParameterException("Email already exists");

            _managingUnitOfWork.Employees.Add(
                _mapper.Map<Entities.Employee>(employee)
             );

            _managingUnitOfWork.Save();
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee == null)
                throw new InvalidOperationException("Employee is missing");

            var employeeEntity = _managingUnitOfWork.Employees.GetById(employee.Id);

            if (employeeEntity != null)
            {
                _mapper.Map(employee, employeeEntity);
                _managingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't find employee");
        }

        public void DeleteEmployee(int id)
        {
            _managingUnitOfWork.Employees.Remove(id);
            _managingUnitOfWork.Save();
        }

        private bool IsNIDAlreadyUsed(int nationalId) =>
    _managingUnitOfWork.Employees.GetCount(x => x.NationalId == nationalId) > 0;

        private bool IsMobileAlreadyUsed(int mobile) =>
_managingUnitOfWork.Employees.GetCount(x => x.Mobile == mobile) > 0;

        private bool IsEmailAlreadyUsed(string email) =>
    _managingUnitOfWork.Employees.GetCount(x => x.Email == email) > 0;
    }
}
