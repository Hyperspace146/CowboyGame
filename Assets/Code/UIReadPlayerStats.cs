using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIReadPlayerStats : MonoBehaviour
{
    public TMPro.TextMeshProUGUI HealthTextComponent;
    public TMPro.TextMeshProUGUI AttackTextComponent;
    public TMPro.TextMeshProUGUI DefenseTextComponent;
    public TMPro.TextMeshProUGUI SpeedTextComponent;
    public TMPro.TextMeshProUGUI MoneyTextComponent;
    public TMPro.TextMeshProUGUI BountyTextComponent;

    public Health PlayerHealth;
    public PlayerStats PlayerStats;
    
    void Start()
    {
        //PlayerHealth.OnHealthChange += UpdateStatsUI;
        //PlayerStats.OnStatChange += UpdateStatsUI;
    }

    void Update()
    {
        HealthTextComponent.text = PlayerHealth.health + " / " + PlayerHealth.maxHealth;
        AttackTextComponent.text = PlayerStats.attack.ToString();
        DefenseTextComponent.text = PlayerStats.defense.ToString();
        SpeedTextComponent.text = PlayerStats.speed.ToString();
        MoneyTextComponent.text = PlayerStats.money.ToString();
        BountyTextComponent.text = PlayerStats.bounty.ToString();
    }
}
