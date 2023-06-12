using UnityEngine;

public interface IDamageable
{
    public void Push(Vector2 direction, float pushForce);

    public void SlowDown();

    public void StopSlow();
}
