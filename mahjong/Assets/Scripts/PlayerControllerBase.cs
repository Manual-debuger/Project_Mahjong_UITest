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
    //public TileSuits[] MeldTilesuits { get { return _meldsAreaController.TilesSuits; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
