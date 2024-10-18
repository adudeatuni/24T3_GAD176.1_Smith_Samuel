using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public float damage = 10f;
    public float range= 100f;
    public Camera playerCam;

    // Update is called once per frame
    void Update()
    {       // Fire1 is a default button set by unity, and if not manually changed, it's set to Mouse 1
     if (Input.GetButtonDown("Fire1"))
     {
        Shoot();
     }   
    }



    void Shoot()
    {

        RaycastHit hitInfo;
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hitInfo, range))
        {
        Debug.Log(hitInfo.transform.name);
        }

    }

}
