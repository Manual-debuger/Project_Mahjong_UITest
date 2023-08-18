using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

//提供基本(本地跟其他三位玩家)都有的基本操作
public class PlayerControllerBase : MonoBehaviour,IInitiable
{
    //private HandTilesAreaController _handTiles;    
    [SerializeField] private FlowerTileAreaController _flowerTileAreaController;
    [SerializeField] private MeldsAreaController _meldsAreaController;
    [SerializeField] private PlayerInfoPlateController _playerInfoPlateController;    


    public TileSuits[] FlowerTileSuits { get { return _flowerTileAreaController.GetTileSuits(); } }
    //public TileSuit[] MeldTilesuits { get { return _meldsAreaController.TilesSuits; } }

    void Awake()
    {
        Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void AddHandTile(TileSuits tileSuit) { Debug.LogWarning("Must override this function AddHandTile, Do NOT Use this base function"); }
    public virtual void AddDrawedTile(TileSuits tileSuit) { Debug.LogWarning("Must override this function AddDrawedTile, Do NOT Use this base function"); }
               
    public void AddFlowerTile(TileSuits tileSuit)
    {
        _flowerTileAreaController.AddTile(tileSuit);
    }
    public void AddMeldTile(MeldTypes meldType,List<TileSuits> tileSuitsList)
    {
        _meldsAreaController.AddMeld(meldType,tileSuitsList);
    }
    public virtual void RemoveHandTile(TileSuits tileSuit) { Debug.LogWarning("Must override this function RemoveHandTile, Do NOT Use this base function"); }
    public virtual void RemoveDrawedTile(TileSuits tileSuit) {Debug.LogWarning("Must override this function RemoveDrawedTile, Do NOT Use this base function"); }

    public virtual void SetSeatInfo(SeatInfo seatInfo)
    {
        _playerInfoPlateController.SetUserName(seatInfo.Nickname);
        _playerInfoPlateController.SetWindPosision(seatInfo.DoorWind.ToString());
        _flowerTileAreaController.SetTiles(seatInfo.FlowerTile);
    }
    public virtual void SetHandTiles(List<TileSuits> tileSuits)
    {
        Debug.LogWarning("Must override this function SetHandTiles, Do NOT Use this base function");
    }
    public virtual void SetHandTiles(int tileCount)
    {
        Debug.LogWarning("Must override this function SetHandTiles, Do NOT Use this base function");
    }

    public virtual void Init()
    {
        _flowerTileAreaController.Init();
        _meldsAreaController.Init();       
    }
}
