# Interfaces

**PipeInterface**

```csharp
PipeInterface Pipe { get; } = new()
  {
  PipeName = "",
  Timeout = 0,
}
```
```csharp
Pipe.SendData(TextEditor.Text, null, false);
Pipe.SendData(null, new Uri("https://pornhub.com"), true);
```
