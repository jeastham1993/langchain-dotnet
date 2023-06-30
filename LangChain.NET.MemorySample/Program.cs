using LangChain.NET.Memory;

var history = new ChatMessageHistory();

history.AddUserMessage("hi!");

history.AddAiMessage("whats up?");

Console.WriteLine(history);