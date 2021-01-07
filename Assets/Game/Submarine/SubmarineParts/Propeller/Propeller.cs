using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : SubmarinePart
{
    public float Force = 500f;
    public float RotateSpeed = 500f;
    public int FuelPerSecond = 1;

    public KeyCode KeyForward = KeyCode.W;
    public KeyCode KeyBack = KeyCode.S;

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
            if (Input.GetKey(KeyForward))
            {
                _submarineRigidbody.AddForce(_submarine.transform.forward * Force * Time.deltaTime);
                transform.Rotate(Vector3.forward, RotateSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyBack))
            {
                _submarineRigidbody.AddForce(_submarine.transform.forward * -Force * Time.deltaTime);
                transform.Rotate(Vector3.back, RotateSpeed * Time.deltaTime);
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
        if (Input.GetKey(KeyForward) || Input.GetKey(KeyBack))
            _hasFuel = _submarine.TakeFuel(FuelPerSecond) != 0;
        else if (_hasFuel)
            _hasFuel = false;          
    }
}
