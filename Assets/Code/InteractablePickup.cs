using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
public class InteractablePickup : MonoBehaviour
{
    [Tooltip("The amount of points the player's max health stat will increase by on pickup")]
    public int MaxHealthBuff;
    [Tooltip("The amount of points the player's health will refill by on pickup")]
    public int HealthRegained;
    [Tooltip("The amount of points the player's attack stat will increase by on pickup")]
    public int AttackStatBuff;
    [Tooltip("The amount of points the player's defense stat will increase by on pickup")]
    public int DefenseStatBuff;
    [Tooltip("The amount of points the player's speeds stat will increase by on pickup")]
    public int SpeedStatBuff;
    [Tooltip("The amount of dollars the player will lose or receive on pickup")]
    public int MoneyAmount;

    private void Start()
    {
        // Subscribe to OnInteract so that when the player interacts with the pickup, we can change
        // their stats
        GetComponent<Interactable>().OnInteract += ChangePlayerStats;
    }

    private void ChangePlayerStats(GameObject player)
    {
        Health playerHealth = player.GetComponent<Health>();
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // Apply all stat/health changes if non-zero
        if (MaxHealthBuff != 0)
        {
            playerHealth.ChangeMaxHealth(MaxHealthBuff);
        }
        if (HealthRegained != 0)
        {
            playerHealth.ChangeHealth(HealthRegained);
        }
        if (AttackStatBuff != 0)
        {
            playerStats.ChangeAttackStat(AttackStatBuff);
        }
        if (DefenseStatBuff != 0)
        {
            playerStats.ChangeDefenseStat(DefenseStatBuff);
        }
        if (SpeedStatBuff != 0)
        {
            playerStats.ChangeSpeedStat(SpeedStatBuff);
        }
        if (MoneyAmount != 0)
        {
            playerStats.ChangeMoneySum(MoneyAmount);
        }
        Destroy(this.gameObject);
    }
}
