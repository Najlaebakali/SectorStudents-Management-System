using SectorMS.Dao.Abstraction;
using SectorMS.Dto;


namespace SectorMS.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ISectorRepository _sectorRepository;

        public StudentService(IStudentRepository studentRepository, ISectorRepository sectorRepository)
        {
            _studentRepository = studentRepository;
            _sectorRepository = sectorRepository;
        }

        
        public IEnumerable<StudentDTO> GetAllStudents()
        {
            var students = _studentRepository.GetAllStudents();
            return students.Select(student => new StudentDTO
            {
                Id = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                Email = student.Email,
                SectorName = _sectorRepository.GetSectorById(student.SectorId)?.Name
            });
        }

        
        public StudentDTO GetStudentById(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null) return null;

            return new StudentDTO
            {
                Id = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                Email = student.Email,
                SectorName = _sectorRepository.GetSectorById(student.SectorId)?.Name
            };
        }

       
        public void AddStudent(StudentDTO studentDto)
        {
            var names = studentDto.FullName.Split(' ');
            var student = new models.Student
            {
                Id = studentDto.Id,
                FirstName = names[0],
                LastName = names.Length > 1 ? names[1] : "",
                Email = studentDto.Email,
                SectorId = _sectorRepository.GetAllSectors().FirstOrDefault(s => s.Name == studentDto.SectorName)?.Id ?? 0
            };
            _studentRepository.AddStudent(student);
        }

        
        public void UpdateStudent(int id, StudentDTO studentDto)
        {
            var existingStudent = _studentRepository.GetStudentById(id);
            if (existingStudent != null)
            {
                var names = studentDto.FullName.Split(' ');
                existingStudent.FirstName = names[0];
                existingStudent.LastName = names.Length > 1 ? names[1] : "";
                existingStudent.Email = studentDto.Email;
                existingStudent.SectorId = _sectorRepository.GetAllSectors().FirstOrDefault(s => s.Name == studentDto.SectorName)?.Id ?? existingStudent.SectorId;
                _studentRepository.UpdateStudent(existingStudent);
            }
        }

        
        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }
    }
}
