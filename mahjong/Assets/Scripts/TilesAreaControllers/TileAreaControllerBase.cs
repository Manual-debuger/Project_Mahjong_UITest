using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TileAreaControllerBase : MonoBehaviour,IInitiable,IReturnTileSuitsAble
{
    [SerializeField]
    protected List<TileComponent> _TilesComponents = new List<TileComponent>();
    protected int TileCount = 0;    
    // Start is called before the first frame update
    void Start()
    {
        Init();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public virtual void AddTile(TileSuits tileSuit)
    {
        _TilesComponents[TileCount].TileSuit = tileSuit;
        _TilesComponents[TileCount].Appear();
        //_TilesComponents[TileCount].ShowTileFrontSide();
        TileCount++;
    }
    public virtual void Init()
    {
        foreach (TileComponent tile in _TilesComponents)
        {
            tile.Init();
        }
        TileCount= 0;
    }
    protected bool IsFlowerTile(TileSuits tileSuit)
    {
        return (tileSuit>=TileSuits.f1 && tileSuit <= TileSuits.f8);
    }
    protected bool IsNormalTile(TileSuits tileSuit)
    {
        return (tileSuit>=TileSuits.c1 && tileSuit <= TileSuits.o7);
    }

    public virtual void SetTiles(List<TileSuits> tileSuits)
    {
        Init();
        foreach(var tileSuit in tileSuits)
        {
            AddTile(tileSuit);
        }
    }
    public virtual void UpdateTiles(List<TileSuits> tileSuits)
    {
        for(int i=0;i<Math.Max(tileSuits.Count,this.TileCount);i++)
        {
            if(i>tileSuits.Count)
            {
                _TilesComponents[i].Disappear();
            }
            else if (i>this.TileCount)
            {
                _TilesComponents[i].TileSuit = tileSuits[i];
                _TilesComponents[i].Appear();
            }
            else
            {
                if (tileSuits[i] != _TilesComponents[i].TileSuit)
                {
                    _TilesComponents[i].TileSuit = tileSuits[i];
                    _TilesComponents[i].Appear();
                }
            }
        }
        this.TileCount=tileSuits.Count;
    }
    public TileSuits[] GetTileSuits()
    {
        TileSuits[] tileSuitsList = new TileSuits[TileCount];
        foreach (var tile in _TilesComponents)
        {
            tileSuitsList[TileCount] = tile.TileSuit;
        }
        return tileSuitsList;
    }
}
