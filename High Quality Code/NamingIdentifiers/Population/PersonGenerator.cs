namespace Population
{
    public class PersonGenerator
    {
        public void CreatePerson(int age)
        {
            Person newPerson = new Person();
            newPerson.Age = age;

            if (age % 2 == 0)
            {
                newPerson.Name = "Aleks";
                newPerson.Gender = Gender.male;
            }
            else
            {
                newPerson.Name = "Aleksandra";
                newPerson.Gender = Gender.female;
            }
        }
    }
}