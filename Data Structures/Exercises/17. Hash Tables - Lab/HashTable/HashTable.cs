using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    public const int InitialCapacity = 16;

    public const float LoadFactor = 0.75f;

    public int Count { get; private set; }

    private LinkedList<KeyValue<TKey, TValue>>[] slots;

    public int Capacity => slots.Length;

    public HashTable(int capacity = InitialCapacity)
    {
        slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
    }

    public void Add(TKey key, TValue value)
    {
        GrowIfNeeded();
        int slot = FindSlot(key);

        if (slots[slot] == null)
        {
            slots[slot] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in slots[slot])
        {
            if (element.Key.Equals(key))
            {
                throw new ArgumentException();
            }
        }

        slots[slot].AddLast(new KeyValue<TKey, TValue>(key, value));
        Count++;
    }

    private int FindSlot(TKey key)
    {
        return Math.Abs(key.GetHashCode() % slots.Length);
    }

    private void GrowIfNeeded()
    {
        if ((float)(Count + 1) / Capacity <= LoadFactor)
        {
            return;
        }

        var newHashTable = new HashTable<TKey, TValue>(2 * Capacity);

        foreach (var keyValue in this)
        {
            newHashTable.Add(keyValue.Key, keyValue.Value);
        }

        slots = newHashTable.slots;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        GrowIfNeeded();
        int slot = FindSlot(key);

        if (slots[slot] == null)
        {
            slots[slot] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in slots[slot])
        {
            if (element.Key.Equals(key))
            {
                element.Value = value;
                return false;
            }
        }

        slots[slot].AddLast(new KeyValue<TKey, TValue>(key, value));
        Count++;
        return true;
    }

    public TValue Get(TKey key)
    {
        var keyValue = Find(key);

        if (keyValue == null)
        {
            throw new KeyNotFoundException();
        }

        return keyValue.Value;
    }

    public TValue this[TKey key]
    {
        get => Get(key);
        set => AddOrReplace(key, value);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var keyValue = Find(key);

        if (keyValue == null)
        {
            value = default(TValue);
            return false;
        }

        value = keyValue.Value;
        return true;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        var list = slots[FindSlot(key)];

        if (list != null)
        {
            foreach (var keyValue in list)
            {
                if (keyValue.Key.Equals(key))
                {
                    return keyValue;
                }
            }
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        return Find(key) != null;
    }

    public bool Remove(TKey key)
    {
        var list = slots[FindSlot(key)];

        if (list != null)
        {
            foreach (var node in list)
            {
                if (node.Key.Equals(key))
                {
                    list.Remove(node);
                    Count--;
                    return true;
                }
            }
        }

        return false;
    }

    public void Clear()
    {
        slots = new LinkedList<KeyValue<TKey, TValue>>[InitialCapacity];
        Count = 0;
    }

    public IEnumerable<TKey> Keys => this.Select(el => el.Key);

    public IEnumerable<TValue> Values => this.Select(el => el.Value);

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var list in slots)
        {
            if (list != null)
            {
                foreach (var keyValue in list)
                {
                    yield return keyValue;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
