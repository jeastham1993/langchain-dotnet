using LangChain.NET.Abstractions.Chains.Base;
using LangChain.NET.Abstractions.Schema;
using LangChain.NET.Chains.Sequentials;
using LangChain.NET.Schema;

namespace LangChain.NET.UnitTest.Chains.Sequentials;

public class SequentialChainTests
{
    [Fact]
    public async Task Sequential_Usage_Single_Inputs()
    {
        // Arrange
        var chain1 = CreateFakeChainMock(new[] {"foo"}, new []{"bar"}).Object;
        var chain2 = CreateFakeChainMock(new[] {"bar"}, new []{"baz"}).Object;
        var chain = new SequentialChain(new SequentialChainInput(new[] {chain1, chain2}, new []{"foo"}));

        // Act
        var outputs = await chain.CallAsync(new ChainValues("foo", "123"));
        
        // Assert
        outputs.Value.Count.Should().Be(1);
        outputs.Value.First().Key.Should().Be("baz");
        outputs.Value.First().Value.Should().Be("123foofoo");
    }
    
    [Fact]
    public async Task Sequential_Usage_Single_Inputs_With_ReturnAll()
    {
        // Arrange
        var chain1 = CreateFakeChainMock(new[] {"foo"}, new []{"bar"}).Object;
        var chain2 = CreateFakeChainMock(new[] {"bar"}, new []{"baz"}).Object;
        var chain = new SequentialChain(new SequentialChainInput(new[] {chain1, chain2}, new []{"foo"}, returnAll: true));

        // Act
        var outputs = await chain.CallAsync(new ChainValues("foo", "123"));
        
        // Assert
        outputs.Value.Count.Should().Be(2);
        outputs.Value.ContainsKey("bar").Should().BeTrue();
        outputs.Value.ContainsKey("baz").Should().BeTrue();
        outputs.Value["bar"].Should().Be("123foo");
        outputs.Value["baz"].Should().Be("123foofoo");
    }

    private Mock<IChain> CreateFakeChainMock(string[] inputVariables, string[] outputVariables)
    {
        var fakeChainMock = new Mock<IChain>();
        
        fakeChainMock.Setup(_ => _.InputKeys).Returns(inputVariables);
        fakeChainMock.Setup(_ => _.OutputKeys).Returns(outputVariables);
        fakeChainMock.Setup(x => x.CallAsync(It.IsAny<IChainValues>()))
            .Returns<IChainValues>(async (chainValues) =>
            {
                var output = new ChainValues();

                foreach (var outputVariable in outputVariables)
                {
                    var text = string.Join("", inputVariables.Select(_ => chainValues.Value[_]).Select(_ => _ as string));
                    var outputValue = $"{text}foo";
                    output.Value.Add(outputVariable, outputValue);
                }

                return output;
            });

        return fakeChainMock;
    }
}