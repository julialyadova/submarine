using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit raycastHit);
        var primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        primitive.transform.position = new Vector3(raycastHit.point.x, raycastHit.point.y + primitive.transform.localScale.y / 2, raycastHit.point.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
