using UnityEngine;

public class Rudder : SubmarinePart
{
    public float RotateAngle = 10f;
    public float Mobility = 0.1f;

    private Submarine _submarine;
    private Rigidbody _submarineRigidbody;

    private float _rotation;

    void Start()
    {
        _submarine = gameObject.GetComponentInParent<Submarine>();
        _submarineRigidbody = _submarine.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            TurnLeft();

        if (Input.GetKey(KeyCode.D))
            TurnRight();
    }

    private void FixedUpdate()
    {
        var submarineSpeed = _submarineRigidbody.velocity.magnitude;
        if (submarineSpeed > 0)
            _submarine.transform.Rotate(0, submarineSpeed * _rotation * Time.fixedDeltaTime, 0);
    }

    private void TurnRight()
    {
        if (_rotation < RotateAngle)
        {
            _rotation += Mobility;
            transform.localRotation = Quaternion.Euler(0, _rotation, 0);
        }
    }

    private void TurnLeft()
    {
        if (_rotation > -RotateAngle)
        {
            _rotation -= Mobility;
            transform.localRotation = Quaternion.Euler(0, _rotation, 0);
        }
    }
}
