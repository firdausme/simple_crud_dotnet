using MySql.Data.MySqlClient;
using SimpleCrud.database;
using SimpleCrud.Extensions;
using SimpleCrud.Models;

namespace SimpleCrud.Repositories;

public class StudentRepository(MySqlDb mySqlDb) : IStudentRepository
{
    private const string GetAllQuery = "SELECT * FROM `student`";
    private const string GetByIdQuery = "SELECT * FROM `student` WHERE `id` = @id";
    private const string AddQuery = "INSERT INTO student (name, email, date_of_birth) VALUES (@name, @email, @date_of_birth)";
    private const string UpdateQuery = "UPDATE `student` SET `name` = @name WHERE `id` = @id";
    private const string DeleteQuery = "DELETE FROM `student` WHERE `id` = @id";

    public List<Student> GetAll()
    {
        using var cmd = new MySqlCommand(GetAllQuery, mySqlDb.Connection);
        using var reader = cmd.ExecuteReader();

        return reader.ToStudent().ToList();
    }

    public Student? GetById(int id)
    {
        using var cmd = new MySqlCommand(GetByIdQuery, mySqlDb.Connection);
        cmd.Parameters.AddWithValue("@id", id);
        using var reader = cmd.ExecuteReader();

        return reader.ToStudent().SingleOrDefault();
    }

    public void Add(Student student)
    {
        using var cmd = new MySqlCommand(AddQuery, mySqlDb.Connection);
        cmd.Parameters.AddWithValue("@name", student.Name);
        cmd.Parameters.AddWithValue("@email", student.Email);
        cmd.Parameters.AddWithValue("@date_of_birth", student.DateOfBirth);
        using var reader = cmd.ExecuteReader();
    }

    public void Update(Student student)
    {
        using var cmd = new MySqlCommand(UpdateQuery, mySqlDb.Connection);
        cmd.Parameters.AddWithValue("@id", student.Id);
        cmd.Parameters.AddWithValue("@name", student.Name);
        using var reader = cmd.ExecuteReader();
    }

    public void Delete(int id)
    {
        using var cmd = new MySqlCommand(DeleteQuery, mySqlDb.Connection);
        cmd.Parameters.AddWithValue("@id", id);
        using var reader = cmd.ExecuteReader();
    }
}