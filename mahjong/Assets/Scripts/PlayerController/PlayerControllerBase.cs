using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//提供基本(本地跟其他三位玩家)都有的基本操作
public class PlayerControllerBase : MonoBehaviour
{
    //private HandTilesAreaController _handTiles;    
    [SerializeField] private FlowerTileAreaController _flowerTileAreaController;
    [SerializeField] private MeldsAreaController _meldsAreaController;
    [SerializeField] private PlayerInfoPlateController _playerInfoPlateController;    


    public TileSuits[] FlowerTileSuits { get { return _flowerTileAreaController.GetTileSuits(); } }
    //public TileSuit[] MeldTilesuits { get { return _meldsAreaController.TilesSuits; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void AddHandTile(TileSuits tileSuit) { }
    public virtual void AddDrawedTile(TileSuits tileSuit) { }
               
    public void AddFlowerTile(TileSuits tileSuit)
    {
        _flowerTileAreaController.AddTile(tileSuit);
    }
    public void AddMeldTile(MeldTypes meldType,List<TileSuits> tileSuitsList)
    {
        _meldsAreaController.AddMeld(meldType,tileSuitsList);
    }
    public virtual void RemoveHandTile(TileSuits tileSuit) { }
    public virtual void RemoveDrawedTile(TileSuits tileSuit) { }

    public virtual void SetSeatInfo(SeatInfo seatInfo)
    {
        _playerInfoPlateController.SetUserName(seatInfo.Nickname);
        _playerInfoPlateController.SetWindPosision(seatInfo.DoorWind.ToString());

    }
}
