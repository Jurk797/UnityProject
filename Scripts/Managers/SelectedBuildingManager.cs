using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SelectedBuildingManager : Singleton<SelectedBuildingManager>
{
    [SerializeField] TextMeshProUGUI cost;
    [SerializeField] TextMeshProUGUI currentLevel;
    [SerializeField] GameObject ManagerUI;
    [SerializeField] EventSystem eventSystem;

    SelectManager selected;

    public void OnClick(SelectManager selectable)
    {
        if (selected != null)
            Reset();

        ManagerUI.SetActive(true);

        selected = selectable;

        selectable.ShowRadius();

        UpdateUI();
    }

    void UpdateUI()
    {
        if (selected != null)
        {
            cost.text = selected.GetPrice();
            currentLevel.text = selected.GetCurrentLevel().ToString();
        }
    }

    public void OnButtonRemove()
    {
        if (selected != null)
        {
            selected.btnRemove();
            Reset();
        }
    }
    public void OnButtonUpdate()
    {
        if (selected != null)
        {
            selected.btnUpgrade();
            UpdateUI();
        }
    }

    public void Reset()
    {
        if (selected != null)
        {
            selected.DontShowRadius();
            selected = null;
            ManagerUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!eventSystem.IsPointerOverGameObject(-1))
            {
                Reset();
            }
        }
    }
}
