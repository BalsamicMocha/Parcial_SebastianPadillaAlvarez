using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : class
{
    private readonly Func<T> createFunc;
    private readonly Action<T> onGet;
    private readonly Action<T> onRelease;
    private readonly Stack<T> stack = new Stack<T>();

    public ObjectPool(Func<T> createFunc, Action<T> onGet, Action<T> onRelease, int initialSize = 0)
    {
        this.createFunc = createFunc;
        this.onGet = onGet;
        this.onRelease = onRelease;
        for (int i = 0; i < initialSize; i++)
        {
            var obj = createFunc();
            onRelease(obj);
            stack.Push(obj);
        }
    }

    public T Get()
    {
        T item = stack.Count > 0 ? stack.Pop() : createFunc();
        onGet(item);
        return item;
    }

    public void Release(T item)
    {
        onRelease(item);
        stack.Push(item);
    }
}