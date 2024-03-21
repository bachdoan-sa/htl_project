using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.IRepositories
{
    public interface ICourseRepository
    {
        Task<Course> GetById(string id);
        Task<List<Course>> GetAll();
        Task<Course> Add(Course course);
        Task<Course> Update(Course course);
        Task<string> Delete(string id);
        
    }
}
