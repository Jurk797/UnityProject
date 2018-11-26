using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    IUpgradable upgrade;

    private void Awake()
    {
        upgrade = GetComponent<IUpgradable>();
    }

    public int GetCurrentLevel()
    {
      return  upgrade.GetCurrentLevel();
    }

    public string GetPrice()
    {
        return upgrade.GetPrice();
    }

    public bool BtnLevelUp()
    {
        return upgrade.Upgrade();
    }

}
