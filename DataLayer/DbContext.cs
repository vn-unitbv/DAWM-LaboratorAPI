using DataLayer.Entities;

namespace DataLayer
{
    public static class DbContext
    {
        public static List<Class> Classes = new List<Class>
        {
            new Class
            {
                Id = 1,
                Name = "10A",
                Students = new List<Student>
                {
                    new Student
                    {
                        Id = 1,
                        FirstName = "Andrei",
                        LastName = "Popescu",
                        ClassId = 1,
                        Grades = new List<Grade>
                        {
                            new Grade
                            {
                                Id = 1,
                                Value = 8.5,
                                Course = CourseType.Chemistry,
                                StudentId = 1
                            },
                            new Grade
                            {
                                Id = 2,
                                Value = 10,
                                Course = CourseType.Math,
                                StudentId = 1
                            },
                               new Grade
                            {
                                Id = 3,
                                Value = 5,
                                Course = CourseType.German,
                                StudentId = 1
                            },
                        }
                    },
                    new Student
                    {
                        Id = 2,
                        FirstName = "Ioana",
                        LastName = "Popa",
                        ClassId = 1,
                        Grades = new List<Grade>
                        {
                            new Grade
                            {
                                Id = 4,
                                Value = 7,
                                Course = CourseType.Biology,
                                StudentId = 2
                            },
                            new Grade
                            {
                                Id = 5,
                                Value = 9,
                                Course = CourseType.English,
                                StudentId = 2
                            },
                               new Grade
                            {
                                Id = 6,
                                Value = 4,
                                Course = CourseType.ComputerScience,
                                   StudentId = 2
                            },
                            new Grade
                            {
                                Id = 7,
                                Value = 10,
                                Course = CourseType.PhisicalEducation,
                                StudentId = 2
                            },
                        }
                    },
                    new Student
                    {
                        Id = 3,
                        FirstName = "Marian",
                        LastName = "Ciobanu",
                        ClassId = 1,
                        Grades = new List<Grade>
                        {
                            new Grade
                            {
                                Id = 8,
                                Value = 10,
                                Course = CourseType.Math,
                                StudentId = 3
                            },
                        }
                    },
                    new Student
                    {
                        Id = 4,
                        FirstName = "Paul",
                        LastName = "Sandu",
                        ClassId = 1,
                        Grades = new List<Grade>()
                    },
                    new Student
                    {
                        Id = 5,
                        FirstName = "Sonia",
                        LastName = "Balan",
                        ClassId = 1,
                        Grades = new List<Grade>()
                    },
                }
            },
            new Class
            {
                Id = 2,
                Name = "10B",
                Students = new List<Student>
                {
                    new Student
                    {
                        Id = 6,
                        FirstName = "Matei",
                        LastName = "Cristea",
                        ClassId = 2,
                        Grades = new List<Grade>()
                    },
                    new Student
                    {
                        Id = 7,
                        FirstName = "Mara",
                        LastName = "Oprea",
                        ClassId = 2,
                        Grades = new List<Grade>()
                    },
                    new Student
                    {
                        Id = 8,
                        FirstName = "Clara",
                        LastName = "Dinu",
                        ClassId = 2,
                        Grades = new List<Grade>()
                    },
                    new Student
                    {
                        Id = 9,
                        FirstName = "Iustin",
                        LastName = "Danu",
                        ClassId = 2,
                        Grades = new List<Grade>()
                    },
                    new Student
                    {
                        Id = 10,
                        FirstName = "Iulian",
                        LastName = "Ciobanu",
                        ClassId = 2,
                        Grades = new List<Grade>()
                    },
                }
            }
        };

        public static List<Student> Students = Classes.SelectMany(x => x.Students).ToList();

        public static List<Grade> Grades = Classes.SelectMany(x => x.Students.SelectMany(x => x.Grades)).ToList();

    }
}
