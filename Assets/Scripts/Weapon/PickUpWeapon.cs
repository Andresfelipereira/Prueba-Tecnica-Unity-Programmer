using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public GameWeapon weapon;
    public GameObject player;
    public float pickUpRange;
    public bool equipped;

    private void Start()
    {
       weapon.enabled = false;
       GetComponent<Rigidbody>().isKinematic = false;
    }

    void Update()
    {
        if (!equipped)
        {
            Vector3 distanceToPlayer = player.transform.position - transform.position;
            if(distanceToPlayer.magnitude <= pickUpRange && !player.GetComponent<PlayerManager>().GetWeaponEquipped())
            {
                Debug.Log("Press Z to grab weapon");
                if (Input.GetKeyDown("z"))
                {
                    PickUp();
                }
            }
        }
        else
        {
            if(Input.GetKeyDown("x"))
            {
                Drop();
            }
        }
    }

    public void PickUp()
    {
        equipped = true;
        weapon.enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<PlayerManager>().SetWeaponEquipped(true);
        transform.SetParent(player.transform);
        transform.localPosition = Vector3.zero+new Vector3(0.5f,0,1);
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    public void Drop()
    {
        equipped = false;
        weapon.enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<PlayerManager>().SetWeaponEquipped(false);
        transform.SetParent(null);
        transform.localPosition = transform.localPosition + new Vector3(-0.5f, 0,0);
    }
}
