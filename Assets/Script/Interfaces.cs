using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(int damage);

}
public interface IInteractable
{
    public void Interact();

}
public interface ICollectable
{
    public void Collect();
}