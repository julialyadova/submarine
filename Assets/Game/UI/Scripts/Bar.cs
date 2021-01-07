using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public RectTransform Progress;
    public Text Value;

    private Vector3 _scale;

    void Start()
    {
        _scale = Vector3.one;
    }

    public void SetValue(int total, int current)
    {
        Value.text = current.ToString();
        if (total == 0)
            _scale.x = 0;
        else
            _scale.x = (float)current / total;

        Progress.localScale = _scale;
    }
}
