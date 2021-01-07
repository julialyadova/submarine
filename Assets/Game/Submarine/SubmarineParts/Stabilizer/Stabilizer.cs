using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilizer : SubmarinePart
{
    private Transform _submarineTransform;

    void Start()
    {
        _submarineTransform = gameObject.GetComponentInParent<Submarine>().gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (_submarineTransform.rotation.eulerAngles.x != 0 || _submarineTransform.transform.rotation.eulerAngles.z != 0)
            _submarineTransform.rotation = Quaternion.Euler(0, _submarineTransform.transform.eulerAngles.y, 0);
    }
}
