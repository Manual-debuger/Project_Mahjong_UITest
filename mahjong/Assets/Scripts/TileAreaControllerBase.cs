using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEditorInternal;
using UnityEngine;

interface IPopTileAble
{
    public void PopLastTile();
}
interface IDeleteTileAble
{
    public void DeleteTile(TileSuits tileSuit);
}

public class TileAreaControllerBase : MonoBehaviour
{
    protected List<TileComponent> _TilesComponents = new List<TileComponent>();
    protected int TileCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void AddTile(TileSuits tileSuit)
    {
        _TilesComponents[TileCount].TileSuit = tileSuit;
        _TilesComponents[TileCount].Appear();
        _TilesComponents[TileCount].ShowTileFrontSide();
        TileCount++;
    }
    public virtual void Init()
    {
        foreach (TileComponent tile in _TilesComponents)
        {
            tile.Disappear();
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
    
}
