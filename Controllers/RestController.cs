using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using aimooc.Services;
using aimooc.Domain;
using aimooc.Models;

namespace aimooc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : ControllerBase
    {


        private readonly ICourseTypeService _courseTypeService;
        private readonly ICourseService _courseService;

        public RestController(ICourseTypeService courseTypeService, ICourseService courseService)
        {
            _courseTypeService = courseTypeService;
            _courseService = courseService;
        }

        
        [HttpGet("GetVideo")]
        public OnLineVideo GetVideo(int courseID)
        {
            OnLineVideo video = new OnLineVideo();

            var videoInfo = _courseService.GetCourseInfo(courseID);

            VideoInfo currentVideo = new VideoInfo();

            currentVideo.courseID = videoInfo.courseID;
            currentVideo.courseIntro = videoInfo.courseIntro;
            currentVideo.courseLevel = videoInfo.courseLevel;
            currentVideo.courseName = videoInfo.courseName;
            currentVideo.courseTime = videoInfo.courseTime;
            currentVideo.courseType = videoInfo.courseType;
            currentVideo.courseURL = videoInfo.courseURL;
            currentVideo.courseorder = videoInfo.courseorder;
            currentVideo.relation = videoInfo.relation;
            currentVideo.courseImg = videoInfo.courseImg;

            video.video = currentVideo;



            var realtionID = videoInfo.relation;

            var relationList = _courseService.GetRelationCourseList(realtionID,courseID);


            IList<VideoInfo> onLineList = new List<VideoInfo>();

            foreach(var info in relationList)
            {

                    VideoInfo vi = new VideoInfo();
                    vi.courseID = info.courseID;
                    vi.courseIntro = info.courseIntro;
                    vi.courseLevel = info.courseLevel;
                    vi.courseName = info.courseName;
                    vi.courseTime = info.courseTime;
                    vi.courseType = info.courseType;
                    vi.courseURL = info.courseURL;
                    vi.courseorder = info.courseorder;
                    vi.relation = info.relation;
                    vi.courseImg = info.courseImg;

                    onLineList.Add(vi);

            }

            video.RelationVideoList = onLineList;



            return video;
        }


        

        

        // GET api/values
        [HttpGet("GetCourseTypeList")]
        public IList<Video> GetCourseTypeList()
        {
            var courseTypeList = _courseTypeService.GetCourseTypeList();

            IList<Video> videoList= new List<Video>();

            foreach(var item in courseTypeList)
            {
                Video ct =new Video();
                ct.typeID = item.typeID;
                ct.typeName = item.typeName;

                var list =_courseService.GetCourseList(item.typeID).ToList();

                IList<VideoInfo> infoList = new List<VideoInfo>();

                foreach(var info in list)
                {
                    VideoInfo vi=new VideoInfo();
                    vi.courseID = info.courseID;
                    vi.courseIntro = info.courseIntro;
                    vi.courseLevel = info.courseLevel;
                    vi.courseName = info.courseName;
                    vi.courseTime = info.courseTime;
                    vi.courseType = info.courseType;
                    vi.courseURL = info.courseURL;
                    vi.courseorder = info.courseorder;
                    vi.courseImg = info.courseImg;
                    vi.relation = info.relation;
                    infoList.Add(vi);
                }

                ct.CourseList =infoList;

               // ct.CourseList =  _courseService.GetCourseList(item.typeID).ToList();
                videoList.Add(ct);
            }
                
        
            return videoList;
        }
    }
}
