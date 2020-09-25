using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public UnityAction OnShoot;
    
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

        //The "!IsReloading" makes sure that the coroutine doesn't happen multiple times during a reload 
        if (!IsReloading && (inputHandler.GetReloadWeaponHeldDown() || CurrentAmmo <= 0)) {
            StartCoroutine(ReloadWeapon());
            IsReloading = true;
        }

        if (inputHandler.GetFireInputHeld())
        {
            TryShoot();
        }




    }
    


    void TryShoot()
    {

        // Shoot if able to (not reloading, has ammo, and has waited the delay between shots)
        if (!IsReloading && CurrentAmmo > 0 && lastTimeShot + DelayBetweenShots < Time.time)
        {
            // Decrease ammo by the amount of projectiles shot
            CurrentAmmo -= 1;

            // For now, projectiles shoot straight forward, no spread yet
            Vector2 shootDirection = GetShootDirectionWithinSpread();
            GameObject projectile = Instantiate(ProjectilePrefab, ShootPoint.position, transform.rotation,
                    this.gameObject.transform);
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), projectile.GetComponent<Collider2D>());

            Debug.DrawRay(ShootPoint.position, shootDirection, Color.red, 5, false);

            // Give velocity to the projectile
            projectile.GetComponent<Rigidbody2D>().velocity = shootDirection * BulletSpeed;

            // Invoke OnShoot for any additional events/effects we want to happen
            if (OnShoot != null)
            {
                OnShoot.Invoke();
            }

            // Update last time shot to now
            lastTimeShot = Time.time;
        }

    }


    // Returns a random normalized vector towards the current aim direction but within the random 
    // projectile spread angle
    Vector2 GetShootDirectionWithinSpread()
    {
        // Get the vector pointing from the gun to the crosshair by subtracting mouse position and
        // the shoot point (gun) position
        Vector2 currentAimVector = (inputHandler.GetMousePosition() - 
            (Vector2) Camera.main.WorldToScreenPoint(ShootPoint.position));

        // Turn that vector into an angle
        float currentAimAngle = Mathf.Atan2(currentAimVector.y, currentAimVector.x) * Mathf.Rad2Deg;
        
        // Get a random angle (within the given spread) near the current aim angle 
        float randomAngleWithinSpread = Random.Range(currentAimAngle + (ProjectileSpreadAngle / 2), 
            currentAimAngle - (ProjectileSpreadAngle / 2)) * Mathf.Deg2Rad;

        // Turn that angle back into a vector
        return new Vector2(Mathf.Cos(randomAngleWithinSpread), Mathf.Sin(randomAngleWithinSpread));
    }
    
    
    
    
    //"IEnumerator" indicates that this function is a coroutine
    IEnumerator ReloadWeapon() 
    {

        //initiate reload animation somehow***

        float TimeOfLastReload = Time.time;

        //coroutine line
        yield return new WaitForSeconds(ReloadTime);


        /* this code is probably also ok
        while (Time.time < TimeOfLastReload + ReloadTime)
        {
            IsReloading = true;
        }
        */

        IsReloading = false;




    }

}
