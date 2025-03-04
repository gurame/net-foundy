# Adpater Pattern - Class Diagram

```mermaid
classDiagram
    direction LR

    class Client{

    }

    class Adaptee{
        +SpecificRequest() : void
    }

    class ITarget{
        +Request() : void
    }

    class Adapter{
        +Request() : void
    }

    Client --> ITarget : uses
    ITarget <|.. Adapter : implements
    Adapter --> Adaptee : uses
