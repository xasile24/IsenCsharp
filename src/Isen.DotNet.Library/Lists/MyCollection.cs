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
        protected T[] Values => _values;

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
            if( index > Count
            || index < 0 )
                throw new ArgumentOutOfRangeException();

            var tmp = new T[Count + 1];

            for(var i = 0 ; i < Count+1 ; i++) 
            {
                if(i == index) tmp[i] = item;
                else if(i > index) tmp[i] = Values[i-1];
                else if(i < index) tmp[i] = _values[i];
            }

            _values = tmp;
        }

        public void Clear()
        {
            _values = new T[0];
        }

        public bool Contains(T item) =>
            IndexOf(item) >= 0;

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array == null) throw new ArgumentNullException();
            if(arrayIndex < 0) throw new ArgumentOutOfRangeException();
            if(Count + arrayIndex > array.Length) throw new ArgumentException();

            for(var i = 0 ; i < Count; i++)
            {
                array[arrayIndex + i] = this[i];
            }
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index < 0) return false;

            RemoveAt(index);
            return true;
        }

        public IEnumerator<T> GetEnumerator() //version typé
        {
            for(var i = 0 ; i < Count ; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>  //version non typé
            GetEnumerator();
    }
}