using System.Collections.Generic;
using System.Linq;
using UsbChecker; // referencing the namespace of the extension methods

namespace UsbChecker.Tests;

public class FlattenTests
{
    private class TestNode
    {
        public int Value { get; }
        public List<TestNode> Children { get; }

        public TestNode(int value, params TestNode[] children)
        {
            Value = value;
            Children = children?.ToList() ?? new List<TestNode>();
        }
    }

    [Fact]
    public void Flatten_ReturnsNodesInPreorder()
    {
        var tree = new TestNode(1,
            new TestNode(2),
            new TestNode(3,
                new TestNode(4),
                new TestNode(5)));

        var result = tree.Flatten(n => n.Children).Select(n => n.Value).ToList();

        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, result);
    }
}
