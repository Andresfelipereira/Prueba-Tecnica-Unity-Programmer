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
    }

    void Update()
    {
        Vector3 distanceToPlayer = player.transform.position - transform.position;
        if(distanceToPlayer.magnitude <= pickUpRange && !equipped && !player.GetComponent<PlayerManager>().GetWeaponEquipped())
        {
            player.GetComponent<PlayerManager>().GetPlayerUIManager().ShowMessage("Press Z to grab weapon");
            Debug.Log("Press Z to grab weapon");
            if (Input.GetKeyDown("z"))
            {
                PickUp();
            } 
               
        }else if (distanceToPlayer.magnitude > pickUpRange && !equipped)
        {
            player.GetComponent<PlayerManager>().GetPlayerUIManager().ShowMessage("");
        }
        if(equipped && Input.GetKeyDown("x"))
        {
            Drop();
        }
    }

    public void PickUp()
    {
        equipped = true;
        weapon.enabled = true;
        player.GetComponent<PlayerManager>().SetWeaponEquipped(true);
        transform.SetParent(player.transform);
        transform.localPosition = Vector3.zero+new Vector3(0.5f,0,1);
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        player.GetComponent<PlayerManager>().GetPlayerUIManager().ShowMessage("Press X to drop weapon");
    }

    public void Drop()
    {
        equipped = false;
        weapon.enabled = false;
        player.GetComponent<PlayerManager>().SetWeaponEquipped(false);
        player.GetComponent<PlayerManager>().GetPlayerUIManager().ShowMessage("");
        transform.SetParent(null);
        transform.localPosition = transform.localPosition + new Vector3(-0.5f, 0,0);
    }
}
