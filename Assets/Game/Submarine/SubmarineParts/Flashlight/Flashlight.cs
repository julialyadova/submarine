using UnityEngine;

public class Flashlight : SubmarinePart
{
    public Transform MovingPartTransform;
    public float RotationAngle = 10f;
    public KeyCode KeyLight = KeyCode.F;

    private Light _light;

    private float _offsetX;
    private float _offsetY;

    private bool _enabled;

    void Start()
    {
        MovingPartTransform.localRotation = Quaternion.Euler(0, 0, 0);
        _light = GetComponentInChildren<Light>();
        _enabled = _light.enabled;
    }

    void Update()
    {
        if (CurrentDurability == 0)
            return;

        if (CurrentDurability < TotalDurability * 0.5f)
        {
            _light.enabled = RandomBool(0.8f);
        }

        if (Input.GetKeyDown(KeyLight))
        {
            _enabled = !_light.enabled;
            _light.enabled = _enabled;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _offsetX = Input.mousePosition.x;
            _offsetY = Input.mousePosition.y;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            MovingPartTransform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            MovingPartTransform.localRotation = Quaternion.Euler(
                Mathf.Clamp((Input.mousePosition.y - _offsetY) * -0.2f, -RotationAngle, RotationAngle),
                0,
                Mathf.Clamp((Input.mousePosition.x - _offsetX) * -0.2f, -RotationAngle, RotationAngle));
        }       
    }

    protected override void OnBreak()
    {
        _light.enabled = false;
    }

    private bool RandomBool(float trueChance)
    {
        return Random.Range(0f, 1f) < trueChance;
    }
}
