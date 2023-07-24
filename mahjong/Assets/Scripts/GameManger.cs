using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private static GameManger _instance = new GameManger();
    private GameManger() { }
    public static GameManger Instance { get { return _instance; } }
    private AnimController _animController;
    private AudioController _audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
