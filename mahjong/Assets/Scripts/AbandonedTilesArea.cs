using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Server as a model for the abandoned tiles area
public class AbandonedTilesArea : TileAreaControllerBase,IPopTileAble
{
    

    public override void AddTile(TileSuits tileSuit)
    {
        if(TileCount>24) { Debug.LogError("Error:AbandonedTilesArea.AddTile() TileCount>24"); return; }
        
        if(this.IsNormalTile(tileSuit))
        {
            base.AddTile(tileSuit);
        }
        else
        {
            Debug.LogError("Error:AbandonedTilesArea.AddTile() tileSuit is not flower");
            throw new System.Exception("Error:AbandonedTilesArea.AddTile() tileSuit is not flower");            
        }        
    }
    public void PopLastTile()
    {
        if(TileCount<0) 
        {
            Debug.LogError("Error:AbandonedTilesArea.DeleteTile() TileCount<=0"); 
            return;
        }
        else
        {           
            _TilesComponents[TileCount].Disappear();
            _TilesComponents[TileCount].ShowTileBackSide();
            TileCount--;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
