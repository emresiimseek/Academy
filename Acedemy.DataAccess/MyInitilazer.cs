using Academy.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedemy.DataAccess
{
    public class MyInitilazer : CreateDatabaseIfNotExists<AcedemyContext>
    {
        protected override void Seed(AcedemyContext context)
        {

            for (int i = 0; i < 10; i++)
            {
                Course course = new Course();
                course.CreatedOn = FakeData.DateTimeData.GetDatetime();
                course.ModifiedOn = FakeData.DateTimeData.GetDatetime();
                course.Title = FakeData.NameData.GetSurname();
                course.Description = FakeData.TextData.GetSentence();
                course.TotalTime = FakeData.NumberData.GetNumber();

                List<Student> students = new List<Student>();
                for (int j = 0; j < 25; j++)
                {
                    Random random = new Random();
                    Student student = new Student();
                    student.FirstName = FakeData.NameData.GetFirstName();
                    student.LastName = FakeData.NameData.GetSurname();
                    student.Gender = 'm';
                    student.Birthdate = FakeData.DateTimeData.GetDatetime();
                    student.CreatedOn = FakeData.DateTimeData.GetDatetime();
                    student.ModifiedOn = FakeData.DateTimeData.GetDatetime();
                    student.Absence = random.Next(0, 30);
                    student.EnrollmentDate = FakeData.DateTimeData.GetDatetime();
                    students.Add(student);

                }
                course.Students = students;

                Instructor ınstructor = new Instructor();
                ınstructor.FirstName = FakeData.NameData.GetFirstName();
                ınstructor.LastName = FakeData.NameData.GetSurname();
                ınstructor.Gender = 'f';
                ınstructor.Birthdate = FakeData.DateTimeData.GetDatetime();
                ınstructor.CreatedOn = FakeData.DateTimeData.GetDatetime();
                ınstructor.ModifiedOn = FakeData.DateTimeData.GetDatetime();
                ınstructor.Biography = FakeData.TextData.GetSentence();
                ınstructor.HireDate = FakeData.DateTimeData.GetDatetime();
                ınstructor.Password = "dw0RNMm7fVs=";
                ınstructor.UserName = FakeData.NameData.GetFirstName();

                course.Instructors = new List<Instructor> { ınstructor };

                context.Courses.Add(course);
                context.SaveChanges();







            }
        }
    }
}
