using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GunLogic;


// IMPORTANT NOTE!! 
// This script must be attatched to the same object as the "GunBase" script!
public class GunStats : MonoBehaviour
{


    public float damage;
    public float ammoCapacity;
    public float range;

    public float fireRate;
    public bool isGunFullAuto;
        public string gunName;
    GunBase gunBase;


    // Start is called before the first frame update
    void Start()
    {
        gunBase = gameObject.GetComponent<GunBase>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.L))
        {
            Revolver();
        }
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            AssaultRifle();
        }
        
    }


    public void Revolver()
    {
        gunName = "Revolver";
        damage = 25;
        ammoCapacity = 6;
        range = 100;
        isGunFullAuto = false;
        Debug.Log("Weapon Changed to Revolver!");
        gunBase.getGunStats();

        

        
    }

    public void AssaultRifle()
    {
        gunName = "Assault Rifle";
        damage = 20;
        ammoCapacity = 31;
        range = 100;
        isGunFullAuto = true;
        fireRate = 0.1f;
        Debug.Log("Weapon Changed to Assault Rifle!");
        gunBase.getGunStats();
    }


    // Below is the template for making your own weapon and stats.
    // All you need to do is to do is copy/paste the function template,
    // change the values to your desired values, and call the function
    //whenever you wish to change weapon
    // to change the stats of the gun effectively "swapping" the gun
    // the player is using.
   
    // NOTE 1: do NOT change "gunBase.getGunStats();"
    // that is the function that actually applies the stats to the gun in
    // the GunStats script
    // NOTE 2: fireRate is only required if isGunFUllAuto is true,
    // Fire rate is in seconds so 0.1f is equal to once every 0.1 seconds
    // NOTE 3: If fireRate is set to false, the gun will shoot as fast as  
    // you can click

   // public void WeaponName()
   // {
   //     damage = 20;
   //     ammoCapacity = 31;
   //     range = 100;
   //     isGunFullAuto = true;  
   //     fireRate = 0.1f;      
   //     Debug.Log("Message for Console");
   //     gunBase.getGunStats();
   // }



}