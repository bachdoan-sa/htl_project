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
        public Task<Roadmap> GetById(string id)
        {
            var acc = _context.Roadmaps.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (acc.Result != null)
            {
                return acc;

            }
            throw new Exception("NotFound!");
        }

        public  Task<List<Roadmap>> GetAll()
        {
            return _context.Roadmaps.Include(r => r.Sections)
                                    .Include(a => a.Career)
                                    .ToListAsync(); 
        }

        public  Task<Roadmap> Add(Roadmap roadmap)
        {
            _context.Roadmaps.Add(roadmap);
            _context.SaveChanges();
            return Task.FromResult(roadmap);
        }

        public Task<Roadmap> Update(Roadmap roadmap)
        {
            _context.Roadmaps.Update(roadmap);
            _context.SaveChanges();
            return Task.FromResult(roadmap);
        }

        public Task Delete(string id)
        {
            var entity = _context.Roadmaps.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }
    }
}
