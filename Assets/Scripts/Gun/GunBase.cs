using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GunLogic;

public class GunBase : MonoBehaviour
{
    GunStats stats;
    public AudioSource source;
    public AudioClip clip; 
    public Camera playerCam;
    public bool gunIsAuto = true;
    bool isFiringGun = false;
    bool hasAmmoLeft = false;
   public float gunDamage;
   public float gunRange;

    float gunAmmoCapacity;

    float remainingAmmo;

    public string testing = "Revolver";

void Start ()
{
    stats = gameObject.GetComponent<GunStats>();
    stats.Revolver();
    getGunStats();
}
    // Update is called once per frame
    void Update()
    {       // Fire1 is a default button set by unity, and if not manually changed, it's set to Mouse 1
     if (Input.GetButtonDown("Fire1"))
     {
        if (gunIsAuto == true)
        {
            StartCoroutine(fullAutoFire());
            isFiringGun = true;

        }

     } 
     if (Input.GetButtonUp("Fire1"))
     {
        isFiringGun = false;
     }
    }

    IEnumerator fullAutoFire()
    {
        Shoot();
        yield return new WaitForSeconds(0.1f);
        if (isFiringGun == true)
        {
            StartCoroutine(fullAutoFire());
        }
        else if (isFiringGun == false)
        {}
    }



    void Shoot()
    {
        source.PlayOneShot(clip);
        //  When the shoot function is called, shoots out a raycast from the player's camera, with the distance of the "range" value
        //  (this can be changed by changing the playerCam and assigning it to another object, such as a gun, if you want the "bullet" to come from an actual gun)
        //  Stores the info from the object in the private "hitInfo" variable, which can then be used to do things relating to the object hit, such as debugging the name,
        //  or doing math to deal damage
        RaycastHit hitInfo;
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hitInfo, gunRange)) 
        {
            Debug.Log("Gun Fired!");
            Debug.Log(hitInfo.transform.name);
            // Stores a reference to the component "EnemyScript" in the variable "enemyscript"
            EnemyScript enemyScript = hitInfo.transform.GetComponent<EnemyScript>();
            // Does a check to see if the hit object has a comonent named "EnemyScript" attatched to it by checking if the enemyScript variable is equal to null or not
            if (enemyScript != null)
            {
                enemyScript.enemyHealth = enemyScript.enemyHealth - gunDamage;
                Debug.Log(" " + hitInfo.transform.name + "was hit and dealt " + gunDamage + "damage. Their remaining health is now" + enemyScript.enemyHealth);
            }

            

        }

    }




    public void getGunStats()
    {
        
    }

}


