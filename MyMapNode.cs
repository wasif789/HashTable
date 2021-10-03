using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    //Value type Data Type KeyValue
    public struct KeyValue<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    };

    public class MyMapNode<K, V>
    {
        int size;
        public LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }

        // Add:    -> get array position(GetHashCode)  -> get linked list position

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedListofPosition = GetLinkedListPosition(position);
            KeyValue<K, V> keyValue = new KeyValue<K, V>()
            {
                Key = key,
                Value = value
            };
            LinkedListofPosition.AddLast(keyValue);
        }

        //Step 1: Get array position
        public int GetArrayPosition(K key)
        {
            int hashcode = key.GetHashCode();
            int position = hashcode % size;
            return Math.Abs(position);
        }

        //Step 2: Create linkedlist for a particular position
        public LinkedList<KeyValue<K, V>> GetLinkedListPosition(int position)
        {
            if (items[position] == null)
            {
                items[position] = new LinkedList<KeyValue<K, V>>();
            }
            return items[position];
        }
        // Check if element is already Present
        public int CheckHash(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedListofPosition = GetLinkedListPosition(position);
            int count = 1;
            bool found = false;
            KeyValue<K, V> founditem = default(KeyValue<K, V>);

            foreach (KeyValue<K, V> keyValue in LinkedListofPosition)
            {
                if (keyValue.Key.Equals(key))
                {
                    count = Convert.ToInt32(keyValue.Value) + 1;
                    found = true;
                    founditem = keyValue;
                }
            }
            if (found)
            {
                LinkedListofPosition.Remove(founditem);
                return count;
            }
            else
            {
                return 1;
            }

        }
        //Display Linkedlist elements for particular key
        public void Display(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedListofPosition = GetLinkedListPosition(position);
            foreach (KeyValue<K, V> keyValue in LinkedListofPosition)
            {
                if (keyValue.Key.Equals(key))
                {
                    Console.WriteLine("Key: " + keyValue.Key + "\t Frequency: " + keyValue.Value + "\tPosition: " + position);
                }

            }
        }

    }
}
