using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using aimooc.Domain;
using aimooc.Data;
using aimooc.Data.Infrastructure;

namespace aimooc.Services
{   
    public interface ICourseService
    {
        IEnumerable<Course> GetCourseList(int courseType);
        Course GetCourseInfo(int courseID);
        IEnumerable<Course> GetRelationCourseList(int relation,int courseID);


    }
    
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUnitOfWork unitOfWork;
        
        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Course> GetCourseList(int courseType)
        {
            return this.courseRepository.GetMany(item=>item.courseType==courseType);
        }

        public Course GetCourseInfo(int courseID)
        {
            return this.courseRepository.Get(item =>item.courseID == courseID);
        }

        public IEnumerable<Course> GetRelationCourseList(int relation,int courseID)
        {
            return this.courseRepository.GetMany(item=>item.relation==relation && item.courseID != courseID);
        }

    }

}