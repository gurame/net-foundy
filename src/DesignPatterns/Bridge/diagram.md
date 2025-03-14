# Bridge Pattern - Class Diagram

```mermaid
classDiagram
    direction LR

    class Client {
    }

    class Abstraction {
        -impl: Implementor
        +Foo() : void
    }

    class RefinedAbstraction {
        +Foo() : void
    }

    class Implementor {
        +Operation() : void
    }

    class ConcreteImplementor {
        +Operation() : void
    }

    Client --> Abstraction : uses
    Abstraction *-- Implementor : has a
    RefinedAbstraction --|> Abstraction : extends
    Implementor <|.. ConcreteImplementor : implements
