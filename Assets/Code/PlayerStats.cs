using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int BaseAttack;
    public int BaseDefense;
    public int BaseSpeed;
    public int InitialMoney;
    public int InitialBounty;

    public int attack;     // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF
    public int defense;    // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF
    public int speed;      // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF
    public int money;      // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF
    public int bounty;     // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF

    void Start()
    {
        attack = BaseAttack;
        defense = BaseDefense;
        speed = BaseSpeed;
        money = InitialMoney;
        bounty = InitialBounty;
    }

    public void ChangeAttackStat(int value)
    {
        attack += value;
        if (attack < 1)
        {
            attack = 1;
        }
    }

    public void ChangeDefenseStat(int value)
    {
        defense += value;
        if (defense < 1)
        {
            defense = 1;
        }
    }

    public void ChangeSpeedStat(int value)
    {
        speed += value;
        if (speed < 1)
        {
            speed = 1;
        }
    }

    // Returns false and does not allow the change if it would lead to a negative sum of money
    public bool ChangeMoneySum(int value)
    {
        if (money + value > 0)
        {
            money += value;
            return true;
        }
        return false;
    }

    public void ChangeBounty(int value)
    {
        bounty += value;
        if (bounty < 0)
        {
            bounty = 0;
        }
    }

    public void ResetStatsToDefault()
    {
        attack = BaseAttack;
        defense = BaseDefense;
        speed = BaseSpeed;
        money = InitialMoney;
        bounty = InitialBounty;
    }
}
