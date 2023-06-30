using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractBullet : MonoBehaviour
{
    //Radio de distancia entre la bala y los demas objetos sobre la cual se aplica la atraccion
    public float _radius;
    //Fuerza de atraccion
    public float _force;

    public void Update()
    {
        //Se obtienen todos los elementos dentro del escenario dentro del radio establecido
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (Collider collider in colliders){
            Debug.Log(colliders.Length+ collider.gameObject.tag);
            //La atraccion se aplica a todo GameObject cuyo tag es "Object" 
            if(collider.gameObject.tag == "Object") {
                
                Rigidbody body = collider.GetComponent<Rigidbody>();
                Vector3 forceDirection = transform.position - collider.transform.position;
                float distance = forceDirection.magnitude;
                forceDirection = forceDirection.normalized;
                float forceRate = (_force / distance);
                body.AddForce(forceDirection * (forceRate / body.mass));}
        }
    }
}
