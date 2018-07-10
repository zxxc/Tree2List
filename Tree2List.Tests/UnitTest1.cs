using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AutoFixture;
using AutoFixture.Dsl;
using AutoFixture.Kernel;
using FluentAssertions;
using Tree2List.Models;
using Xunit;

namespace Tree2List.Tests
{
    class NodeBuilder : ISpecimenBuilder
    {
        private readonly int _maxDepth;
        private int _depth;

        public NodeBuilder(int maxDepth)
        {
            _maxDepth = maxDepth;
            _depth = 0;
        }
        public object Create(object request, ISpecimenContext context)
        {
            if (request.ToString().Contains("Node"))
            {
                if (_depth >= _maxDepth)
                {
                    return null;
                }
                return context.Create<Node>();
            }
            return new NoSpecimen();
        }
    }
    public class TestsBase
    {
        protected Fixture Fixture;

        public TestsBase()
        {
            Fixture = new Fixture();
        }

    }
    public class UnitTest1 : TestsBase
    {
        private Tree2ListConverter<Node> _subject;

        public UnitTest1()
        {
            _subject = new Tree2ListConverter<Node>(x => x.Left, x => x.Right);
        }

        [Fact]
        public void Test1()
        {
            var tree = new Node(new Node(null, null), new Node(null, null));
            LinkedList<Node> l = _subject.Convert(tree);
            l.Count.Should().Be(2);
            l.First.Should().Be(tree.Left);
            l.Last.Should().Be(tree.Right);
        }
    }
}
