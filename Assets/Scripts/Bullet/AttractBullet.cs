using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractBullet : MonoBehaviour
{
    public float pullRadius = 2;
    public float pullForce = 1;

    public void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pullRadius);
        foreach (Collider collider in colliders){
            if(collider.gameObject.tag == "Untagged") {
                Rigidbody body = collider.GetComponent<Rigidbody>();
                Vector3 forceDirection = transform.position - collider.transform.position;
                float distance = forceDirection.magnitude;
                forceDirection = forceDirection.normalized;
                float forceRate = (pullForce / distance);
                body.AddForce(forceDirection * (forceRate / body.mass));}
        }
    }
}
