# Questions and Answers for real interviews

This document contains a collection of questions and answers that are commonly asked in real interviews. It is designed to help candidates prepare for interviews by providing insights into the types of questions they may encounter and effective ways to respond.

## Table of Contents

1. [Fundamentals Questions] (#fundamentals)

## Fundamentals Questions

### 1. What's the fundamental difference between .dll and .exe files in the context of C# projects?

**Answer:** In C# projects, .exe files are executable files that contain the entry point of the application, meaning they can be run directly by the operating system. On the other hand, .dll (Dynamic Link Library) files are not executable on their own; instead, they contain reusable code and resources that can be used by other applications or libraries. In essence, .exe files are for standalone applications, while .dll files are for shared components.

#### Follow-up Question: But there is no exe in .NET Core? How does it work?

**Answer:** In .NET Core, while the primary output of a project is typically a .dll file, you can still create an executable by specifying the runtime identifier (RID) during the publish process. When you publish a .NET Core application with a specific RID, it generates a self-contained executable that includes the .NET runtime along with your application. This allows the application to run independently on the target platform without requiring a separate .NET installation. So, while the main build output is a .dll, you can still produce an executable for deployment purposes.

#### Follow-up Question: So, how does the application start if there is no exe? Is it contained a runtime inside the dll?

**Answer:** In .NET Core, the application starts from the .dll file by using the `dotnet` command-line tool. When you run a .NET Core application, you typically execute it using the command `dotnet yourapp.dll`. The `dotnet` tool acts as a host that loads the .NET runtime and executes the code contained in the .dll file.

The .dll file itself does not contain the runtime; instead, it contains the compiled code of your application. The .NET runtime is a separate component that is either installed on the system or included in a self-contained deployment. When you run the `dotnet` command, it locates the appropriate runtime and uses it to execute the code in the .dll file, starting from the `Main` method defined in your application.

### 2. What is the difference between processes and threads in C#?

**Answer:** In C#, a process is an instance of a running application that has its own memory space and system resources. Each process operates independently and can contain multiple threads. A thread, on the other hand, is the smallest unit of execution within a process. Threads share the same memory space and resources of the parent process, allowing for concurrent execution of code within the same application, but each one has its own stack. In summary, processes are isolated from each other, while threads within a process can communicate and share data more easily.
