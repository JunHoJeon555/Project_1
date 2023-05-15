using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHP = 100;
    int currentHP;

    int attackFailedDamage = 10;
    
    bool attackFailed = false;

    bool attack = false; 
    



    private void Awake()
    {
        currentHP = maxHP;
    }





}
