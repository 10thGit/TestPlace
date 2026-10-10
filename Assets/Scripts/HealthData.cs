

public class HealthData
{
    public float MaxHP { get; private set; }
    public float CurrentHP { get; private set; }
    public bool IsDead => CurrentHP <= 0;


    public HealthData(float pMaxHP)
    {
        SetMaxHP(pMaxHP);
    }

    public void SetMaxHP(float pMaxHP)
    {
        MaxHP = pMaxHP;
        CurrentHP = MaxHP;
    }

    public void TakeDamage(float pDamage)
    {
        if(IsDead || pDamage <= 0)
            return;

        CurrentHP -= pDamage;
    }
}