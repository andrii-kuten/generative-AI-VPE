using GenerativeAI;
using Xunit;

namespace StudentTestProject
{
    public class ConvertStudentsUnitTests
    {
        private List<Student> ArrayOfStudents { get; set; }

        private List<Student> ArrayOfConvertedStudents { get; set; }

        public ConvertStudentsUnitTests() 
        {
            ArrayOfStudents = new List<Student>()
            {
                new Student()
                {
                    Name = "S1",
                    Age = 20,
                    Grade = 91
                },
                new Student()
                {
                    Name = "S2",
                    Age = 19,
                    Grade = 95
                },
                new Student()
                {
                    Name = "S3",
                    Age = 17,
                    Grade = 100
                },

                new Student() 
                {
                    Name = "S4",
                    Age = 21,
                    Grade = 93
                },
                new Student()
                {
                    Name = "S5",
                    Age = 25,
                    Grade = 95
                },
                new Student()
                {
                    Name = "S6",
                    Age = 26,
                    Grade = 99
                },

                new Student()
                {
                    Name = "S7",
                    Age = 21,
                    Grade = 71
                },
                new Student()
                {
                    Name = "S8",
                    Age = 25,
                    Grade = 75
                },
                new Student()
                {
                    Name = "S9",
                    Age = 26,
                    Grade = 90
                },
                
                new Student()
                {
                    Name = "S10",
                    Age = 20,
                    Grade = 69
                },
                new Student()
                {
                    Name = "S11",
                    Age = 22,
                    Grade = 70
                },
                new Student()
                {
                    Name = "S12",
                    Age = 21,
                    Grade = 65
                },
            };

            ArrayOfConvertedStudents = new StudentConverter()
                .ConvertStudents(ArrayOfStudents); 
        }

        [Fact]
        public void ExceptionalYoungHighAciever()
        {
            var data = ArrayOfConvertedStudents.Where(s => s.Exceptional);
            var names = new[] { "S1", "S2", "S3" };

            Assert.Equal(names, data.Select(s => s.Name));
        }

        [Fact]
        public void HighAchiever()
        {
            var data = ArrayOfConvertedStudents.Where(s => s.HonorRoll);
            var names = new[] { "S4", "S5", "S6" };

            Assert.Equal(names, data.Select(s => s.Name));
        }

        [Fact]
        public void PassedStudents()
        {
            var data = ArrayOfConvertedStudents.Where(s => s.Passed);
            var names = new[] { "S7", "S8", "S9"};

            Assert.Equal(names, data.Select(s => s.Name));
        }

        [Fact]
        public void FailedStudents()
        {
            var data = ArrayOfConvertedStudents.Where(s => !s.Passed);
            var names = new[] { "S1", "S2", "S3", "S4", "S5", "S6", "S10", "S11", "S12" };

            Assert.Equal(names, data.Select(s => s.Name));
        }

        [Fact]
        public void EmptyArray()
        {
            var data = new StudentConverter()
                .ConvertStudents(new List<Student>());

            Assert.Empty(data);
        }

        [Fact]
        public void NotAnArray()
        {
            Assert.Throws<ArgumentNullException>(() 
                => new StudentConverter().ConvertStudents(null) );
        }
    }
}