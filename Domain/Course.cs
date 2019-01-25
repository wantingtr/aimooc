using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aimooc.Domain
{
    [Table("aicourse")]
    public class Course
    {
        [Key]
        public int courseID {get;set;}
        public string courseName {get;set;}
        public string courseIntro {get;set;}
        public string courseLevel {get;set;}
        public string courseURL {get;set;}
        public string courseTime {get;set;}

        public string courseImg {get;set;}
        public int relation { get; set;}
        public int courseorder { get; set; }
        public int courseType {get;set;}
        [ForeignKey("courseType")]
        public CourseType CourseTypeInfo {get;set;}
    }
}