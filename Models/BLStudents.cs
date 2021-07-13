using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAdmissionManagement.Models
{
    public class BLStudents
    {
        public short CalculateAge(DateTime dob)
        {
            return Convert.ToInt16(((DateTime.Now - dob).Days) / 365);
        }

        public void AddOrUpdateStudent(Student student)
        {
            using (StudentAdmissionEntities ctx = new StudentAdmissionEntities())
            {
                Student objStudentUpdate = this.GetStudentDetails(student.stuId);
                if (objStudentUpdate == null)
                {
                    student.stuAge = this.CalculateAge(student.stuDOB);
                    ctx.Students.Add(student);
                }
                else
                {
                    objStudentUpdate.stuName = student.stuName;
                    objStudentUpdate.stuDOB = student.stuDOB;
                    objStudentUpdate.stuAge = this.CalculateAge(student.stuDOB);
                    objStudentUpdate.stuGender = student.stuGender;
                    objStudentUpdate.stuStatus = student.stuStatus;
                    objStudentUpdate.stuCourseId = student.stuCourseId;
                    objStudentUpdate.stuSuspendTillDate = null;
                    if (student.stuStatus == 6)
                        objStudentUpdate.stuSuspendTillDate = student.stuSuspendTillDate;
                    ctx.Entry(objStudentUpdate).State = System.Data.Entity.EntityState.Modified;
                }
                ctx.SaveChanges();
            }
        }

        public List<Student> GetStudentsList()
        {
            using (StudentAdmissionEntities ctx = new StudentAdmissionEntities())
            {
                return ctx.Students.ToList();
            }
        }

        public Student GetStudentDetails(int studentId)
        {
            using (StudentAdmissionEntities ctx = new StudentAdmissionEntities())
            {
                return ctx.Students.Where(e => e.stuId == studentId).SingleOrDefault();
            }
        }

        public void RemoveStudent(int studentId)
        {
            using (StudentAdmissionEntities ctx = new StudentAdmissionEntities())
            {
                Student objStudentDelete = this.GetStudentDetails(studentId);
                ctx.Entry(objStudentDelete).State = System.Data.Entity.EntityState.Deleted;
                ctx.Students.Remove(objStudentDelete);
                ctx.SaveChanges();
            }
        }

        public List<Student_Status> GetStudentStatusList()
        {
            using (StudentAdmissionEntities ctx = new StudentAdmissionEntities())
            {
                return ctx.Student_Status.ToList();
            }
        }

        public List<Student> GetStudentsList(string searchText)
        {
            using (StudentAdmissionEntities ctx = new StudentAdmissionEntities())
            {
                return (from stu in ctx.Students
                        join co in ctx.Courses on stu.stuCourseId equals co.coId
                        join ss in ctx.Student_Status on stu.stuStatus equals ss.ssId
                        where (stu.stuName + co.coName + ss.ssName).ToLower().Contains(searchText.ToLower())
                        select stu).ToList();
            }
        }
    }
}