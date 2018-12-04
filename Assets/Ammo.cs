using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject newBullet;
    public float timeReload = 1f;
    public void OnCollisionEnter(Collision collision)
    {
        PlayerController pc = collision.collider.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            Gun gun = pc.gameObject.GetComponent<Gun>();
            if (gun != null)
            {
                gun.bullet = newBullet;
                gun.timeReload = timeReload;
                Destroy(gameObject);
            }
        }
    }
}
