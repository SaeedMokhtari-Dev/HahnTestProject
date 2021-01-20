using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Data.Helpers;
using Hahn.ApplicationProcess.December2020.Data.Persistence;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.December2020.Data.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly HahnContext _hahnContext;
        public EmployeeRepository(HahnContext hahnContext)
        {
            _hahnContext = hahnContext;
        }
        public async Task<Employee> Add(Employee employee)
        {
            Employee newEmployee = (await _hahnContext.Employees.AddAsync(employee)).Entity;
            await _hahnContext.SaveChangesAsync();
            return newEmployee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            Employee editEmployee = _hahnContext.Employees.Attach(employee).Entity;
            await _hahnContext.SaveChangesAsync();
            return editEmployee;
        }

        public async Task Delete(Employee employee)
        {
            _hahnContext.Employees.Remove(employee);
            await _hahnContext.SaveChangesAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            if (id <= 0)
                throw new Exception($"invalid id value!");
            
            return await _hahnContext.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetAll()
        {
            HahnContext _hahnContext = ContextHelper.GetContext();
            return await _hahnContext.Employees.ToListAsync();
        }
    }
}