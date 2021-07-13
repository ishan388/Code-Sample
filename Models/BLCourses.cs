using System.Collections.Generic;
using System.Linq;

namespace StudentAdmissionManagement.Models
{
    public class BLCourses
    {
        public void AddOrUpdateCourse(Course course)
        {
            using (StudentAdmissionEntities ctx = new StudentAdmissionEntities())
            {
                Course objCourseUpdate = this.GetCourseDetails(course.coId);
                if (objCourseUpdate == null)
                {
                    ctx.Courses.Add(course);
                }
                else
                {
                    objCourseUpdate.coName = course.coName;
                    objCourseUpdate.coNoOfSems = course.coNoOfSems;
                    objCourseUpdate.coStatus = course.coStatus;
                    ctx.Entry(objCourseUpdate).State = System.Data.Entity.EntityState.Modified;
                }
                ctx.SaveChanges();
            }
        }

        public List<Course> GetCoursesList()
        {
            using (StudentAdmissionEntities ctx = new StudentAdmissionEntities())
            {
                return ctx.Courses.ToList();
            }
        }

        public Course GetCourseDetails(int courseId)
        {
            using (StudentAdmissionEntities ctx = new StudentAdmissionEntities())
            {
                return (from obj in ctx.Courses
                        where obj.coId == courseId
                        select obj).FirstOrDefault();
            }
        }

        public void RemoveCourse(int courseId)
        {
            using (StudentAdmissionEntities ctx = new StudentAdmissionEntities())
            {
                Course objCourseDelete = this.GetCourseDetails(courseId);
                ctx.Entry(objCourseDelete).State = System.Data.Entity.EntityState.Deleted;
                ctx.Courses.Remove(objCourseDelete);
                ctx.SaveChanges();
            }
        }

        public List<Course_Status> GetCourseStatusList()
        {
            using (StudentAdmissionEntities ctx = new StudentAdmissionEntities())
            {
                return ctx.Course_Status.ToList();
            }
        }
    }
}