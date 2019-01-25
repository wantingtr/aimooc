using System;
using aimooc.Domain;
using aimooc.Data.Infrastructure;

namespace aimooc.Data
{
    public class CourseTypeRepository : RepositoryBase<CourseType>, ICourseTypeRepository
    {
        public CourseTypeRepository(AIMoocDataContext context)
            : base(context)
        {
        }
    }
    public interface ICourseTypeRepository : IRepository<CourseType>
    {

    }
}