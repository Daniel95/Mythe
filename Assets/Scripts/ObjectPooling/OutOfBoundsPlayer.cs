using UnityEngine;
using System.Collections;

public class OutOfBoundsPlayer : OutOfBoundsHandler {

    [SerializeField]
    private HealthBar healthBar;

    protected override void OutOfBounds()
    {
        base.OutOfBounds();
        healthBar.Die();
    }
}
