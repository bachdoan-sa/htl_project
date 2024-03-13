using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface ICourseLessonService
    {
        Task<CourseLessonModel> GetById(string id);
        Task<List<CourseLessonModel>> GetAll();
        Task<CourseLessonModel> Add(CourseLessonModel model);
        Task<CourseLessonModel> Update(CourseLessonModel model);
        Task<string> Delete(string id);
        Task<CourseLessonModel> GetCourseLessonByCourseModuleId(string id);
    }
}
