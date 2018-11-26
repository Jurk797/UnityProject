using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    [SerializeField] GameObject hpBar;
    [SerializeField] Image currentHPBar;

    public void DisplayHP(float percent)
    {
        if (percent == 1)
        {
            hpBar.SetActive(false);
        }
        else
        {
            hpBar.SetActive(true);
            currentHPBar.fillAmount = percent;
        }

    }
}
