using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���Ѱ�(���a���L�T�쪱�a)�������򥻾ާ@
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
