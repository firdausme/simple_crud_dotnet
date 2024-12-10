using System.Data;
using SimpleCrud.Models;

namespace SimpleCrud.Extensions;

public static class StudentReaderExtensions
{
    public static IEnumerable<Student> ToStudent(this IDataReader reader)
    {
        while (reader.Read())
        {
            yield return new Student()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2),
                DateOfBirth = reader.GetDateTime(3)
            };
        }
    }
}