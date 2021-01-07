using UnityEngine;

public class SubmarinePart : MonoBehaviour
{
    public string Name = "Part";
    public int TotalDurability = 10;
    public int CurrentDurability = 10;
    public int Mass;

    public int RecieveDamage(int damage)
    {
        if (damage < CurrentDurability)
        {
            CurrentDurability -= damage;
            OnDamageRecieved(damage);
        }
        else
        {
            damage = CurrentDurability;
            CurrentDurability = 0;
            OnBreak();
        }
        return damage;
    }

    public void Repair()
    {
        CurrentDurability = TotalDurability;
    }

    protected virtual void OnBreak()
    {

    }

    protected virtual void OnDamageRecieved(float damage)
    {

    }
}
