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
        public async Task<Employee> Add(Employee employee)
        {
            HahnContext context = ContextHelper.GetContext();
            Employee newEmployee = (await context.Employees.AddAsync(employee)).Entity;
            await context.SaveChangesAsync();
            return newEmployee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            HahnContext context = ContextHelper.GetContext();
            Employee editEmployee = context.Employees.Attach(employee).Entity;
            await context.SaveChangesAsync();
            return editEmployee;
        }

        public async Task Delete(Employee employee)
        {
            HahnContext context = ContextHelper.GetContext();
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            if (id <= 0)
                throw new Exception($"invalid id value!");
            
            HahnContext context = ContextHelper.GetContext();
            return await context.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetAll()
        {
            HahnContext context = ContextHelper.GetContext();
            return await context.Employees.ToListAsync();
        }
    }
}