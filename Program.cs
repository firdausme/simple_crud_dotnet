// See https://aka.ms/new-console-template for more information

using SimpleCrud.database;
using SimpleCrud.Models;
using SimpleCrud.Repositories;
using SimpleCrud.Services;

const string connectionString = "Server=localhost;Database=belajar_dotnet;Uid=root;Pwd=;";

var mysqldb = new MySqlDb(connectionString);
var stdRepository = new StudentRepository(mysqldb);
var stdService = new StudentService(stdRepository);
GetSeparator();

Print(stdService.GetAll());

Console.WriteLine("GetById : ");
var student = stdService.GetById(1);
Console.WriteLine(student);
GetSeparator();

Console.WriteLine("Add : ");
var newStudent = new Student()
{
    Name = "John Doe",
    Email = "john.doe@gmail.com",
    DateOfBirth = new DateTime(1980, 01, 01),
};
Console.WriteLine(newStudent);
stdService.Add(newStudent);
GetSeparator();

Print(stdService.GetAll());

Console.WriteLine("Update : ");
var stdUpdate = stdService.GetById(1);
if (stdUpdate != null)
{
    stdUpdate.Name = "Jamal";
    stdService.Update(stdUpdate);
}
GetSeparator();

Print(stdService.GetAll());

stdService.Delete(2);

Print(stdService.GetAll());

void Print(List<Student> students)
{
    Console.WriteLine("GetAll : ");
    students.ForEach(Console.WriteLine);
    GetSeparator();
}

void GetSeparator() => Console.WriteLine("==================================================");