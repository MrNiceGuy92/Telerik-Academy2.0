namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class CoursesExamples
    {
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("HQC", "Marin Jelev", new List<string>() { "Peter", "Maria" }, "Enterprise");
            Console.WriteLine(localCourse);
            localCourse.Students.Add("Marin");
            localCourse.Students.Add("Aleks");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse("DSA", "Aleks Sklqrov", new List<string>() { "Vasil", "Dimitar", "Sophia" }, "Sofia");
            Console.WriteLine(offsiteCourse);
        }
    }
}
