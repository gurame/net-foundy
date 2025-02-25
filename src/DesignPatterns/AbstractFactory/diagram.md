# Abstract Factory Pattern - Class Diagram

```mermaid
classDiagram
    direction LR

    class Client {
    }

    class Product1 {
        +Operation()
    }

    class ConcreteProduct1 {
        +Operation()
    }

    class Product2 {
        +Operation()
    }

    class ConcreteProduct2 {
        +Operation()
    }

    class AbstractFactory {
        +CreateProduct1() : Product1
        +CreateProduct2() : Product2
    }

    class ConcreteFactory {
        +CreateProduct1() : Product1
        +CreateProduct2() : Product2
    }

    Client --> AbstractFactory : uses
    Product1 <|.. ConcreteProduct1 : implements
    AbstractFactory <|-- ConcreteFactory : extends
    AbstractFactory --> Product1 : creates
    AbstractFactory --> Product2 : creates
    ConcreteFactory --> ConcreteProduct1 : creates
    ConcreteFactory --> ConcreteProduct2 : creates
    Product2 <|.. ConcreteProduct2 : implements
