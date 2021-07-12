using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class NPCBanker : MonoBehaviour
{
    private Dictionary<GameObject, int> bank;

    // Start is called before the first frame update
    void Start()
    {
        bank = new Dictionary<GameObject, int>();
        GetComponent<Interactable>().OnInteract += StoreMoneyInBank;
    }

    // Transfer the player's money into the bank's storage
    void StoreMoneyInBank(GameObject player)
    {
        print("woo");
        if (!bank.ContainsKey(player))
        {
            bank.Add(player, 0);
        }

        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        bank[player] += playerStats.money;
        playerStats.ChangeMoneySum(-playerStats.money);
    }
}
