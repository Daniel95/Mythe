using UnityEngine;
using System.Collections;

public class OutOfBoundsPool : OutOfBoundsHandler
{
    protected override void OutOfBounds()
    {
        base.OutOfBounds();
        ObjectPool.instance.PoolObject(gameObject);
    }
}
