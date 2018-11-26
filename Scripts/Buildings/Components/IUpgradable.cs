using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradable
{
    string GetPrice();
    int GetCurrentLevel();

    bool Upgrade();
}
