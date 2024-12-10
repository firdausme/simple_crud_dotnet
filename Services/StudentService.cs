using SimpleCrud.Models;
using SimpleCrud.Repositories;

namespace SimpleCrud.Services;

public class StudentService(StudentRepository repository) : IStudentService
{
    public List<Student> GetAll()
    {
        return repository.GetAll();
    }

    public Student? GetById(int id)
    {
        return repository.GetById(id);
    }

    public void Add(Student student)
    {
        repository.Add(student);
    }

    public void Update(Student student)
    {
        repository.Update(student);
    }

    public void Delete(int id)
    {
        repository.Delete(id);
    }
}