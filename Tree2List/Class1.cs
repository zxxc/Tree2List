using System;
using System.Collections.Generic;

namespace Tree2List
{
    public class Tree2ListConverter<T>
    {
        private readonly Func<T, T> _leftSelector;
        private readonly Func<T, T> _rightSelector;

        public Tree2ListConverter(Func<T,T> leftSelector, Func<T, T> rightSelector)
        {
            _leftSelector = leftSelector;
            _rightSelector = rightSelector;
        }

        public LinkedList<T> Convert(T tree)
        {
            LinkedList<T> list = new LinkedList<T>();

            return list;
        }
    }
}
