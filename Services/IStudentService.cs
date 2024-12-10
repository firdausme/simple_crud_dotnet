using SimpleCrud.Models;

namespace SimpleCrud.Services;

public interface IStudentService
{
    List<Student> GetAll();
    Student? GetById(int id);
    void Add(Student student);
    void Update(Student student);
    void Delete(int id);
}