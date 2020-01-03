﻿using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Objects.Tiles;
using Objects.Tiles.ConnectedTiles;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using TileLoc = Objects.Tiles.TileLoc;

public class GameMap : Singleton<GameMap>
{
    public TileMap tileMap;
    public ConnectedTileMap connectedTileMap;

    public void Start()
    {
        InitTileObjects();
        InitConnectedTileObjects();

        InitGameMapInteraction();

        GenerateFakeObjectAtRandomPost();


    }

    private void GenerateFakeObjectAtRandomPost()
    {
        TileLoc loc = new TileLoc(Random.Range(0, TileMap.SquaredMapSize), Random.Range(0, TileMap.SquaredMapSize));
        
        
        
        
    }

    private void InitGameMapInteraction()
    {
        GameMapInteraction gameMapInteraction = gameObject.AddComponent<GameMapInteraction>();
        gameMapInteraction.tileMap = tileMap;
        gameMapInteraction.connectedTileMap = connectedTileMap;
    }

    private void InitTileObjects()
    {
        tileMap = new GameObject("TileObjects").AddComponent<TileMap>();
        tileMap.transform.parent = transform;
    }

    private void InitConnectedTileObjects()
    {
        connectedTileMap = new GameObject("ConnectedTileObjects").AddComponent<ConnectedTileMap>();
        connectedTileMap.transform.parent = transform;
    }

    /**
     * Utility method used by both ConnectedTileObjects (paths) and TileObjects (other) to create a basic tile.
     */
    public GameObject CreateTileAt(TileLoc loc, Transform parent)
    {
        GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
        tile.name = "Ground Tile (" + loc.x + ", " + loc.y + ")";
        tile.transform.parent = parent;
        tile.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        tile.transform.localPosition = new Vector3(loc.x, 0, loc.y);
        return tile;
    }
}