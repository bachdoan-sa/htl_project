using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
    public class SectionRepository : ISectionRepository
    {
        private readonly AppDbContext _context;
        public SectionRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<Section> GetById(string id)
        {
            var sec = _context.Sections.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (sec.Result != null)
            {
                return sec;

            }
            throw new Exception("NotFound!");
        }
        public Task<List<Section>> GetAll()
        {
            return _context.Sections.ToListAsync();
        }
        public Task<Section> Add(Section section)
        {
            _context.Sections.Add(section);
            _context.SaveChanges();
            return Task.FromResult(section);
        }
        public Task<Section> Update(Section section)
        {
            _context.Sections.Update(section);
            _context.SaveChanges();
            return Task.FromResult(section);
        }
        public Task<string> Delete(string id)
        {

            var entity = _context.Sections.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }

        public async Task<List<Section>> GetListSectionByRoadmapId(string id)
        {
            try
            {
                return await _context.Sections.Where(p => p.RoadmapId == id).ToListAsync();
            } catch
            {
                throw;
            }
        }
    }
}
