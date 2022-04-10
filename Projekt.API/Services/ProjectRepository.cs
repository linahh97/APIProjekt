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
    public class ProjectRepository : IProjekt<Project>
    {
        private ProjektDbContext _projekt;
        public ProjectRepository(ProjektDbContext projekt)
        {
            _projekt = projekt;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _projekt.Projects.ToListAsync();
        }
        public async Task<Project> GetSingle(int id)
        {
            return await _projekt.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
        }

        public async Task<ICollection> GetOne(int id)
        {
            IQueryable<Project> pro = _projekt.Projects.Include(e => e.Employee);
            if (!pro.Equals(id))
            {
                pro = pro.Where(p => p.ProjectId == id);
            }
            return pro.ToList();
        }

        public async Task<Project> Add(Project newEntity)
        {
            var result = await _projekt.AddAsync(newEntity);
            await _projekt.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Project> Delete(int id)
        {
            var result = await _projekt.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (result != null)
            {
                _projekt.Projects.Remove(result);
                await _projekt.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Project> Update(Project Entity)
        {
            var result = await _projekt.Projects.FirstOrDefaultAsync(p => p.ProjectId == Entity.ProjectId);
            if (result != null)
            {
                result.ProjectName = Entity.ProjectName;

                await _projekt.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
