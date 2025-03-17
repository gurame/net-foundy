# Decorator Pattern - Class Diagram

```mermaid
classDiagram
    direction LR

    class Client {
    }

    class Component {
        +Operation() : void
    }

    class ConcreteComponent {
        +Operation() : void
    }

    class Decorator {
        -component: Component
        +Operation() : void
    }

    class ConcreteDecorator1 {
        +Operation() : void
    }

    class ConcreteDecorator2 {
        +Operation() : void
    }

    Client --> Component : uses
    ConcreteComponent ..|> Component : implements
    Decorator ..|>  Component : implements
    Decorator *--  Component : has   
    ConcreteDecorator1 --|> Decorator : extends
    ConcreteDecorator2 --|> Decorator : extends
