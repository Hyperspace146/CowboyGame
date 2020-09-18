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

    public int _attack;     // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF
    public int _defense;    // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF
    public int _speed;      // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF
    public int _money;      // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF
    public int _bounty;     // ONLY TEMPORARILY PUBLIC FOR DEBUGGING PURPOSES, REMEMBER TO TURN OFF

    void Start()
    {
        _attack = BaseAttack;
        _defense = BaseDefense;
        _speed = BaseSpeed;
        _money = InitialMoney;
        _bounty = InitialBounty;
    }

    public void ChangeAttackStat(int value)
    {
        _attack += value;
        if (_attack < 1)
        {
            _attack = 1;
        }
    }

    public void ChangeDefenseStat(int value)
    {
        _defense += value;
        if (_defense < 1)
        {
            _defense = 1;
        }
    }

    public void ChangeSpeedStat(int value)
    {
        _speed += value;
        if (_speed < 1)
        {
            _speed = 1;
        }
    }

    // Returns false and does not allow the change if it would lead to a negative sum of money
    public bool ChangeMoneySum(int value)
    {
        if (_money + value > 0)
        {
            _money += value;
            return true;
        }
        return false;
    }

    public void ChangeBounty(int value)
    {
        _bounty += value;
        if (_bounty < 0)
        {
            _bounty = 0;
        }
    }

    public void ResetStatsToDefault()
    {
        _attack = BaseAttack;
        _defense = BaseDefense;
        _speed = BaseSpeed;
        _money = InitialMoney;
        _bounty = InitialBounty;
    }
}
