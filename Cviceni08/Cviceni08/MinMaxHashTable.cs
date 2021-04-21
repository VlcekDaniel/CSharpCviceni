using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Cviceni08
{
    public struct KeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    class MinMaxHashTable<TKey, TValue> where TKey : IComparable
    {
        public int Count { get; set; }
        public LinkedList<KeyValue<TKey, TValue>>[] linkedList;
        //public KeyValue<TKey,TValue>[] items;
        private int size;
        private int maximum;
        private int minimum;

        public int Maximum
        {
            get { if (Count != 0) { return maximum; } throw new InvalidOperationException(); }
            set { maximum = value; }
        }
        public int Minimum
        {
            get { if (Count != 0) { return minimum; } throw new InvalidOperationException(); }
            set { minimum = value; }
        }
        public MinMaxHashTable(int capacity)
        {
            Count = 0;
            //this.items = new KeyValue<TKey,TValue>[capacity];
            linkedList = new LinkedList<KeyValue<TKey, TValue>>[capacity];
            maximum = 0;
            minimum = 0;
            size = capacity;
        }
        public MinMaxHashTable()
        {
            Count = 0;
            //this.items = new KeyValue<TKey, TValue>[20];
            linkedList = new LinkedList<KeyValue<TKey, TValue>>[20];
            maximum = 0;
            minimum = 0;
            size = 20;
        }

        public KeyValue<TKey, TValue>[] this[int indexMin,int indexMax]
        {
            get {
                return Range(indexMin, indexMax);
            }
        }

        public void Add(TKey key, TValue value) {
            int keyInt = key.GetHashCode() % size;
            if (keyInt < 0) {
                keyInt *= -1;
            }

            if (linkedList[keyInt] == null)
            {
                linkedList[keyInt] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            KeyValue<TKey, TValue> item = new KeyValue<TKey, TValue>() { Key = key, Value = value };


            if (linkedList[keyInt].Count == 0)
            {
                linkedList[keyInt].AddFirst(item);
            }
            else {
                if (Contains(key)) {
                    throw new ArgumentException();
                }
                linkedList[keyInt].AddFirst(item);
            }   
            if (Convert.ToInt32(key)  < minimum) {
                minimum = Convert.ToInt32(key);
            }
            if (Convert.ToInt32(key) > maximum)
            {
                maximum = Convert.ToInt32(key);
            }
            Count++;
        }

        public bool Contains(TKey key) {
            int keyInt = key.GetHashCode()% size;
            if (keyInt < 0)
            {
                keyInt *= -1;
            }

            if (Count == 0) {
                return false;
            }
            if (linkedList[keyInt] == null) {
                return false;
            }

            LinkedListNode<KeyValue<TKey, TValue>> keyValueAktualni = linkedList[keyInt].First;
            while (keyValueAktualni!= null)
            {
                if (keyValueAktualni.Value.Key.Equals(key))
                {
                    return true;
                }
                keyValueAktualni = keyValueAktualni.Next;
            }
            return false;       
        }

        public TValue Get(TKey key) {
            int keyInt = key.GetHashCode() % size;

            if (Count == 0)
            {
                throw new KeyNotFoundException();
            }

            if (linkedList[keyInt] == null)
            {
                throw new KeyNotFoundException();
            }

            LinkedListNode<KeyValue<TKey, TValue>> keyValueAktualni = linkedList[keyInt].First;
            while (!keyValueAktualni.Equals(null))
            {
                if (keyValueAktualni.Value.Key.Equals(key))
                {
                    return keyValueAktualni.Value.Value;
                }
                keyValueAktualni = keyValueAktualni.Next;
            }
            throw new KeyNotFoundException();
        }

        public TValue Remove(TKey key) {           
            int keyInt = key.GetHashCode() % size;

            if (Count == 0) {
                throw new KeyNotFoundException();
            }

            if (linkedList[keyInt] == null)
            {
                throw new KeyNotFoundException();
            }

            LinkedListNode<KeyValue<TKey, TValue>> keyValueAktualni = linkedList[keyInt].First;
            while (keyValueAktualni != null)
            {
                if (keyValueAktualni.Value.Key.Equals(key))
                {
                    TValue value = keyValueAktualni.Value.Value;
                    linkedList[keyInt].Remove(keyValueAktualni);
                    Count--;
                    return value;
                }
            }
            throw new KeyNotFoundException();

        }

        public KeyValue<TKey, TValue>[] Range(int min, int max)
        {
            if (Count > 0)
            {
                int velikostRange = 0;
                for (int i = min; i < max+1; i++)
                {
                    velikostRange += linkedList[i].Count;
                }

                KeyValue<TKey, TValue>[] range = new KeyValue<TKey, TValue>[velikostRange];
                int index = 0;

                for (int i = min; i < max+1; i++)
                {
                    LinkedListNode<KeyValue<TKey, TValue>> aktualni = linkedList[i].First;
                    while (aktualni != null)
                    {
                        range[index] = aktualni.Value;
                        index++;
                        aktualni = aktualni.Next;
                    }
                }
                return range;
            }
            return null;
        }

        public KeyValue<TKey, TValue>[] SortedRange(int min, int max)
        {
            KeyValue<TKey, TValue>[] range = Range(min, max);
            for (int i = 0; i < range.Length - 1; i++)
            {
                for (int j = 0; j < range.Length - i-1; j++)
                {
                    if (range[j + 1].Key.CompareTo(range[j].Key)<0)
                    {
                        KeyValue<TKey, TValue> tmp = range[j + 1];
                        range[j + 1] = range[j];
                        range[j] = tmp;
                    }
                }
            }
            return range;
        }
    }
}
