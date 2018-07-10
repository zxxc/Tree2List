using System.Collections.Generic;
using FluentAssertions;
using Tree2List.Models;
using Xunit;

namespace Tree2List.Tests
{
    public class Tree2ListConverterTests : TestsBase
    {
        private Tree2ListConverter<Node> _subject;

        public Tree2ListConverterTests()
        {
            _subject = new Tree2ListConverter<Node>(x => x.Left, x => x.Right);
        }

        [Fact]
        public void Test1()
        {
            var tree = new Node(new Node(null, null), new Node(null, null));
            LinkedList<Node> l = _subject.Convert(tree);
            l.Count.Should().Be(2);
            l.First.Value.Should().Be(tree.Left);
            l.Last.Value.Should().Be(tree.Right);
        }
        [Fact]
        public void Test2()
        {
            var tree = new Node(new Node(new Node(null, null), new Node(null, null)), new Node(new Node(null, null), new Node(null, null)));
            LinkedList<Node> l = _subject.Convert(tree);
            l.Count.Should().Be(4);
            l.First.Value.Should().Be(tree.Left.Left);
            l.First.Next.Value.Should().Be(tree.Left.Right);
            l.First.Next.Next.Value.Should().Be(tree.Right.Left);
            l.First.Next.Next.Next.Value.Should().Be(tree.Right.Right);
        }
    }
}