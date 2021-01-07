using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Submarine Submarine;

    public Bar FuelBar;
    public Bar DurabilityBar;
    public Text SpeedText;

    public GameObject DurabilityDetails;
    public SubmarinePartsStatusList SubmarinePartsStatusList;
    public FuelTanksStatusList FuelTanksStatusList;

    public Dictionary<SubmarinePart, SubmarinePartStatus> _submarinePartsDetails;


    private void Start()
    {
        SubmarinePartsStatusList.Load(Submarine.Parts);
        FuelTanksStatusList.Load(Submarine.FuelSources);
    }

    private void OnGUI()
    {            
        SpeedText.text = Mathf.Round(Submarine.Speed * 10).ToString();
        DurabilityBar.SetValue(Submarine.TotalDurability, Submarine.CurrentDurability);
        FuelBar.SetValue(Submarine.TotalFuel, Submarine.CurrentFuel);
    }
}
