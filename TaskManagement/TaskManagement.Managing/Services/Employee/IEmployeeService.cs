using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;

namespace TaskManagement.Managing.Services
{

    public interface IEmployeeService
    {
        IList<Employee> GetAllEmployee();
        Employee GetEmployee(int id);
        void CreateEmployee(Employee project);
        void UpdateEmployee(Employee project);
        void DeleteEmployee(int id);
    }
}
