using System.Collections;
using UnityEngine;

public class DivingPlane : SubmarinePart
{
    public int Force = 400;
    public int FuelPerSecond = 3;
    public KeyCode KeyUp = KeyCode.Space;
    public KeyCode KeyDown = KeyCode.LeftControl;

    private Submarine _submarine;
    private Rigidbody _submarineRigidbody;
    private bool _hasFuel;

    void Start()
    {
        _submarine = gameObject.GetComponentInParent<Submarine>();
        _submarineRigidbody = _submarine.GetComponent<Rigidbody>();

        if (FuelPerSecond != 0)
            StartCoroutine(OneSecondCoroutine());
    }

    private void Update()
    {
        if (_hasFuel)
            if (Input.GetKey(KeyUp))
            {
                _submarineRigidbody.AddForce(Vector3.up * Force * Time.deltaTime);
            }
            else if (Input.GetKey(KeyDown))
            {
                _submarineRigidbody.AddForce(Vector3.up * -Force * 1.6f * Time.deltaTime);
            }
    }
    private IEnumerator OneSecondCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ConsumeFuel();
        }
    }

    private void ConsumeFuel()
    {
        if (Input.GetKey(KeyUp) || Input.GetKey(KeyDown))
            _hasFuel = _submarine.TakeFuel(FuelPerSecond) != 0;
        else if (_hasFuel)
            _hasFuel = false;
    }
}
