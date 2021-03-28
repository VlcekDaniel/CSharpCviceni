using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cviceni05
{
    public class SpojovySeznam : System.Collections.IEnumerable,System.Collections.ICollection,System.Collections.IList
    {
        private Prvek prvni;
        private Prvek posledni;
        public int Velikost;

         public class Prvek
        {
             public Prvek Dalsi;
             public Prvek Predchozi;
             public object Data;

            public Prvek(Prvek dalsi, Prvek predchozi, object data)
            {
                Dalsi = dalsi;
                Predchozi = predchozi;
                Data = data;
            }
            public Prvek(object data)
            {
                Data = data;
            }
        }

        //ENUMERATOR
        public class SpojovySeznamEnumerator : System.Collections.IEnumerator
        {
            private Prvek aktualni;
            public object Current => aktualni.Data;

             public SpojovySeznamEnumerator(Prvek aktualni)
            {
               this.aktualni = aktualni;
            }

            public bool MoveNext()
            {
                if (aktualni.Dalsi != null)
                {
                    aktualni = aktualni.Dalsi;
                    return true;
                }
                else {
                    return false;
                }
            }
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public object this[int index] {
            get => Return(index);
            set => Set(index, value);
        }

        public int Count => Velikost;

        public object SyncRoot => this;

        public bool IsSynchronized => false;

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public int Add(object value)
        {
            Prvek vkladany = new Prvek(value);
            if (Velikost == 0)
            {
                prvni = vkladany;
                posledni = vkladany;
            }
            else {
                posledni.Dalsi = vkladany;
                vkladany.Predchozi = posledni;                
                posledni = vkladany;
            }
            Velikost++;
            return Velikost;
        }
        public void Clear()
        {
            prvni = null;
            posledni = null;
            Velikost = 0;
        }
        public bool Contains(object value)
        {
            Prvek pom = prvni;
            Prvek hledany = new Prvek(value);
            while (pom.Dalsi!=null)
            {
                if (pom.Data == hledany.Data)
                {
                    return true;
                }
                pom = pom.Dalsi;
            }            
                return false;            
        }
        public void CopyTo(Array array, int index)
        {
            Prvek pom = prvni;
            for (int i = 0; i < index; i++)
            {
                pom = pom.Dalsi;
            }
            foreach (var item in array)
            {
                pom.Dalsi = new Prvek(item);
                pom = pom.Dalsi;
                Velikost++;
            }
        }
        public IEnumerator GetEnumerator()
        {
            Prvek aktualni = prvni;
            for (int i = 0; i < Velikost-1; i++)
            {
                aktualni = aktualni.Dalsi;
            }
            return new SpojovySeznamEnumerator(aktualni);
        }
        public int IndexOf(object value)
        {
            Prvek pom = prvni;
            Prvek hledany = new Prvek(value);
            int index = 0;
            while (pom.Dalsi != null)
            {
                if (pom.Data == hledany.Data)
                {
                    return index;
                }
                pom = pom.Dalsi;
                index++;
            }
            return -1;

        }
        public void Insert(int index, object value)
        {
            Prvek pom = prvni;
            for (int i = 0; i < index; i++)
            {
                pom = pom.Dalsi;
            }
            pom.Dalsi = new Prvek(value);
            Velikost++;
        }
        public void Remove(object value)
        {
            Prvek pom = prvni;
            Prvek hledany = new Prvek(value);
            while (pom.Dalsi != null)
            {
                if (pom.Data == hledany.Data)
                {
                    pom.Dalsi = pom.Dalsi.Dalsi;
                    break;
                }
                pom = pom.Dalsi;
            }
            Velikost--;
        }
        public object Return(int index)
        {
            Prvek pom = prvni;
            for (int i = 0; i < index; i++)
            {
                pom = pom.Dalsi;
            }
            return pom.Data;
        }

        public void Set(int index, object value)
        {
            Prvek pom = prvni;
            for (int i = 0; i < index; i++)
            {
                pom = pom.Dalsi;
            }
            pom.Data = value;
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                prvni = prvni.Dalsi;
            }
            else
            {
                Prvek pom = prvni;
                if (index + 1 == Velikost)
                {
                    posledni.Predchozi.Dalsi = null;
                    posledni = null;
                }
                else
                {                    
                    for (int i = 0; i < index - 1; i++)
                    {
                        pom = pom.Dalsi;
                    }
                    if (pom != posledni)
                    {
                        pom.Dalsi = pom.Dalsi.Dalsi;
                    }
                }
            }
            Velikost--;
        }
    }    
}
