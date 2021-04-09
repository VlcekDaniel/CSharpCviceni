using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni08
{
    public struct KeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public KeyValue<TKey, TValue>[] KeyValueitems;
    }

    class MinMaxHashTable<TKey, TValue> where TKey : IComparable
    {
        public int Count { get; set; }
        public KeyValue<TKey,TValue>[] items;
        public int Maximum { 
            get 
            {
                if (Count == 0) { throw new InvalidOperationException(); } else {
                    return Maximum;
                }
            }
            set
            { 
                //Maximum = value; 
            }
        }

        public int Minimum
        {
            get
            {
                if (Count == 0) { throw new InvalidOperationException(); }
                else
                {
                    return Minimum;
                }
            }
            set
            { 
                //Minimum = value; 
            }
        }

        public MinMaxHashTable(int capacity)
        {
            Count = 0;
            this.items = new KeyValue<TKey,TValue>[capacity];
            Maximum = 20;
            Minimum = 0;
        }
        public MinMaxHashTable()
        {
            Count = 0;
            this.items = new KeyValue<TKey, TValue>[20];
            Maximum = 20;
            Minimum = 0;
        }

        public KeyValue<TKey, TValue>[] this[int indexMin,int indexMax]
        {
            get {
                return Range(indexMax, indexMax);
            }
        }

        public void Add(TKey key, TValue value) {
            int keyInt = key.GetHashCode();
            int index = keyInt * 67 % 20;
            if (items[index].Value != null)
            {
                throw new ArgumentException();
            }
            KeyValue<TKey, TValue> item = new KeyValue<TKey, TValue>() { Key = key, Value = value };
            
            items[index] = item;
            Count++;
        }

        public bool Contains(TKey key) {
            if (Count == 0) {
                return false;
            }
            foreach (var item in items)
            {
                if (key.Equals(item.Key)) {
                    return true;
                }
            }
            return false;
        }

        public TValue Get(TKey key) {
            int keyInt = key.GetHashCode();
            int index = keyInt * 67 % 20;
            if (items[index].Value == null) {
                throw new KeyNotFoundException();
            }
            return items[index].Value;
        }

        public TValue Remove(TKey key) {
            int index = 0;
            foreach (var item in items)
            {
                if (key.Equals(item.Key))
                {
                    items[index] = items[Count];
                    Count--;
                    return item.Value;
                }
                index++;
            }
            throw new KeyNotFoundException();
        }

        public KeyValue<TKey, TValue>[] Range(int min, int max) {
            KeyValue<TKey, TValue>[] range = new KeyValue<TKey, TValue>[max - min];
            int index = 0;
            foreach (var item in range)
            {
                range[index] = items[min + index];
                index++;
            }
            return range;
        }

        public KeyValue<TKey, TValue>[] SortedRange(int min, int max)
        {
            KeyValue<TKey, TValue>[] range = new KeyValue<TKey, TValue>[max - min];
            for (int i = 0; i < range.Length - 1; i++)
            {
                for (int j = 0; j < range.Length - i - 1; j++)
                {
                    if (range[j + 1].Key.CompareTo(range[j].Key)>0)
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
