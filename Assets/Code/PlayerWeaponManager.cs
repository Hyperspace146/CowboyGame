using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerWeaponManager : MonoBehaviour
{
    [Tooltip("The time in seconds it takes to complete a full clip reload")]
    public float ReloadTime;
    [Tooltip("Max number of times the gun can be shot with one clip")]
    public int ClipSize;
    [Tooltip("The current amount of shots available in the current clip")]
    public int CurrentAmmo;
    [Tooltip("The time in seconds that you must wait in before you can shoot again")]
    public float DelayBetweenShots;
    [Tooltip("Multiplier for the speed")]
    public float ProjectileSpeed;
    [Tooltip("How much damage the weapon's projectiles will do")]
    public int Damage;
    [Tooltip("The time in seconds before the projectile despawns")]
    public float TimeBeforeProjectileDespawns;
    [Tooltip("The projectile to be spawned")]
    public GameObject ProjectilePrefab;
    [Tooltip("Where the projectiles will be shot from")]
    public Transform ShootPoint;
    [Tooltip("The angle in degrees representing the total width of the weapon's inaccuracy spread")]
    public float ProjectileSpreadAngle;

    public UnityAction OnShoot;
    public UnityAction<GameObject> OnProjectileDespawn;

    private PlayerInputHandler inputHandler;
    private float lastTimeShot;
    private bool isReloading;

    // Start is called before the first frame update
    void Start()
    {
        CurrentAmmo = ClipSize; //automatically set player's ammo as full at the start
        inputHandler = GetComponent<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        //The "!IsReloading" makes sure that the coroutine doesn't happen multiple times during a reload 
        if (!isReloading && (inputHandler.GetReloadWeaponHeldDown() || CurrentAmmo <= 0)) {
            StartCoroutine(ReloadWeapon());
        }

        if (inputHandler.GetFireInputHeld())
        {
            TryShoot();
        }
    }


    void TryShoot()
    {
        // Shoot if able to (not reloading, has ammo, and the time delay between shots has passed)
        if (!isReloading && CurrentAmmo > 0 && lastTimeShot + DelayBetweenShots < Time.time)
        {
            // Decrease ammo by the amount of projectiles shot
            CurrentAmmo -= 1;

            // For now, projectiles shoot straight forward, no spread yet
            Vector2 shootDirection = GetShootDirectionWithinSpread();
            GameObject projectile = Instantiate(ProjectilePrefab, ShootPoint.position, 
                transform.rotation, this.gameObject.transform);
            projectile.GetComponent<ContactDamage>().Damage = Damage;

            // Begin the coroutine to have the projectile despawn after given amount of time
            StartCoroutine(DespawnProjectile(projectile));

            // Have collisions ignored between the projectile and the player that shot it
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), 
                projectile.GetComponent<Collider2D>());

            //Debug.DrawRay(ShootPoint.position, shootDirection, Color.red, 5, false);

            // Give velocity to the projectile
            projectile.GetComponent<Rigidbody2D>().velocity = shootDirection * ProjectileSpeed;

            // Invoke OnShoot for any additional events/effects we want to happen when we shoot
            if (OnShoot != null)
            {
                OnShoot.Invoke();
            }

            // Update last time shot to now
            lastTimeShot = Time.time;
        }
    }

    // Despawns the given projectile after certain amount of time, and triggers any events that 
    // should happen on despawn
    IEnumerator DespawnProjectile(GameObject projectile)
    {
        yield return new WaitForSeconds(TimeBeforeProjectileDespawns);
        if (OnProjectileDespawn != null)
        {
            OnProjectileDespawn.Invoke(projectile);
        }
        Destroy(projectile);
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
        isReloading = true;
        // Wait for the specified reload time before refilling the clip
        yield return new WaitForSeconds(ReloadTime);
        CurrentAmmo = ClipSize;
        isReloading = false;
    }

}
