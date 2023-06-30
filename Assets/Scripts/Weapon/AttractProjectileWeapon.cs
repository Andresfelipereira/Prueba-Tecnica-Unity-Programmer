using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractProjectileWeapon : GameWeapon
{
    bool needReload;

    void Update()
    {
        if (Input.GetKeyDown("space")&&!needReload)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        needReload = true;
        Transform Temp = pointSpawn.transform;
        GameObject newBullet = GameObject.Instantiate(weapon.bullet, Temp);
        newBullet.transform.SetParent(null, true);
        newBullet.GetComponent<Rigidbody>().AddForce(pointSpawn.forward * weapon.throwStrength);
        StartCoroutine(DestroyBullet(newBullet));
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(bullet);
        needReload = false;
    }
}
