using System;
using System.Collections.Generic;

namespace Tree2List
{
    public class Tree2ListConverter<T> where T : class
    {
        private readonly Func<T, T> _leftSelector;
        private readonly Func<T, T> _rightSelector;

        public Tree2ListConverter(Func<T, T> leftSelector, Func<T, T> rightSelector)
        {
            _leftSelector = leftSelector;
            _rightSelector = rightSelector;
        }

        public LinkedList<T> Convert(T tree)
        {
            LinkedList<T> list = new LinkedList<T>();
            var left = _leftSelector(tree);
            var right = _rightSelector(tree);


            if (left == null && right == null)
            {
                list.AddLast(tree);
                return list;
            }

            FindLeaf(left, list);

            FindLeaf(right, list);

            return list;
        }

        private void FindLeaf(T node, LinkedList<T> list)
        {
            if (node == null)
            {
                return;
            }

            foreach (var r in Convert(node))
            {
                list.AddLast(r);
            }
        }
    }
}
