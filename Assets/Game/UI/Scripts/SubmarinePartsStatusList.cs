using UnityEngine;

public class SubmarinePartsStatusList : MonoBehaviour
{
    public SubmarinePartStatus StatusPrefab;
    
    public void Load(SubmarinePart[] submarineParts)
    {
        foreach (var submarinePart in submarineParts)
        {
            GameObject gameObj = Instantiate(StatusPrefab.gameObject);
            gameObj.GetComponent<SubmarinePartStatus>().AppendPart(submarinePart);
            gameObj.transform.SetParent(transform, false);
        }
    }
}
