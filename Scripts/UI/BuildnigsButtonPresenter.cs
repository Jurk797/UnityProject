using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildnigsButtonPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Image icon;
    [SerializeField] private Button button;

    public void Present(BuildingsProfile profile)
    {
        icon.sprite = profile.Icon;
        price.text = profile.Price.ToString();

        button.onClick.AddListener(() =>
        {
            if (GoldManager.instance.Gold >= profile.Price) {
                GoldManager.instance.Gold -= profile.Price;
                PlaceLogic.instance.SelectPlaceBuilding(profile);
            }
        });
    }


}
