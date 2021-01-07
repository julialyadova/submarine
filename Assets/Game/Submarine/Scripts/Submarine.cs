using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Submarine : MonoBehaviour
{
    public int TotalDurability { get; private set; }
    public int CurrentDurability { get; private set; }
    public int TotalFuel { get; private set; }
    public int CurrentFuel { get; private set; }
    public float Speed { get { return _rigidbody.velocity.magnitude; } }

    public SubmarinePart[] Parts { get { return _parts; } }
    public FuelTank[] FuelSources { get { return _fuelSources; } }


    private Rigidbody _rigidbody;
    private SubmarinePart[] _parts;
    private FuelTank[] _fuelSources;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _parts = gameObject.GetComponentsInChildren<SubmarinePart>();
        _rigidbody.mass = _parts.Select(part => part.Mass).Sum() / 100f;
        TotalDurability = _parts.Select(part => part.TotalDurability).Sum();
        CurrentDurability = _parts.Select(part => part.CurrentDurability).Sum();

        _fuelSources = gameObject.GetComponentsInChildren<FuelTank>()
            .OrderBy(tank => tank.Priority)
            .ToArray();
        TotalFuel = _fuelSources.Select(fuelSource => fuelSource.Capacity).Sum();
        CurrentFuel = _fuelSources.Select(fuelSource => fuelSource.Fuel).Sum();
    }

    public int TakeFuel(int amount)
    {
        int taken = 0;
        foreach (var fuelSource in _fuelSources)
        {
            taken += fuelSource.Take(amount - taken);
            if (taken == amount)
                break;
        }
        CurrentFuel -= taken;
        return taken;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Коллизия Субмарины" + collision.contacts.Length);

        var damage = (int)Math.Round(_rigidbody.velocity.magnitude * _rigidbody.mass);
        CurrentDurability -= collision.contacts
            .Select(point => point.thisCollider.gameObject.GetComponent<SubmarinePart>())
            .First(submarinePart => submarinePart != null)
            .RecieveDamage(damage);
    }
}
