using Test_2.Models;

namespace Test_2.Services
{
    public class StudentServices
    {
        private static List<Model> _students = new List<Model>
        {
            new Model
            {
                  StudentId = 1,
                  StudentName= "Test",
                  isActive= true
            },
            new Model
            {
                  StudentId = 2,
                  StudentName= "Test",
                  isActive= false
            },
            new Model
            {
                  StudentId = 3,
                  StudentName= "Test",
                  isActive= true
            },
            new Model
            {
                  StudentId = 4,
                  StudentName= "Test",
                  isActive= false
            },
            new Model
            {
                  StudentId = 5,
                  StudentName= "Test",
                  isActive= true
            }
        };  
        // return all student
      public List<Model> isFavorite(int id)
{
    var student = _students.SingleOrDefault(m => m.StudentId == id);

    if (student != null)
    {
        student.isActive = !student.isActive;
        //_context.SaveChanges();
    }

    return _students.ToList();
}


        public List<Model> allEvents()
        {
            return _students;
        }

        public Model GetById(int id)
        {
            return _students.FirstOrDefault(m => m.StudentId == id);

        }


        public void Update(Model model,int id)
        {
            var student = GetById(id);
            student.isActive =! model.isActive;
        }

    }
}
   

