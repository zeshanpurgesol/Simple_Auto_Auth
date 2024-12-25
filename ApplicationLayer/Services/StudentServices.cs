using ApplicationLayer.IRepo;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{

    public interface IStudentServices
    {
        Task<Student> AddStudent(Student model);
        IQueryable<Student> GetStudents();

        Task<Student> UpdateStudent(Student model);

        Task<Student> DeleteStudent(int id);

        Task<Student?> GetStudent(int id);
    }

    public class StudentServices : IStudentServices
    {
        private IRepo<Student> student_repo;

        public StudentServices(IRepo<Student> student_repo)
        {
            this.student_repo = student_repo;
        }

        public Task<Student> AddStudent(Student model)
        {
            return student_repo.Insert(model);
        }

        public Task<Student> DeleteStudent(int id)
        {
            return student_repo.Delete(id);
        }

        public IQueryable<Student> GetStudents()
        {
            return student_repo.GetAll();
        }

        public Task<Student?> GetStudent(int id)
        {
            return student_repo.Get(id);
        }

        public Task<Student> UpdateStudent(Student model)
        {
            return student_repo.Update(model);
        }
    }
}
