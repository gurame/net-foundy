# Prototype Pattern - Class Diagram

```mermaid
classDiagram
    direction LR

    class Client {
    }

    class Prototype {
        +Clone()
    }

    class ConcretePrototype {
        +Clone()
    }

    Client --> Prototype : uses
    Prototype <|.. ConcretePrototype : implements
