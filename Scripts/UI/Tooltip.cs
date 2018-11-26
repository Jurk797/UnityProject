using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    #region Singleton
    public static Tooltip instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("Tooltip уже существует");
    }
    #endregion

    [SerializeField] private TextMeshProUGUI tooltipText;

    public void TooltipText(string text)
    {
        tooltipText.text = text;
    }
}
