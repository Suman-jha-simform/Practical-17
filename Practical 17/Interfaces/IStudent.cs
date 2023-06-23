using Practical_17.Models;

namespace Practical_17.Interfaces
{
    public interface IStudent
    {
        List<Student> GetAllStudent();
        Student GetStudent(int id);
        bool AddStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(int id);
    }
}
