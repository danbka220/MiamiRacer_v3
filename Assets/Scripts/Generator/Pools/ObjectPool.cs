using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> where T : BlockBase
{
    public abstract bool HaveObjects { get; }

    public abstract T GetRandom();
    public abstract void Put(T go);
}
