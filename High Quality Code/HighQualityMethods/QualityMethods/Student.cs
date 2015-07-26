namespace QualityMethods
{
    using System;

    internal class Student
    {
        private string firstName;
        private string lastName;
       
        public Student(string firstName, string lastName, DateTime dateOfBirth, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.OtherInfo = otherInfo;
        }

        public string FirstName 
        { 
            get
            {
                return this.firstName;
            }

            set
            {
                this.ValidateNameLength(value);
                this.firstName = value;
            }
        }

        public string LastName 
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.ValidateNameLength(value);
                this.lastName = value;
            }
        }

        public DateTime DateOfBirth { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlder(Student otherStudent)
        {
            bool isOlder = this.DateOfBirth < otherStudent.DateOfBirth;
            return isOlder;
        }

        private void ValidateNameLength(string name)
        {
            if (name.Length < 3 || name.Length > 20)
            {
                throw new ArgumentOutOfRangeException("Invalid length of name.");
            }
        }
    }
}