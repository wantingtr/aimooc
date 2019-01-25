using System;
using System.Collections.Generic;

namespace aimooc.Models
{
    public class VideoInfo
    {
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
    }


    public class Video
    {
        public int typeID {get;set;}

        public string typeName {get;set;}

        public IList<VideoInfo> CourseList {get; set;}

    }

    public class OnLineVideo
    {
        public VideoInfo video {get;set;}

        public IList<VideoInfo> RelationVideoList {get;set;}
    }


}