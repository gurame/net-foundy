# Composite Pattern - Class Diagram

```mermaid
classDiagram
    direction LR

    class Client {
    }

    class Component {
        +Operation() : void
        +Add(Component) : void
        +Remove(Component) : void
        +GetChild() : Component
    }

    class Leaf {
        +Operation() : void
    }

    class Composite {
        -children: List<Component>
        +Operation() : void
        +Add(Component) : void
        +Remove(Component) : void
        +GetChild() : Component
    }

    Client --> Component : uses
    Leaf --|> Component : extends
    Composite --|> Component : extends    
    Composite *-- Component : has
