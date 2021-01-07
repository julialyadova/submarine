using UnityEngine;

public class FuelTank : SubmarinePart
{
    public int Capacity;
    
    public int Fuel{ get { return _fuel; } }

    public int Priority = 1;

    [SerializeField]
    private int _fuel;

    public int Take(int amount)
    {
        if (_fuel == 0)
            return 0;

        if (amount < _fuel)
        {
            _fuel -= amount;
        }
        else
        {
            amount = _fuel;
            _fuel = 0;                       
        }
        return amount;
    }

    public void Refill()
    {
        _fuel = Capacity;
    }

    protected override void OnBreak()
    {
        base.OnBreak();
        _fuel = 0;
    }

    protected override void OnDamageRecieved(float damage)
    {
        base.OnDamageRecieved(damage);
        if (CurrentDurability > TotalDurability / 2)
        {
            _fuel -= 2;
        }
        else
        {
            _fuel -= 2 + (int)damage;
        }
    }
}
