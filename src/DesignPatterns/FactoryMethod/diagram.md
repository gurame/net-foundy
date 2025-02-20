# Factory Method Pattern - Class Diagram

```mermaid
classDiagram
    direction LR

    class Client {
    }

    class Product {
        +Operation()
    }

    class ConcreteProduct {
        +Operation()
    }

    class Creator {
        +CreateProduct() : Product
    }

    class ConcreteCreator {
        +CreateProduct() : Product
    }

    Client --> Creator : uses
    Product <|.. ConcreteProduct : implements
    Creator <|-- ConcreteCreator : extends
    Creator --> Product : creates
    ConcreteCreator --> ConcreteProduct : creates
