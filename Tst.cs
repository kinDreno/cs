using System;
using System.Collections.Generic;
using System.Linq;

class Tst
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class Course
    {
        public int StudentId { get; set; }
        public string? CourseName { get; set; }
    }

    static void TstMain()
    {
        // List of students
        var students = new List<Student>
        {
            new Student { Id = 1, Name = "John" },
            new Student { Id = 2, Name = "Jane" },
            new Student { Id = 3, Name = "Sam" }
        };

        var courses = new List<Course>
        {
            new Course { StudentId = 1, CourseName = "Math" },
            new Course { StudentId = 2, CourseName = "Science" },
            new Course { StudentId = 1, CourseName = "History" }
        };

        var studentCourses = from student in students
                             join course in courses on student.Id equals course.StudentId
                             select new
                             {
                                 student.Name,
                                 course.CourseName
                             };

        // Output the results
        foreach (var item in studentCourses)
        {
            Console.WriteLine($"{item.Name} is enrolled in {item.CourseName}");
        }
    }
}