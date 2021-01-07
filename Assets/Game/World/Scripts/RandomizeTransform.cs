using UnityEngine;

public class RandomizeTransform : MonoBehaviour
{
    [Header("Randomize Rotation:")]
    public bool RotationX = true;
    public bool RotationY = true;
    public bool RotationZ = true;
    public Vector3 MinRotation = new Vector3(0,0,0);
    public Vector3 MaxRotation = new Vector3(360, 360, 360);
    [Header("Randomize Scale:")]
    public bool ScaleX = true;
    public bool ScaleY = true;
    public bool ScaleZ = true;
    [Space(10)]
    public Vector3 MinScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 MaxScale = new Vector3(2f, 2f, 2f);
    [Space(10)]
    public bool EqualX = false;
    public bool EqualY = false;
    public bool EqualZ = false;

    void Start()
    {
        transform.localRotation = Quaternion.Euler(
                RotationX ? Random.Range(MinRotation.x, MaxRotation.x) : transform.rotation.eulerAngles.x,
                RotationY ? Random.Range(MinRotation.y, MaxRotation.y) : transform.rotation.eulerAngles.y,
                RotationZ ? Random.Range(MinRotation.z, MaxRotation.z) : transform.rotation.eulerAngles.z);

        var randomScale = new Vector3(
            Random.Range(MinScale.x, MaxScale.x),
            Random.Range(MinScale.y, MaxScale.y),
            Random.Range(MinScale.z, MaxScale.z));

        if (EqualX && EqualY)
            randomScale.x = randomScale.y;
        if (EqualY && EqualZ)
            randomScale.y = randomScale.z;
        if (EqualX && EqualZ)
            randomScale.x = randomScale.z;

        transform.localScale = new Vector3(
            ScaleX ? randomScale.x : transform.localScale.x,
            ScaleY ? randomScale.y : transform.localScale.y,
            ScaleZ ? randomScale.z : transform.localScale.z);
    }
}
