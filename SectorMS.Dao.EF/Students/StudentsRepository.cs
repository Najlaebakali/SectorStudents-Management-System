using SectorMS.models;
using SectorMS.Dao.Abstraction;

namespace SectorMS.Dao.EF.Students
{
    public class StudentsRepository : IStudentRepository
    {
        private readonly List<Student> _students;

        public StudentsRepository()
        {
            _students = new List<Student>
            {
                new Student 
                { 
                    Id = 1, 
                    FirstName = "Najlae", 
                    LastName = "bk", 
                    Email = "najlaebk@example.com", 
                    Phone = "3423342", 
                    Address = "rue x", 
                    City = "Larache", 
                    State = "x", 
                    ZipCode = "92000", 
                    Country = "Morocco", 
                    DateOfBirth = new DateTime(2002, 6, 15), 
                    Gender = "Female", 
                    BirthPlace = "Larache",
                    SectorId = 1 
                }
            };
        }

        public IReadOnlyCollection<Student> GetAllStudents()
        {
            return _students.AsReadOnly();
        }

        public Student GetStudentById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public void AddStudent(Student student)
        {
            if (student != null)
            {
                _students.Add(student);
            }
        }

        public void UpdateStudent(Student student)
        {
            if (student != null)
            {
                var existingStudent = GetStudentById(student.Id);
                if (existingStudent != null)
                {
                    existingStudent.FirstName = student.FirstName;
                    existingStudent.LastName = student.LastName;
                    existingStudent.Email = student.Email;
                    existingStudent.Phone = student.Phone;
                    existingStudent.Address = student.Address;
                    existingStudent.City = student.City;
                    existingStudent.State = student.State;
                    existingStudent.ZipCode = student.ZipCode;
                    existingStudent.Country = student.Country;
                    existingStudent.DateOfBirth = student.DateOfBirth;
                    existingStudent.Gender = student.Gender;
                    existingStudent.BirthPlace = student.BirthPlace;
                    existingStudent.SectorId = student.SectorId;
                }
            }
        }

        public void DeleteStudent(int id)
        {
            var studentToRemove = GetStudentById(id);
            if (studentToRemove != null)
            {
                _students.Remove(studentToRemove);
            }
        }
    }
}
