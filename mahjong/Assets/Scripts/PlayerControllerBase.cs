using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���Ѱ�(���a���L�T�쪱�a)�������򥻾ާ@
public class PlayerControllerBase : MonoBehaviour
{
    private HandTilesArea _handTiles;
    private MeldTilesArea _meldTiles;
    private FlowerTileArea _flowerTiles;

    public MeldTilesArea MeldTilesArea
    {
        get => default;
        set
        {
        }
    }

    public HandTilesArea HandTilesArea
    {
        get => default;
        set
        {
        }
    }

    public FlowerTileArea FlowerTileArea
    {
        get => default;
        set
        {
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
