using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeJail : MonoBehaviour
{
    private float _radius = 1f;
    private float _force = 5f;

    private void OnEnable()
    {
        Explode();
    }

    public void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);
        for(int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_force, transform.position, _radius);
            }
        }
    }
}
