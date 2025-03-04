# Builder Pattern - Class Diagram (No Director)

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

    Client --> Builder : uses
    Builder <|-- ConcreteBuilder : extends
    Builder --> Product : builds
