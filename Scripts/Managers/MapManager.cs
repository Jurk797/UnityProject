using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] Transform parent;
    [SerializeField] int size = 50;

   public Dictionary<Point, TileScript> Tiles;

    public int Size
    {
        get
        {
            return size;
        }
    }
    
    void Start()
    {
        Generate();
    }

    void Generate()
    {

        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                TileScript tile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity).GetComponent<TileScript>();
                tile.transform.SetParent(parent);
            }
        }
    }
}
