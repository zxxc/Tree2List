using System;
using System.Security.Cryptography.X509Certificates;
using AutoFixture;
using AutoFixture.Dsl;
using AutoFixture.Kernel;
using Tree2List.Models;

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
}
