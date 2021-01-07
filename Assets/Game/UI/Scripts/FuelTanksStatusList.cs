using UnityEngine;

public class FuelTanksStatusList : MonoBehaviour
{
    public FuelTankStatus StatusPrefab;

    public void Load(FuelTank[] fuelTanks)
    {
        foreach (var fuelTank in fuelTanks)
        {
            GameObject gameObj = Instantiate(StatusPrefab.gameObject);
            gameObj.GetComponent<FuelTankStatus>().AppendTank(fuelTank);
            gameObj.transform.SetParent(transform, false);
        }
    }
}
