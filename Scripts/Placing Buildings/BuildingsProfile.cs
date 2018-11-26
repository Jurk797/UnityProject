using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buildings/Profile")]
public class BuildingsProfile : ScriptableObject
{
    public int idForSpawn;
    public Vector2 size;
    public string nameKey;
    public string descriptionKey;
    public Sprite Icon;
    public Sprite BuildingView;
    public float activeRadius;
    public int Price;
}
