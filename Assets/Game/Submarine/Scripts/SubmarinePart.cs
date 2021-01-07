using UnityEngine;

public class SubmarinePart : MonoBehaviour
{
    public string Name = "Part";
    public int TotalDurability = 10;
    public int CurrentDurability = 10;
    public int Mass;

    void Start()
    {
    }

    public int RecieveDamage(int damage)
    {
        if (damage < CurrentDurability)
        {
            CurrentDurability -= damage;
        }
        else
        {
            damage = CurrentDurability;
            CurrentDurability = 0;
        }
        return damage;
    }

    public void Repair()
    {
        CurrentDurability = TotalDurability;
    }
}
