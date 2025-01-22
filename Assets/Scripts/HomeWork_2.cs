using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWork_2 : MonoBehaviour
{
    public int baseDamage = 0;
    public float multiplier = 0f;
    bool isTrue;

    private void Start()
    {
        Debug.Log(baseDamage);
        Debug.Log(multiplier);
        Debug.Log(isTrue);
        DealDamage();
    }
    public void DealDamage() 
    {
        int damage = baseDamage * (int)multiplier;
        Debug.Log($"нанесенный урон {damage}");           
    }
}
