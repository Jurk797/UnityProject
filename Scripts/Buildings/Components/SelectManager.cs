using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    PoolObject pool;
    UpgradeManager upgradeManager;
    [SerializeField] SpriteRenderer radius;

    private void Awake()
    {
        pool = GetComponent<PoolObject>();
        upgradeManager = GetComponent<UpgradeManager>();
    }

    /// <summary>
    /// при нажатии на здание передаем его в менеджер выбора зданий
    /// </summary>
    private void OnMouseUp()
    {
        SelectedBuildingManager.instance.OnClick(this);
    }

    public void btnRemove()
    {
        DontShowRadius();
        BuildingsList.instance.buildings.Remove(gameObject);
        pool.ReturnToPool();
    }

    public void btnUpgrade()
    {
        upgradeManager.BtnLevelUp();
    }

    public int GetCurrentLevel()
    {
        return upgradeManager.GetCurrentLevel();
    }

    public string GetPrice()
    {
        return upgradeManager.GetPrice();
    }

    public void ShowRadius()
    {
        if (radius != null)
        radius.enabled = true;
    }

    public void DontShowRadius()
    {
        if (radius != null)
            radius.enabled = false;
    }
}
