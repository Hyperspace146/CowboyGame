using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class BloodParticlesOnHit : MonoBehaviour
{
    [Tooltip("The blood particle system prefab to be spawned when damage is taken.")]
    public GameObject BloodParticleSystem;

    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        health.OnHealthChange += (SpawnBloodParticles);
    }

    void SpawnBloodParticles(int healthChange)
    {
        // If the user took damage (health change negative), spawn the particles
        if (healthChange < 0)
        {
            Instantiate(BloodParticleSystem, this.transform.position, this.transform.rotation);
        }
    }
}
