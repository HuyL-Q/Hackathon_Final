using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public class MapGenerator : MonoBehaviour
{
    public GameObject MapTile;

    private List<GameObject> mapTiles = new List<GameObject>();
    private List<GameObject> pathTiles = new List<GameObject>();


    public GameObject startTile;
    public GameObject endTile;

    public Color pathColor;
    const string path = @"Assets/JSON/GenMap.json";//fix json path
    public Color startColor;
    public Color endColor;
    public Color towerColor;

    private void Start()
    {
        generateMap();
    }

    public static int[,] JSONConverter(string path)
    {
        //Open the stream and read it back.  
        //save
        //var object_string = JsonConvert.SerializeObject(array);
        //File.WriteAllText(path, object_string);
        int[,] arr2 = JsonConvert.DeserializeObject<int[,]>(File.ReadAllText(path));
        return arr2;
    }

    private void generateMap()
    {
        for (int i = 0; i < 64; i++)
        {
            for (int z = 0; z < 36; z++)
            {
                GameObject newTile = Instantiate(MapTile);
                if (array[z, i] != 0)
                {
                    switch (array[z, i])
                    {
                        case 1:
                            newTile.tag = "Map Tile (non-buildable)";
                            pathTiles.Add(newTile);
                            newTile.GetComponent<SpriteRenderer>().color = pathColor;
                            break;
                        case 2:
                            newTile.GetComponent<SpriteRenderer>().color = endColor;
                            break;
                        case 3:
                            newTile.GetComponent<SpriteRenderer>().color = towerColor;
                            break;
                        case 4:
                            newTile.tag = "Map Tile (buildable)";
                            newTile.GetComponent<SpriteRenderer>().color = towerColor;
                            break;
                        case -1:
                            newTile.GetComponent<SpriteRenderer>().color = startColor;
                            break;
                    }
                }
                if (newTile.CompareTag("Map Tile (buildable)"))
                {
                    newTile.AddComponent<BoxCollider2D>();
                    newTile.AddComponent<TileCheck>();
                    BoxCollider2D collider = newTile.GetComponent<BoxCollider2D>();
                    collider.size = new Vector2(collider.size.x * 3.3f, collider.size.y * 3.3f);
                }
                mapTiles.Add(newTile);
                newTile.transform.position = new Vector2((-32f + 0.5f + i) / 3.6f, (18f - 0.5f - z) / 3.6f);
            }
        }
    }
    int[,] array = JSONConverter(path);
}
