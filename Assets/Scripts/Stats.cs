using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Stats
{
    private int health;
    public int maxHP=5;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = Mathf.Clamp(value,0,maxHP);
        }
    }
    public void SetHealth()
    {
        Health = maxHP;
    }
}
