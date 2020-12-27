using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [Tooltip("The time in seconds the player waits to respawn")]
    public float RespawnTime;
    [Tooltip("Respawn Locations")]
    public Transform[] RespawnLocations;

    // Respawns the player after waiting the respawn time. Resets all cooldowns, health 
    // refilled, other stat changes tbd
    public void RespawnPlayer(GameObject player)
    {
        StartCoroutine(WaitThenRespawnPlayer(player));
    }

    IEnumerator WaitThenRespawnPlayer(GameObject player)
    {
        yield return new WaitForSeconds(RespawnTime);
        // TODO: respawn player at one of the respawn locations with cooldowns and stats lowered/reset
        player.transform.position = RespawnLocations[Random.Range(0, RespawnLocations.Length)].position;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<PlayerStats>().ResetStatsToDefault();
        player.GetComponent<Health>().RefillAllHealth();
    }
}
