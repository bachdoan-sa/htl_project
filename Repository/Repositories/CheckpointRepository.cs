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
    public class CheckpointRepository : ICheckpointRepository
    {
        private readonly AppDbContext _context;
        public CheckpointRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<Checkpoint> Add(Checkpoint roadmap)
        {
            _context.Checkpoints.Add(roadmap);
            _context.SaveChanges();
            return Task.FromResult(roadmap);
        }

        public Task<string> Delete(string id)
        {
            var entity = _context.Checkpoints.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }

        public Task<List<Checkpoint>> GetAll()
        {
            return _context.Checkpoints.ToListAsync();
        }

        public Task<Checkpoint> GetById(string id)
        {
            var acc = _context.Checkpoints.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (acc.Result != null)
            {
                return acc;

            }
            throw new Exception("NotFound!");
        }

        public Task<Checkpoint> Update(Checkpoint roadmap)
        {
            _context.Checkpoints.Update(roadmap);
            _context.SaveChanges();
            return Task.FromResult(roadmap);
        }
    }
}
