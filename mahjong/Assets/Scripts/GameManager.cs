using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Example 參數還不確定
    public void AddHandTile(int PlayerIndex,TileSuits tileSuits)
    {
        throw new System.NotImplementedException();
    }

    public void Init()
    {
        throw new System.NotImplementedException();
    }
}
