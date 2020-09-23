using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerWeaponManager : MonoBehaviour
{
    public float ReloadTime;
    public int AmmoPoolSize;
    public int CurrentAmmo;
    public float DelayBetweenShots;
    public float BulletSpeed;
    public GameObject ProjectilePrefab;
    public Transform ShootPoint;
    public float ProjectileSpreadAngle;
    
    //public UnityAction OnShoot;
   
    private PlayerInputHandler inputHandler;
    private float lastTimeShot;
    private bool IsReloading;

    // Start is called before the first frame update
    void Start()
    {
        CurrentAmmo = AmmoPoolSize; //automatically set player's ammo as full at the start
        inputHandler = GetComponent<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
    
    	if (inputHandler.GetFireInputHeld()) {
      	   // TryShoot();
        }
      
        //The "!IsReloading" makes sure that the coroutine doesn't happen multiple times during a reload 
        if (!IsReloading && (inputHandler.GetReloadWeaponHeldDown() || CurrentAmmo <= 0)) {
            StartCoroutine(ReloadWeapon());
            IsReloading = true;
        }
    
    
        
    }
    /*
    void TryShoot() 
    {
    
    	// Check if able to shoot
    	if (!IsReloading && CurrentAmmo > 0 && lastTimeShot + DelayBetweenShots < Time.time) {
      	// decrease ammo and shoot
        // For now, projectiles shoot straight forward, no spread yet
        Vector2 shootDirection = inputHandler.GetLookInput();
        GameObject projectile = Instantiate(ProjectilePrefab, ShootPoint.position, Quaternion.LookRotation(shootDirection, Vector2.up), 
        		this.gameObject.transform);
        // Give velocity to the projectile
        projectile.GetComponent<Rigidbody2D>().AddForce(shootDirection, ForceMode2D.Impulse);
      
      	// invoke OnShoot
        if (OnShoot != null) 
        {
        	OnShoot.Invoke();
        }
        
      }
    
    }
    
    */
    
    
    //"IEnumerator" indicates that this function is a coroutin
    IEnumerator ReloadWeapon() 
    {
    	
        Debug.Log("Test to make sure reload function gets activated when needed");
        

        //***initiate reload animation somehow***

        //official coroutine code - function is paused for "Reload Time" amount
        yield return new WaitForSeconds(ReloadTime);
        CurrentAmmo = AmmoPoolSize;
        IsReloading = false; //reset to false once done reloading

      
        /* I think this code would also work
    	float TimeOfLastReload = Time.time;
        while (Time.time < TimeOfLastReload + ReloadTime) {
            IsReloading = true;
        }
        IsReloading = false;
			*/
      
    
    
    }
    
    
    
    
    
    
    
    
    
    
    //butt 
    //poop
    
}
