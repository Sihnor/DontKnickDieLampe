using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyCollection<T> : ScriptableObject
{
    public event Action<T> OnAdd
    {
        add
        {
            onAdd -= value;
            onAdd += value;
        }
        remove 
        {
            onAdd -= value;
        }
    }

    public event Action<T> OnRemove
    {
        add
        {
            onRemove -= value;
            onRemove += value;
        }
        remove 
        {
            onRemove -= value;
        }
    }

    private List<T> Data = new List<T>();

    private event Action<T> onRemove;
    private event Action<T> onAdd;

    public void Add(T _item)
    {
        Data.Add(_item);
        onAdd?.Invoke(_item);
    }

    public void Remove(T _item)
    {
        Data.Remove(_item);
        onRemove?.Invoke(_item);
    }
}
