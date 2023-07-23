using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//一刻牌(一組 吃/碰/槓)
public class Meld : MonoBehaviour
{
    private List<TileComponent> _meldTiles = new List<TileComponent>();
    public List<TileComponent> MeldTiles
    {
        get { return _meldTiles; }
    }
    enum MeldType
    {
        CHOW,
        PONG,
        CONCEALED_KONG,
        KONG,
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
