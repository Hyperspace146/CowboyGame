using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInputHandler)]
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
        inputHandler = GetComponent<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        if (inputHandler.GetFireInputHeld())
        {
            TryShoot();
        }

        //add ReloadWeapon() to inputhandler
        if (inputHandler.GetReloadInputDown())
        {
            ReloadWeapon();
        }



    }

    void TryShoot()
    {

        // Check if able to shoot
        if (!IsReloading && CurrentAmmo > 0 && lastTimeShot + DelayBetweenShots < Time.time)
        {
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




    //I think this should be a coroutine
    void ReloadWeapon()
    {

        //initiate reload animation somehow***

        float TimeOfLastReload = Time.time;

        while (Time.time < TimeOfLastReload + ReloadTime)
        {
            IsReloading = true;
        }

        IsReloading = false;




    }










    //butt 
    //poop

}
