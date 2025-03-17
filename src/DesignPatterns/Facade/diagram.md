# Decorator Pattern - Class Diagram

```mermaid
classDiagram
    direction LR

    class Client {
    }

    class Facade {
        +Operation1() : void
    }

    class Class1 {
        +Operation2() : void
    }

    class Class2 {
        +Operation3() : void
    }

    class Class3 {
        +Operation4() : void
    }

    class Class4 {
        +Operation5() : void
    }


    Client --> Facade : uses
    Facade --> Class1 : uses
    Facade --> Class2 : uses
    Facade --> Class3 : uses
    Facade --> Class4 : uses
