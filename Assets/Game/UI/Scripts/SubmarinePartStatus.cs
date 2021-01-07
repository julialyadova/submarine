using UnityEngine;
using UnityEngine.UI;

public class SubmarinePartStatus : MonoBehaviour
{
    public Text Name;
    public Bar Bar;

    public SubmarinePart SubmarinePart;

    public void AppendPart(SubmarinePart submarinePart)
    {
        SubmarinePart = submarinePart;
        Name.text = SubmarinePart.Name;
    }

    public void OnGUI()
    {
        Bar.SetValue(SubmarinePart.TotalDurability, SubmarinePart.CurrentDurability);
    }
}
