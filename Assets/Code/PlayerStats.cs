using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public int BaseAttack;
    public int BaseDefense;
    public int BaseSpeed;
    public int InitialMoney;
    public int InitialBounty;

    // These stats can be public read, but can only be set within this class. To change these 
    // values from other scripts, use the below methods.
    public int attack { get; private set; }     
    public int defense { get; private set; }   
    public int speed { get; private set; }    
    public int money { get; private set; }      
    public int bounty { get; private set; }

    public event UnityAction OnStatChange;

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

        if (OnStatChange != null)
        {
            OnStatChange.Invoke();
        }
    }

    public void ChangeDefenseStat(int value)
    {
        defense += value;
        if (defense < 1)
        {
            defense = 1;
        }

        if (OnStatChange != null)
        {
            OnStatChange.Invoke();
        }
    }

    public void ChangeSpeedStat(int value)
    {
        speed += value;
        if (speed < 1)
        {
            speed = 1;
        }

        if (OnStatChange != null)
        {
            OnStatChange.Invoke();
        }
    }

    // Returns false and does not deduct money if it would lead to a negative sum of money
    public bool ChangeMoneySum(int value)
    {
        if (money + value >= 0)
        {
            money += value;
            if (OnStatChange != null)
            {
                OnStatChange.Invoke();
            }
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

        if (OnStatChange != null)
        {
            OnStatChange.Invoke();
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
