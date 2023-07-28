using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�@��P(�@�� �Y/�I/�b)
public class Meld : MonoBehaviour,IInitiable
{
    private MeldTypes _meldType;
    [SerializeField]
    private List<TileComponent> _meldTileComponents = new List<TileComponent>();
    public MeldTypes MeldType { get { return _meldType; }  }
    public List<TileComponent> MeldTiles
    {
        get { return _meldTileComponents; }
    }
    public void Init()
    {
        foreach (var tile in _meldTileComponents)
        {
            tile.Disappear();
            tile.ShowTileBackSide();
        }
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
