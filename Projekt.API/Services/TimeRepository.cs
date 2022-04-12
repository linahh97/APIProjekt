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
    public class TimeRepository : IProjekt<TimeReport>
    {
        private ProjektDbContext _projekt;
        public TimeRepository(ProjektDbContext projekt)
        {
            _projekt = projekt;
        }

        public async Task<IEnumerable<TimeReport>> GetAll()
        {
            return await _projekt.TimeReports.ToListAsync();
        }

        public async Task<TimeReport> GetSingle(int id)
        {
            return await _projekt.TimeReports.FirstOrDefaultAsync(t => t.TimeReportId == id);
        }

        public Task<ICollection> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TimeReport> Add(TimeReport newEntity)
        {
            var result = await _projekt.AddAsync(newEntity);
            await _projekt.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TimeReport> Delete(int id)
        {
            var result = await _projekt.TimeReports.FirstOrDefaultAsync(t => t.TimeReportId == id);
            if (result != null)
            {
                _projekt.TimeReports.Remove(result);
                await _projekt.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TimeReport> Update(TimeReport Entity)
        {
            var result = await _projekt.TimeReports.FirstOrDefaultAsync(t => t.TimeReportId == Entity.TimeReportId);
            if (result != null)
            {
                result.StartDate = Entity.StartDate;
                result.EndDate = Entity.EndDate;
                result.Week = Entity.Week;

                await _projekt.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<int> GetDate(int id, int week)
        {
            var result = await _projekt.TimeReports.Where(t => t.EmployeeId == id && t.Week == week).CountAsync();
            return result * 8;
        }
    }
}
