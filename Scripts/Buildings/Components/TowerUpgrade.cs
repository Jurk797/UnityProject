using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class TowerUpgrade : MonoBehaviour, IUpgradable
{
    public TowerLevels[] levels;

    public int currentLevel = 0;

    HpManager hpManager;
    AttackManager attackManager;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Awake()
    {
        attackManager = GetComponent<AttackManager>();
        hpManager = GetComponent<HpManager>();
    }

    private void OnEnable()
    {
        levelUp(0);
    }

    public bool Upgrade()
    {
        if (levels.Length > currentLevel + 1)
        {
            if (GoldManager.instance.Gold >= levels[currentLevel + 1].cost)
            {
                GoldManager.instance.Gold -= levels[currentLevel + 1].cost;
                levelUp(currentLevel + 1);
                return true;
            }
        }
        return false;
    }

    private void levelUp(int level)
    {
        spriteRenderer.sprite = levels[level].sprite;
        hpManager.HpMax = levels[level].hpMax;
        attackManager.Damage = levels[level].damage;
        attackManager.AttackSpeed = levels[level].attackSpeed;
        currentLevel = level;
    }

    public string GetPrice()
    {
        if (levels.Length > currentLevel + 1)
        {
            return levels[currentLevel + 1].cost.ToString();
        }
        else
        {
            return "Max";
        }
    }

    public int GetCurrentLevel()
    {
        return currentLevel + 1;
    }
}

