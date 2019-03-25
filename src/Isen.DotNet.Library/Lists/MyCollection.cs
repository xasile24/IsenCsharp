using System;

namespace Isen.DotNet.Library.Lists
{
    public class MyCollection
    {
        private string[] _values;

        public MyCollection()
        {
            _values = new string[0];
        }
        /// <summary>
        ///Taille de la liste
        ///</summary>
        public int Count => _values.Length;
        public string[] Values => _values;

        public string this[int index]
        {
            get { return _values[index]; }
            set { _values[index] = value; }
        }


        /// <summary>
        ///Ajoute un élément à la fin de la liste
        ///</summary>
        ///<param name="item"></param>
        public void Add(string item)
        {
            //Nouveau tableau
            var temp = new string[Count + 1];
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
            if( Values == null 
            || Values.Length == 0 
            || index > Count 
            || index < 0 )
                throw new IndexOutOfRangeException();

            //nouveau tableau
            var tmp = new string[Count - 1];

            //copier les elements du tableau initial
            for (var i = 0 ; i < tmp.Length ; i++)
            {
                if (i < index) tmp[i] = _values[i];
                else if (i >= index) tmp[i] = Values[i+1];
            }
            //echanger les tableaux
            _values = tmp;
        }
    }
}