using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuildingsPanel : MonoBehaviour
{

    private List<BuildingsProfile> _buildings;
    [SerializeField] private Transform parentForButtons;
    [SerializeField] private GameObject button;

    // автоматически подгружаем из ресурсов все префабы на панель постройки
    private void Awake()
    {
        _buildings = Resources.LoadAll<BuildingsProfile>("Buildings").ToList();

        foreach (var building in _buildings)
        {
            GameObject buttonGO = Instantiate(button, parentForButtons);
            buttonGO.GetComponent<BuildnigsButtonPresenter>().Present(building);
        }
    }
}
