using Student.Models;
using System.Reflection;

namespace Student.Service
{
    public class StudentService
    {
        private static List<StudentModel> _students = new List<StudentModel>
        {
            new StudentModel
            {
                StudentName="AAA",
                StudentId=1,
                isActive=true
            },new StudentModel
            {
                StudentName="BBB",
                StudentId=2,
                isActive=false
            },
            new StudentModel
            {
                StudentName="CCC",
                StudentId=3,
                isActive=true
            }
        };
        public List<StudentModel> GetAll()
        {
            return _students;
        }

        public List<StudentModel> GetById(int id)
        {
            return _students.Where(m => m.isActive == true).ToList();
        }

        public void Update(StudentModel model)
        {
            
         
        }

       
    }
}