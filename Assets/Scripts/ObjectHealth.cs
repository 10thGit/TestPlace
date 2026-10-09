using UnityEngine;


public class ObjectHealth
{
    public float MaxHP { get; private set; }
    public float CurrentHP { get; private set; }
    public bool isDead => CurrentHP <= 0;


    public ObjectHealth(float pMaxHP)
    {
        MaxHP = pMaxHP;
        CurrentHP = MaxHP;
    }

    public void SetMaxHP(float pMaxHP)
    {
        MaxHP = Mathf.Max(0f, pMaxHP);
        CurrentHP = Mathf.Clamp(CurrentHP, 0f, MaxHP);
    }

    public void TakeDamage(float pDamage)
    {
        if(isDead || pDamage <= 0)
            return;

        CurrentHP = Mathf.Max(0f, CurrentHP - pDamage);
    }
}