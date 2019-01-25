using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aimooc.Domain
{
    [Table("aicoursetype")]
    public class CourseType
    {
        [Key]

        public int typeID {get;set;}

        public string typeName {get;set;}

        public List<Course> CourseList {get; set;}
    }
}