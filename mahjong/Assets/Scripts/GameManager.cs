using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour,IInitiable
{
    private static GameManager _instance = new GameManager();
    private GameManager() { }
    public static GameManager Instance { get { return _instance; } }
    [SerializeField] private AbandonedTilesAreaController _abandonedTilesAreaController;
    [SerializeField] private PlayerControllerBase[] _playerControllers;
    [SerializeField] private InGameUIController _inGameUIController;
    [SerializeField] private AnimController _animController;
    [SerializeField] private AudioController _audioManager;    
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
        throw new System.NotImplementedException();
    }
    public void OnChowTileEvent(object sender, ChowTileEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    public void OnPongTileEvent(object sender, PongTileEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    public void OnKongTileEvent(object sender, KongTileEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    public void OnWinningSuggestEvent(object sender, WinningSuggestArgs e)
    {
        throw new System.NotImplementedException();
    }    
    #endregion

}
