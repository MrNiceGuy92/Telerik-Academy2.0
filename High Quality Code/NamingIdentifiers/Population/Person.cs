namespace Population
{
    using System;

    internal class Person
    {
        private string name;
        private int age;

        public Gender Gender { get; set; }

        public string Name 
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length < 3 || value.Length > 33)
                {
                    throw new ArgumentOutOfRangeException("Length of name must be between 3 and 30 characters.");
                }

                this.name = value;
            }
        }

        public int Age 
        { 
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Invalid age.");
                }

                this.age = value;
            }
        }
    }
}