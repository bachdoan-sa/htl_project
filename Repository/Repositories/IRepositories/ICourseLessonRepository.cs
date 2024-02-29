using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.IRepositories
{
    public interface ICourseLessonRepository
    {
        Task<CourseLesson> GetById(string id);
        Task<List<CourseLesson>> GetAll();
        Task<CourseLesson> Add(CourseLesson courseLesson);
        Task<CourseLesson> Update(CourseLesson courseLesson);
        Task<string> Delete(string id);
    }
}
