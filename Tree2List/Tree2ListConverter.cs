using System;
using System.Collections.Generic;
using System.Linq;

namespace Tree2List
{
    public class Tree2ListConverter<T>
    {
        private readonly Func<T, bool> _isLeaf;
        private readonly Func<T, T>[] _leafSelector;

        public Tree2ListConverter(Func<T, bool> isLeaf, params Func<T, T>[] leafSelector)
        {
            _isLeaf = isLeaf;
            _leafSelector = leafSelector;
        }

        public LinkedList<T> Convert(T tree) => new LinkedList<T>(FindLeafs(tree));

        private IEnumerable<T> FindLeafs(T tree)
        {
            if (tree == null)
            {
                return Array.Empty<T>();
            }
            return _leafSelector
                .Select(propertySelector => propertySelector(tree))
                .SelectMany(FindLeafs)
                .Where(_isLeaf)
                .DefaultIfEmpty(tree);
        }
    }
}
