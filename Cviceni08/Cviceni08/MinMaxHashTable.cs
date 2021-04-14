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
            this.items = new KeyValue<TKey,TValue>[capacity];
            maximum = 0;
            minimum = 0;
        }
        public MinMaxHashTable()
        {
            Count = 0;
            this.items = new KeyValue<TKey, TValue>[20];
            maximum = 0;
            minimum = 0;
        }

        public KeyValue<TKey, TValue>[] this[int indexMin,int indexMax]
        {
            get {
                return Range(indexMin, indexMax);
            }
        }

        public void Add(TKey key, TValue value) {
            int keyInt = key.GetHashCode() * 67 % 20;
            if (keyInt < 0) {
                keyInt *= -1;
            }
            if (items[keyInt].Value != null)
            {
                throw new ArgumentException();
            }
            KeyValue<TKey, TValue> item = new KeyValue<TKey, TValue>() { Key = key, Value = value };           
            items[keyInt] = item;
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
            int keyInt = key.GetHashCode() * 67 % 20;
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
            KeyValue<TKey, TValue>[] range = new KeyValue<TKey, TValue>[max-min+1];
            int index = 0;
            foreach (var item in items)
            {
                if (Convert.ToInt32(item.Key) >= min && Convert.ToInt32(item.Key) <= max)
                {
                    range[Convert.ToInt32(item.Key)-min] = items[index];                   
                }
                index++;
            }
            return range;
        }

        public KeyValue<TKey, TValue>[] SortedRange(int min, int max)
        {
            KeyValue<TKey, TValue>[] range = new KeyValue<TKey, TValue>[max - min];
            for (int i = 0; i < range.Length - 1; i++)
            {
                for (int j = 0; j < range.Length - i; j++)
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
