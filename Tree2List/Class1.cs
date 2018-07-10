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

            foreach (var l in Convert(left))
            {
                list.AddLast(l);
            }

            foreach (var r in Convert(right))
            {
                list.AddLast(r);
            }

            //list.AddLast(left);
            //list.AddLast(right);
            
            return list;
        }

        private T Collect(T node)
        {
            var left = _leftSelector(node);
            var right = _rightSelector(node);


            if (left == null && right == null)
            {
                return node;
            }

            return Collect(left);
        }

        class N
        {

        }
    }
}
