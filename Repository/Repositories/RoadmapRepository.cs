using Microsoft.EntityFrameworkCore;
using Repository.ApplicationDbContext;
using Repository.Entities;
using Repository.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class RoadmapRepository : IRoadmapRepository
    {
        private readonly AppDbContext _context;

        public RoadmapRepository(AppDbContext context) 
        { 
            _context = context;
        }
        public async Task<Roadmap> GetByIdAsync(string id)
        {
            return await _context.Roadmaps.FindAsync(id);
        }

        public async Task<List<Roadmap>> GetAllAsync()
        {
            return await _context.Roadmaps.ToListAsync();
        }

        public async Task AddAsync(Roadmap roadmap)
        {
            _context.Roadmaps.Add(roadmap);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Roadmap roadmap)
        {
            _context.Entry(roadmap).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var roadmap = await GetByIdAsync(id);
            if (roadmap != null)
            {
                _context.Roadmaps.Remove(roadmap);
                await _context.SaveChangesAsync();
            }
        }
    }
}
