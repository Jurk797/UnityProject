using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : Singleton<GoldManager>
{
    [SerializeField] TextMeshProUGUI goldUI;
    [SerializeField] int StartGold;
    private void Start()
    {
        goldUI.text = gold.ToString();
        Gold += StartGold;
    }

    private int gold = 0;

    public int Gold
    {
        get
        {
            return gold;
        }

        set
        {
            gold = value;
            goldUI.text = gold.ToString();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            Gold += 1000;
        }
    }


}
