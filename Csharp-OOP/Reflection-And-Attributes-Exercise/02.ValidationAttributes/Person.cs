namespace ValidationAttributes
{
    internal class Person
    {
        public Person(string fullName, int age)
        {
            this.Age = age;
            this.FullName = fullName;
        }

        [MyRange(12, 90)]
        public int Age { get; set; }
        [MyRequiredAttribute]
        public string FullName { get; set; }
    }
}