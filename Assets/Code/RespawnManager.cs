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

    IEnumerator WaitThenRespawnPlayer(GameObject characterPrefab)
    {
        yield return new WaitForSeconds(RespawnTime);

        Vector3 respawnLocation = RespawnLocations[Random.Range(0, RespawnLocations.Length)].position;
        Instantiate(characterPrefab, respawnLocation, Quaternion.identity, GameObject.Find("Adrian Stuff").transform);
    }
}
