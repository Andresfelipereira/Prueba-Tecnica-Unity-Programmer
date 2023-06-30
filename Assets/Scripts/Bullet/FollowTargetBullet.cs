using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetBullet : MonoBehaviour
{
    //Rigidbody de la bala
    Rigidbody rb;
    //Colider del objeto objetivo seleccionado
    Collider target;
    //Radio de covertura
    public float radius;
    //Fuerza de la bala
    public float force;
    //Velocidad de movimiento de la bala
    public float speed;
    //Velocidad de rotacion de la bala
    public float rotationSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SelectTarget();
    }

    public void FixedUpdate()
    {
        //Si se ha definido un objetivo la bala tendra una direccion hacia el objetivo
        if(target != null) { 
        Vector3 direction = target.gameObject.transform.position - rb.position;
        direction.Normalize();
        Vector3 rotateAmount = Vector3.Cross(direction, transform.forward);
        rb.angularVelocity = -rotateAmount * rotationSpeed;
        rb.velocity = transform.forward * speed;
        }
    }

    //Seleccion aleatoria del objetivo
    public void SelectTarget()
    {
        //Se recolecta todos los objetos que se encuentran sobre el radio y se toman unicamente aquellos cuyo tag es "Object"
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        List<Collider> collidersAux = new List<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Object")
            {
                collidersAux.Add(colliders[i]);
            }
        }
        if (collidersAux.Count > 0)
        {
            //Seleccion aleatoria del objectivo
            int selectedTarget = Random.Range(0, collidersAux.Count);
            target = collidersAux[selectedTarget];
        }
        Debug.Log(collidersAux.Count);
    }

}
