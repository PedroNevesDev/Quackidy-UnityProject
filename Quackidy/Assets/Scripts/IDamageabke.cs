using UnityEditor.Purchasing;
using UnityEngine;

public interface IDamageable
{
    public void Push(Vector2 direction, float pushForce);
}
