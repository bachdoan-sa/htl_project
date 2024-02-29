using Repository.Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface ICourseService
    {
        Task<Course> GetById(string id);
        Task<List<Course>> GetAll();
        Task<Course> Add(Course course);
        Task<Course> Update(Course model);
        Task<string> Delete(string id);
    }
}
