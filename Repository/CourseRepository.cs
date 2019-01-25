using System;
using aimooc.Domain;
using aimooc.Data.Infrastructure;

namespace aimooc.Data
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(AIMoocDataContext context)
            : base(context)
        {
        }
    }
    public interface ICourseRepository : IRepository<Course>
    {

    }
}