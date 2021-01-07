using UnityEngine;
using UnityEngine.UI;

public class FuelTankStatus : MonoBehaviour
{
    public Text Name;
    public Bar Bar;

    public FuelTank FuelTank;

    public void AppendTank(FuelTank fuelTank)
    {
        FuelTank = fuelTank;
        Name.text = FuelTank.Name;
    }

    public void OnGUI()
    {
        Bar.SetValue(FuelTank.Capacity, FuelTank.Fuel);
    }
}
