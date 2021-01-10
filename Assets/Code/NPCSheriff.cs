using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class NPCSheriff : MonoBehaviour
{
    void Start()
    {
        GetComponent<Interactable>().OnInteract += TradeCorpseWithPlayer;
    }
    
    void TradeCorpseWithPlayer(GameObject player)
    {
        InteractableCorpse corpse = player.GetComponent<PlayerCharacterController>().CorpseBeingCarried;
        if (corpse != null)
        {
            Debug.Log("thnx 4 corpse");

            PlayerStats playerStats = player.GetComponent<PlayerStats>();

            // Add the corpse's bounty to the player's pocket money
            playerStats.ChangeMoneySum(corpse.GetComponent<PlayerStats>().bounty);

            // Raise the player's bounty?
            playerStats.ChangeBounty(corpse.GetComponent<PlayerStats>().bounty / 2);

            // Delete the corpse object
            Destroy(corpse);
        }
    }
}
