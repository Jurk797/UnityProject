using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : MonoBehaviour
{
    private int goldInSec;

    public int GoldInSec
    {
        set
        {
            goldInSec = value;
        }
    }

    private void OnEnable()
    {
        InvokeRepeating("TakeGold", 1, 1);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void TakeGold()
    {
        GoldManager.instance.Gold += goldInSec;
    }
}
