using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour,IInitiable
{
    private static GameManager _instance;    

    public static GameManager Instance { get { return _instance; } }
    [SerializeField] private AbandonedTilesAreaController _abandonedTilesAreaController;
    [SerializeField] private PlayerControllerBase[] _playerControllers;
    [SerializeField] private InGameUIController _inGameUIController;
    [SerializeField] private AnimController _animController;
    [SerializeField] private AudioController _audioManager;
    public void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else if (_instance == null)
            _instance = this;
        _inGameUIController.DiscardTileEvent += OnDiscardTileEvent;
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

}
