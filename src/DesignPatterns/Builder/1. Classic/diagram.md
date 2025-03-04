# Builder Pattern - Class Diagram (Classic)

```mermaid
classDiagram
    direction LR

    class Client {
    }

    class Product {
        +SetName() : void
        +SetDescription() : void
    }

    class Builder {
        +BuildName() : void
        +BuildDescription() : void
        +Build(): Product
    }

    class ConcreteBuilder {
        +BuildName() : void
        +BuildDescription() : void
        +Build(): Product
    }

    class Director {
        +ConstructProduct() : void
    }

    Client --> Director : uses
    Client --> Builder : uses
    Director *-- Builder
    Builder <|-- ConcreteBuilder : extends
    Builder --> Product : builds
