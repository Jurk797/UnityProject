using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TowerLevels
{
    // заменить на анимации
    public Sprite sprite;
    public float hpMax;
    public int damage;
    public float attackSpeed;
    public int cost;
}