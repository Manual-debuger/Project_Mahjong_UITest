using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�@��P(�@�� �Y/�I/�b)
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
