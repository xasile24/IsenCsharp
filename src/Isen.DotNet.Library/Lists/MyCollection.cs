using System;
using System.Collections;
using System.Collections.Generic;

namespace Isen.DotNet.Library.Lists
{
    public class MyCollection<T> : IList<T>
    {
        private T[] _values;

        public MyCollection()
        {
            _values = new T[0];
        }


        /// <summary>
        ///Taille de la liste
        ///</summary>
        public int Count => _values.Length;
        public T[] Values => _values;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get { return _values[index]; }
            set { _values[index] = value; }
        }


        /// <summary>
        ///Ajoute un élément à la fin de la liste
        ///</summary>
        ///<param name="item"></param>
        public void Add(T item)
        {
            //Nouveau tableau
            var temp = new T[Count + 1];
            //Copier les elements du tableau initial
            for(var i = 0; i< Count; i++)
            {
                temp[i] = _values[i];
            }
            //Ajouter le nouvel element
            temp[Count] = item;
            //Echanger les tableaux
            _values = temp;
        }

        public void RemoveAt(int index)
        {
            if( Values?.Length == 0 
            || index > Count 
            || index < 0 )
                throw new IndexOutOfRangeException();

            //nouveau tableau
            var tmp = new T[Count - 1];

            //copier les elements du tableau initial
            for (var i = 0 ; i < tmp.Length ; i++)
            {
                if (i < index) tmp[i] = _values[i];
                else if (i >= index) tmp[i] = Values[i+1];
            }
            //echanger les tableaux
            _values = tmp;
        }

        public int IndexOf(T item)
        {
            var index = -1;
            for ( var i = 0 ; i < Count ; i++)
            {
                if (this[i].Equals(item)) {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item) =>
            IndexOf(item) >= 0;

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index < 0) return false;

            RemoveAt(index);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}