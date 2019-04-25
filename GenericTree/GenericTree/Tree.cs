using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTree
{
    public class Tree<T> : ICollection<T>
    {
        private T _value;
        private Tree<T> _parent;
        private List<Tree<T>> _children;

        public Tree(T value)
        {
            _value = value;
            _parent = null;
            _children = new List<Tree<T>>();
        }

        private Tree(T value, Tree<T> parent)
        {
            _value = value;
            _parent = parent;
            _children = new List<Tree<T>>();
        }

        public int Count
        {
            get { return _children.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
        public void Add(T item)
        {
            _children.Add(new Tree<T>(item, this));
        }

        public void Add(Tree<T> item)
        {
            item._parent = this;
            _children.Add(item);
        }

        public void Clear()
        {
            _children.Clear();
        }

        public bool Contains(T item)
        {
            return _children.Any(a => a._value.Equals(item)) || _children.Any(a => a.Contains(item));
        }
        public bool Contains(Func<T, bool> predicate)
        {
            return _children.Any(a => predicate(a._value)) || _children.Any(a => a.Contains(predicate));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _children.Select(s=>s._value).ToArray().CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _children.Select(s=>s._value).GetEnumerator();
        }

        public bool Remove(T item)
        {
            var tree = _children.FirstOrDefault(a => a._value.Equals(item));
            if (tree == null)
                return false;
            return _children.Remove(tree);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int i]
        {
            get { return _children[i]._value; }
        }

        public void Draw()
        {
            Console.WriteLine(_value.ToString());
            foreach(var item in GetItemsDepthFirst().Skip(1))
            {
                for (int i = 1; i < item.Level; i++)
                {
                    Console.Write("|  ");
                }
                Console.WriteLine("|--" + item.Value.ToString());
            }
        }

        public IEnumerable<ItemWithLevel<T>> GetItemsDepthFirst()
        {
            return GetItemsDepthFirst(0);
        }

        public IEnumerable<ItemWithLevel<T>> GetItemsDepthFirst(int level)
        {
            yield return new ItemWithLevel<T>(_value, level);
            foreach (var item in _children)
            {
                foreach (var depth in item.GetItemsDepthFirst(level + 1))
                {
                    yield return depth;
                }
            }
        }

        /*public IEnumerable<T> GetItemsBreadthFirst()
        {
            yield return _value;
            foreach (var item in _children)
            {
                foreach (var depth in item.GetItemsBreadthFirst())
                {
                    yield return depth;
                }
            }
        }*/
    }

    public class ItemWithLevel<T>
    {
        private T _value;
        private int _level;
        public T Value { get { return _value; } }
        public int Level { get { return _level; } }
        public ItemWithLevel(T value, int level)
        {
            _value = value;
            _level = level;
        }
    }
}
