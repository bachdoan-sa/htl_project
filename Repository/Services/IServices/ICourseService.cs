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
        Task<CourseModel> GetById(string id);
        Task<List<CourseModel>> GetAll();
        Task<CourseModel> Add(CourseModel model);
        Task<CourseModel> Update(CourseModel model);
        Task<string> Delete(string id);
    }
}
