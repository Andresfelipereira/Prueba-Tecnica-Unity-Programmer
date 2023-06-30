using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetWeapon : GameWeapon
{
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Transform Temp = pointSpawn.transform;
        GameObject newBullet = GameObject.Instantiate(weapon.bullet, Temp);
        newBullet.transform.SetParent(null, true);
        newBullet.GetComponent<Rigidbody>().AddForce(pointSpawn.forward * weapon.throwStrength, ForceMode.Impulse);
         StartCoroutine(DestroyBullet(newBullet));
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(bullet);
    }
}
