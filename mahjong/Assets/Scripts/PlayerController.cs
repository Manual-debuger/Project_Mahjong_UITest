using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ѥu�����a���a�~�����ާ@
public class PlayerController : PlayerControllerBase
{
    // Start is called before the first frame update
    private static PlayerController _instance = new PlayerController();
    private PlayerController() { }
    public static PlayerController Instance { get { return _instance; } }
    private PlayingViewer _playingViewer;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
