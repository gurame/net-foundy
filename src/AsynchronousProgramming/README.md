# Asynchronous Programming in C#
All about asynchronous programming in C# using async and await keywords.

## Libraries
AsyncAwaitBestPractices (NuGet)

## ConfigureAwait
- false: Avoids deadlocks in UI applications by not capturing the current synchronization context.
- true: Captures the current synchronization context, useful for UI updates.
- ConfigureAwaitOptions
  - None: Default behavior. (equivalent to false)
  - ContinueOnCapturedContext: Captures the current context. (equivalent to true)
  - ForceYielding: Forces the continuation to yield back to the caller. (equivalent to false with additional yielding)
  - SuppressFlow: Suppresses the flow of the execution context. (advanced scenarios)
