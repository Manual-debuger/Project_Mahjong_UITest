using Assets.Scripts.UIScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour,IInitiable
{
    private static GameManager _instance;    

    public static GameManager Instance { get { return _instance; } }
    private int _playerIndex;
    [SerializeField] private AbandonedTilesAreaController _abandonedTilesAreaController;
    [SerializeField] private CentralAreaController _centralAreaController;
    private List<PlayerControllerBase> _playerControllers;
    [SerializeField] private InGameUIController _inGameUIController;
    [SerializeField] private AnimController _animController;
    [SerializeField] private AudioController _audioManager;
    [SerializeField] private API _api;

    public void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else if (_instance == null)
            _instance = this;

        _playerControllers = new List<PlayerControllerBase>
        {
            GameObject.Find("Main_Tiles").GetComponent<PlayerController>(),
            GameObject.Find("Player_Tiles E").GetComponent<CompetitorController>(),
            GameObject.Find("Player_Tiles N").GetComponent<CompetitorController>(),
            GameObject.Find("Player_Tiles W").GetComponent<CompetitorController>()
        };

        _inGameUIController.DiscardTileEvent += OnDiscardTileEvent;
        _inGameUIController.OnTileBeHoldingEvent += OnTileBeHoldingEvent;
        _inGameUIController.LeaveTileBeHoldingEvent += OnLeaveTileBeHoldingEvent;

        _api.RandomSeatEvent += OnRandomSeatEvent;
        _api.DecideBankerEvent += OnDecideBankerEvent;
        _api.OpenDoorEvent += OnOpenDoorEvent;
        _api.GroundingFlowerEvent += OnGroundingFlowerEvent;
        _api.PlayingEvent += OnPlayingEvent;
        _api.WaitingActionEvent += OnWaitingActionEvent;
        _api.PassEvent += OnPassActionEvent;
        _api.DiscardEvent += OnDiscardActionEvent;
        _api.ChowEvent += OnChowActionEvent;
        _api.PongEvent += OnPongActionEvent;
        _api.KongEvent += OnKongActionEvent;
        _api.DrawnEvent += OnDrawnActionEvent;
        _api.GroundingFlowerActionEvent += OnGroundingFlowerActionEvent;
    }

  
    public void Init()
    {
        throw new System.NotImplementedException();
    }
    // Start is called before the first frame update
    void Start()
    {       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region UI Event handle
    private void OnTileBeHoldingEvent(object sender, TileSuitEventArgs e)
    {
        _abandonedTilesAreaController.HighLightDiscardTiles(e.TileSuit);
    }
    private void OnLeaveTileBeHoldingEvent(object sender, TileSuitEventArgs e)
    {
        _abandonedTilesAreaController.UnHighLightDiscardTiles();        
    }


    public void OnDiscardTileEvent(object sender,DiscardTileEventArgs e)
    {
        //Debug.Log("GM");
        _abandonedTilesAreaController.AddTile(e.PlayerIndex, e.TileSuit);
        //throw new System.NotImplementedException();
    }
    public void OnChowTileEvent(object sender, ChowTileEventArgs e)
    {
        _playerControllers[e.PlayerIndex].AddMeldTile(MeldTypes.Sequence, e.TileSuitsList);
        throw new System.NotImplementedException();
    }
    public void OnPongTileEvent(object sender, PongTileEventArgs e)
    {
        _playerControllers[e.PlayerIndex].AddMeldTile(MeldTypes.Triplet, e.TileSuitsList);
        throw new System.NotImplementedException();
    }
    public void OnKongTileEvent(object sender, KongTileEventArgs e)
    {
        if(e.IsConcealedKong)
            _playerControllers[e.PlayerIndex].AddMeldTile(MeldTypes.ConcealedQuadplet, e.TileSuitsList);
        else
            _playerControllers[e.PlayerIndex].AddMeldTile(MeldTypes.ExposedQuadplet, e.TileSuitsList);
        throw new System.NotImplementedException();
    }
    public void OnWinningSuggestEvent(object sender, WinningSuggestArgs e)
    {
        throw new System.NotImplementedException();
    }
    #endregion

    
    #region API handle
    private void OnRandomSeatEvent(object sender, RandomSeatEventArgs e)
    {
        _playerIndex = e.SelfSeatIndex;
        foreach (SeatInfo seatInfo in e.Seats)  
        {
            _playerControllers[seatInfo.Index].SetSeatInfo(seatInfo);
            _abandonedTilesAreaController.SetTiles(seatInfo.Index, seatInfo.SeaTile);
            _centralAreaController.SetScore(seatInfo.Index, seatInfo.WinScores);
            Debug.LogWarning(seatInfo.Index);
            if (seatInfo.Index == e.SelfSeatIndex)//玩家自己的手牌，需特別處理
            {
                //throw new System.NotImplementedException();
            }
            else
            {
                //Debug.Log(_playerControllers[seatInfo.Index]);
                _playerControllers[seatInfo.Index].SetHandTiles(seatInfo.TileCount ?? 16);
            }
        }

        Debug.Log("!!!!!!!!!!!!OnRandomSeatEvent!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }

    private void OnDecideBankerEvent(object sender, DecideBankerEventArgs e)
    {
        Debug.Log("!!!!!!!!!!!!OnDecideBankerEvent!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }

    private void OnOpenDoorEvent(object sender, OpenDoorEventArgs e)
    {
        Debug.Log("!!!!!!!!!!!!OnOpenDoorEvent!!!!!!!!!!!!");
        foreach(int tileIndex in e.Tiles)
        {
            Debug.Log(tileIndex);
        }
        //throw new System.NotImplementedException();
    }

    private void OnGroundingFlowerEvent(object sender, GroundingFlowerEventArgs e)
    {
        Debug.Log("!!!!!!!!!!!!OnGroundingFlowerEvent!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }
    
    private void OnPlayingEvent(object sender, PlayingEventArgs e)
    {
        /*foreach (SeatInfo seatInfo in e.Seats)
        {
            foreach (TileSuits Flower in seatInfo.FlowerTile)
            {
                Debug.Log(Flower + "Flowers");
            }
            foreach (TileSuits Sea in seatInfo.SeaTile)
            {
                Debug.Log(Sea + "Sea");
            }
        }*/
        
        Debug.Log("!!!!!!!!!!!!OnPlayingEvent!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }
    
    private void OnWaitingActionEvent(object sender, WaitingActionEventArgs e)
    {
        Debug.Log("!!!!!!!!!!!!OnWaitingActionEvent!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }
    
    private void OnPassActionEvent(object sender, PassActionEventArgs e)
    {
        Debug.Log("!!!!!!!!!!!!OnPassActionEvent!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }
    
    private void OnDiscardActionEvent(object sender, DiscardActionEventArgs e)
    {
        Debug.Log("!!!!!!!!!!!!OnDiscardActionEvent!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }
    
    private void OnChowActionEvent(object sender, ChowActionEventArgs e)
    {
        Debug.Log("!!!!!!!!!!!!OnChowActionEvent!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }
    
    private void OnPongActionEvent(object sender, PongActionEventArgs e)
    {
        Debug.Log("!!!!!!!!!!!!OnPongActionEvent!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }
    
    private void OnKongActionEvent(object sender, KongActionEventArgs e)
    {
        Debug.Log("!!!!!!!!!!!!OnKongActionEvent!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }
    
    private void OnDrawnActionEvent(object sender, DrawnActionEventArgs e)
    {
        Debug.Log("!!!!!!!!!!!!OnDrawnActionEvent!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }
    
    private void OnGroundingFlowerActionEvent(object sender, GroundingFlowerActionEventArgs e)
    {
        Debug.Log("!!!!!!!!!!!!OnGroundingFlowerActionEvent!!!!!!!!!!!!");
        //throw new System.NotImplementedException();
    }
    #endregion
}