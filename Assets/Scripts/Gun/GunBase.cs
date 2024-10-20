using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunLogic
{
public class GunBase : MonoBehaviour
{
    private GunStats stats;
    public AudioSource source;
    public AudioClip clip; 
    public Camera playerCam;
    private bool gunIsAuto = true;
    private bool isFiringGun = false;
   private float gunDamage;
   private float gunRange = 0;
   private float gunFireRate;

    private float gunAmmoCapacity;

   [SerializeField] private float remainingAmmo;

    public string currentGun = "None";

void Start ()
{
    stats = gameObject.GetComponent<GunStats>();

}
    // Update is called once per frame
    void Update()
    {   // Fire1 is a default button set by unity, and if not manually changed, it's set to Mouse 1/left Control
     if (Input.GetButtonDown("Fire1"))
     {
        if (gunRange == 0)
        {Debug.LogWarning("Player Has no weapon 'equipped'");}
        else{
        if (gunIsAuto == true)
        {
            StartCoroutine(fullAutoFire());
            isFiringGun = true;
        }
        else if (gunIsAuto == false)
        {
            Shoot();
        }
        }

     } 
     if (Input.GetButtonUp("Fire1"))
     {
        isFiringGun = false;
     }

     if (Input.GetKeyUp(KeyCode.R))
     {
        reload();
     }
    }

    private IEnumerator fullAutoFire()
    {
        Shoot();
        yield return new WaitForSeconds(gunFireRate);
        if (isFiringGun == true)
        {
            StartCoroutine(fullAutoFire());
        }
        else if (isFiringGun == false)
        {}
    }



    private void Shoot()
    {
 
        //  When the shoot function is called, shoots out a raycast from the player's camera, with the distance of the "range" value
        //  (this can be changed by changing the playerCam and assigning it to another object, such as a gun, if you want the "bullet" to come from an actual gun)
        //  Stores the info from the object in the private "hitInfo" variable, which can then be used to do things relating to the object hit, such as debugging the name,
        //  or doing math to deal damage
        RaycastHit hitInfo;
        if(remainingAmmo > 0)
        { 
            source.PlayOneShot(clip);
            remainingAmmo--;
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
        else
        {Debug.Log("No ammo left, reload required!");}

    }




    public void getGunStats()
    {
        GunStats transferStats;
        transferStats = gameObject.GetComponent<GunStats>();
        gunDamage = transferStats.damage;
        gunRange = transferStats.range;
        gunIsAuto = transferStats.isGunFullAuto;
        gunAmmoCapacity = transferStats.ammoCapacity;
        remainingAmmo = gunAmmoCapacity;
        currentGun = transferStats.gunName;
        gunFireRate = transferStats.fireRate;
        
    }

    private void reload()
    {
        remainingAmmo = gunAmmoCapacity;
        Debug.Log("Gun Reloaded");
    }

}
}


