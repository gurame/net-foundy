namespace NetFoundy.Concepts;

public abstract class BaseAnimal
{
    public abstract void Speak();
    public virtual void Eat()
    {
        Console.WriteLine("The animal is eating.");
    }
}

public class Dog : BaseAnimal
{
    public override void Speak()
    {
        Console.WriteLine("Woof! Woof!");
    }

    public override void Eat()
    {
        Console.WriteLine("The dog is eating dog food.");
    }
}

public class Cat : BaseAnimal
{
    public override void Speak()
    {
        Console.WriteLine("Meow! Meow!");
    }
    public new static void Eat()
    {
        Console.WriteLine("The cat is eating cat food.");
    }
}

public class Elepahant : BaseAnimal
{
    public override void Speak()
    {
        Console.WriteLine("Trumpet! Trumpet!");
    }
}

public class Polymorphism
{
    public static void Run()
    {
        BaseAnimal myDog = new Dog();
        BaseAnimal myCat = new Cat();
        BaseAnimal myElephant = new Elepahant();

        myDog.Speak(); // Outputs: Woof! Woof!
        myDog.Eat();   // Outputs: The dog is eating dog food.
        Console.WriteLine();
        myCat.Speak(); // Outputs: Meow! Meow!
        myCat.Eat();   // Outputs: The animal is eating. (because Eat is not overridden in Cat)
        Console.WriteLine();
        myElephant.Speak(); // Outputs: Trumpet! Trumpet!
        myElephant.Eat();   // Outputs: The animal is eating.
        Console.WriteLine();
        // Demonstrating static method hiding
        // What does it mean to hide a method?
        // It means that the method is not part of the instance, but rather part of the class itself.
        // Therefore, it can only be called on the class, not on the instance.
        // What is it useful for?
        // It is useful for providing a default implementation of a method that can be called without an instance.
        // However, it is not polymorphic, meaning that it does not participate in method overriding.
        Cat.Eat(); // Outputs: The cat is eating cat food.
    }
}