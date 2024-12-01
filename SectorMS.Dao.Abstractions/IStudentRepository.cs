using SectorMS.models;

namespace SectorMS.Dao.Abstraction;

public interface IStudentRepository
{
    IReadOnlyCollection<Student> GetAllStudents();  
    Student GetStudentById(int id);
    void AddStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(int id);
    
    
}