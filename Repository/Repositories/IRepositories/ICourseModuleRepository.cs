using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.IRepositories
{
    public interface ICourseModuleRepository
    {
        Task<CourseModule> GetById(string id);
        Task<List<CourseModule>> GetAll();
        Task<CourseModule> Add(CourseModule courseModule);
        Task<CourseModule> Update(CourseModule courseModule);
        Task<string> Delete(string id);
    }
}
