using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Practical_17.Interfaces;
using Practical_17.Models;

namespace Practical_17.Repo
{
    public class StudentRepo : IStudent
    {
        private readonly ApplicationContext _context;

        public StudentRepo(ApplicationContext context)
        {
            _context = context;
        }
        public bool AddStudent(Student student)
        {
            var studentInDb = _context.Students.Where(x => x.Id == student.Id).FirstOrDefault();
            if (studentInDb == null)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteStudent(int id)
        {
            var studentInDb = _context.Students.Where(x => x.Id == id).FirstOrDefault();
            if (studentInDb != null)
            {
                _context.Students.Remove(studentInDb);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Student> GetAllStudent()
        {
            var studentList = _context.Students.ToList();
            return studentList;
        }

        public Student GetStudent(int id)
        {
            var student = _context.Students.Where(x => x.Id == id).FirstOrDefault();
            return student;
        }

        public bool UpdateStudent(Student student)
        {
            var studentInDb = GetStudent(student.Id);
            if(studentInDb != null)
            {
                studentInDb.Department = student.Department;
                studentInDb.Name = student.Name;
                studentInDb.Grades = student.Grades;

                _context.Entry(studentInDb).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
