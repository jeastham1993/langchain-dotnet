using LangChain.NET.Chat;
using LangChain.NET.Memory;

namespace LangChain.NET.UnitTest;

public class MemoryTests
{
    [Fact]
    public async Task TestInMemoryHistory_WhenAddingMessages_ShouldStoreInMememory()
    {
        ChatMessageHistory inMemoryHistory = CreateInMemoryHistoryExample();

        inMemoryHistory.Messages.Should().HaveCount(2);

        inMemoryHistory.Messages.FirstOrDefault(x => x.Text == "hi!").Should().BeOfType<HumanChatMessage>();
        inMemoryHistory.Messages.FirstOrDefault(x => x.Text == "whats up?").Should().BeOfType<AiChatMessage>();
    }

    [Fact]
    public  async Task TestInMemoryHistory_WhenCleanMethodIsCalled_ShouldCleanHistory()
    {
        ChatMessageHistory inMemoryHistory = CreateInMemoryHistoryExample();

        inMemoryHistory.Clear();

        inMemoryHistory.Messages.Should().HaveCount(0);
    }

    private static ChatMessageHistory CreateInMemoryHistoryExample()
    {
        var inMemoryHistory = new ChatMessageHistory();

        inMemoryHistory.AddUserMessage("hi!");

        inMemoryHistory.AddAiMessage("whats up?");
        return inMemoryHistory;
    }
}

