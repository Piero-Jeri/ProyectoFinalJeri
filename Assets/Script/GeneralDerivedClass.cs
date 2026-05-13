using UnityEngine;

public class GeneralDerivedClass : BaseGeneralClass
{

    public override void Excecute()
    {
        print("Attack");
    }

    public override void Attack()
    {
        base.Attack();
        print("X");


    }


    int hp = 10;
    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    public void TakeDamage()
    {
        hp--;
    }
    public void TakeDamage(int damage, bool crit, float critMult)
    {
        hp -= damage;
    }







}