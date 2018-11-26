using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLogic : Singleton<PlaceLogic>
{
    [SerializeField] Transform activeRadius;
    private BuildingsProfile currentPlaceBuilding;
    private SpriteRenderer spriteRenderer;

    private List<PlacePrefab> placeBlocks = new List<PlacePrefab>();

    private Transform regionToPlace;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        regionToPlace = GetComponent<Transform>();
    }

    public void SelectPlaceBuilding(BuildingsProfile profile)
    {
        if (currentPlaceBuilding != null)
        {
            DeleteGhost();
        }

        // отображение здание перед постройкой и просчет его позиций
        currentPlaceBuilding = profile;
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = profile.Icon;
        Vector3 sizeRadius = Vector3.zero;
        sizeRadius.x = profile.activeRadius;
        sizeRadius.y = profile.activeRadius;
        sizeRadius.z = 1;
        activeRadius.localScale = sizeRadius;

        float offsetX = profile.size.x / 2 - 0.5f;
        float offsetY = profile.size.y / 2 - 0.5f;

        for (int x = 0; x < profile.size.x; x++)
        {
            for (int y = 0; y < profile.size.y; y++)
            {
                Vector2 newPos = regionToPlace.position;
                newPos.x += offsetX - x;
                newPos.y += offsetY - y;
                PlacePrefab cube = PoolManager.GetObject(0, newPos, Quaternion.identity).GetComponent<PlacePrefab>();
                cube.transform.SetParent(regionToPlace);
                placeBlocks.Add(cube);
            }
        }
    }


    private void DeleteGhost()
    {
        currentPlaceBuilding = null;
        spriteRenderer.enabled = false;
        activeRadius.localScale = Vector3.forward;
        foreach (var block in placeBlocks)
        {
            block.GetComponent<PoolObject>().ReturnToPool();
        }
    }

    private void Update()
    {
        if (currentPlaceBuilding != null)
        {
            if (Input.GetMouseButtonDown(0))
            {  
                // при клике проверка на возможность постройки
                foreach (var block in placeBlocks)
                {
                    if (!block.isEmpty)
                    {
                        return;
                    }
                }
                BuildingsList.instance.buildings.Add(PoolManager.GetObject(currentPlaceBuilding.idForSpawn, regionToPlace.position, Quaternion.identity));
                DeleteGhost();
            }
            else
            {
                // апдейт позиции
                Vector2 newPos;
                if (currentPlaceBuilding.size.x % 2 == 0)
                {
                    newPos.x = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + 0.5f) - 0.5f;
                }
                else
                {
                    newPos.x = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
                }
                if (currentPlaceBuilding.size.y % 2 == 0)
                {
                    newPos.y = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y + 0.5f) - 0.5f;
                }
                else
                {
                    newPos.y = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                }
                regionToPlace.position = newPos;
            }
        }
    }
}
