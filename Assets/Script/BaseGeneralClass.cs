using UnityEngine;

public abstract class BaseGeneralClass : MonoBehaviour
{
    public abstract void Excecute();


    public virtual void Attack()
    {
        print("SimpleAttack");
    }

}