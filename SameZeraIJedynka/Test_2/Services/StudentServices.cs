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
        // return all events
        public List<Model> isFavorite()
        {
            return _students.Where(m => m.isActive == true).ToList();
        }

        public List<Model> allEvents()
        {
            return _students;
        }

        public Model GetById(int id)
        {
            return _students.FirstOrDefault(m => m.StudentId == id);
        }


        public void Update(Model model)
        {
            var events = GetById(model.StudentId);
            events.StudentName = model.StudentName;
            events.StudentId = model.StudentId;
            events.isActive = model.isActive;
        }

    }
}
   

