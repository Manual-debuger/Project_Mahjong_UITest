using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���Ѱ�(���a���L�T�쪱�a)�������򥻾ާ@
public class PlayerControllerBase : MonoBehaviour
{
    private HandTilesAreaController _handTiles;
    
    private FlowerTileAreaController _flowerTileAreaController;



    public HandTilesAreaController HandTilesArea
    {
        get => default;
        set
        {
        }
    }

    public FlowerTileAreaController FlowerTileAreaController
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
