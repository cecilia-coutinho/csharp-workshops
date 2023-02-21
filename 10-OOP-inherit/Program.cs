namespace OOPInherit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Dog");
            dog.AnimalIntroduction();

            Cat cat = new Cat("Cat");
            cat.AnimalIntroduction();

            Pig pig = new Pig("Pig");
            pig.AnimalIntroduction();

            dog.FavoriteDogType("Bulldog");

            MyCat myCat = new MyCat("Tata", "Persian");
            myCat.MyCatIntroduction();
        }
    }
}