using APIProjekt.Models;
using Microsoft.EntityFrameworkCore;
using Projekt.API.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.API.Services
{
    public class EmployeeRepository : IProjekt<Employee>
    {
        private ProjektDbContext _projekt;
        public EmployeeRepository(ProjektDbContext projekt)
        {
            _projekt = projekt;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _projekt.Employees.ToListAsync();
        }

        public async Task<Employee> GetSingle(int id)
        {
            return await _projekt.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<ICollection> GetOne(int id)
        {
            var list = (from emp in _projekt.Employees
                        join tr in _projekt.TimeReports
                        on emp.EmployeeId equals tr.EmployeeId
                        where emp.EmployeeId == id
                        select new
                        {
                            ID = emp.EmployeeId,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            Email = emp.Email,
                            Phone = emp.Phone,
                            TimereportId = tr.TimeReportId,
                            StartDate = tr.StartDate,
                            EndDate = tr.EndDate,
                            Week = tr.Week
                        }).ToListAsync();
            return await list;
        }

        public async Task<Employee> Add(Employee newEntity)
        {
            var result = await _projekt.AddAsync(newEntity);
            await _projekt.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> Delete(int id)
        {
            var result = await _projekt.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (result != null)
            {
                _projekt.Employees.Remove(result);
                await _projekt.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employee> Update(Employee Entity)
        {
            var result = await _projekt.Employees.FirstOrDefaultAsync(e => e.EmployeeId == Entity.EmployeeId);
            if (result != null)
            {
                result.FirstName = Entity.FirstName;
                result.LastName = Entity.LastName;
                result.Email = Entity.Email;
                result.Phone = Entity.Phone;

                await _projekt.SaveChangesAsync();
                return result;
            }
            return null;
        }

        Task<int> IProjekt<Employee>.GetDate(int id, int week)
        {
            throw new NotImplementedException();
        }
    }
}
