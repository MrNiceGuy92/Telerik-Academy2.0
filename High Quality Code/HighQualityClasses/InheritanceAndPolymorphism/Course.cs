namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Course
    {
        private string courseName;
        private string teacherName;
        private List<string> students;

        public Course(string courseName)
        {
            this.CourseName = courseName;
            this.Students = new List<string>();            
        }

        public Course(string courseName, string teacherName)
            : this(courseName)
        {
            this.TeacherName = teacherName;            
        }

        public Course(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName)
        {
            if (students != null)
            {
                foreach (var student in students)
                {
                    this.Students.Add(student);
                }
            }
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null.");
                }

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Teacher name cannot be null.");
                }
            }
        }

        public IList<string> Students { get; private set; }

        public void AddStudents(params string[] students)
        {
            foreach (var student in students)
            {
                if (string.IsNullOrWhiteSpace(student))
                {
                    throw new ArgumentException("Student can't be null or empty.");
                }

                this.Students.Add(student);
            }
        }

        public string GetStudentsAsString()
        {
            string students = string.Format("{{ {0} }}", string.Join(", ", this.Students));
            return students;
        }

        public override string ToString()
        {
            string courseType = this.GetType().Name;
            string courseName = string.Format("Name = {0}", this.courseName);
            string teacherName = string.Format("Teacher = {0}", this.TeacherName);
            string students = string.Empty;

            if (this.Students.Count > 0)
            {
                students = string.Format("Students = {0}", this.GetStudentsAsString());
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine(courseType);
            result.AppendLine(courseName);
            result.AppendLine(teacherName);
            result.AppendLine(students);

            return result.ToString().Trim();
        }
    }
}