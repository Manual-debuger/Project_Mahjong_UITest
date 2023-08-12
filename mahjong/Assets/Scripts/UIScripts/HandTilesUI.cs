using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//Duty: To display the tiles in the hand of the player跟回傳事件
public class HandTilesUI : MonoBehaviour
{
    private int NumberOfRemainingTiles = 17;
    [SerializeField]
    public List<HandTileUI> _TilesComponents = new List<HandTileUI>();
    public event EventHandler<DiscardTileEventArgs> DiscardTileEvent;
    public List<TileSuits> HandTileSuits = new List<TileSuits>() { 
        TileSuits.c1, 
        TileSuits.c8,TileSuits.c8,
        TileSuits.c7, TileSuits.c7,
        TileSuits.c1, TileSuits.c1,
        TileSuits.c4, TileSuits.c4,
        TileSuits.c2, TileSuits.c2,
        TileSuits.c3, TileSuits.c3,
        TileSuits.c6, TileSuits.c6,
        TileSuits.c5, TileSuits.c5
    }; 
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NumberOfRemainingTiles; i++)
        {
            //Debug.Log(i);
            HandTileSort();
            _TilesComponents[i].DiscardTileEvent += DiscardTile;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Appear()
    {
        this.gameObject.SetActive(true);
    }
    public void Disappear()
    {
        this.gameObject.SetActive(false);
    }
    private void DiscardTile(object sender, TileIndexEventArgs e)
    {
        Debug.Log("Tiles");
        //if(_TilesComponents[0].gameObject.activeSelf)
        //    _TilesComponents[0].Disappear();
        //else
        //    _TilesComponents[0].Appear();

        _TilesComponents[0].Appear();
        DiscardTileEvent?.Invoke(this, new DiscardTileEventArgs(TileSuits.c1,1));
    }
    public void HandTileSort()
    {
        List<TileSuits> sublist = HandTileSuits.GetRange(1, NumberOfRemainingTiles - 1);

        sublist.Sort(new Comparison<TileSuits>((x, y) => x.CompareTo(y)));

        HandTileSuits.RemoveRange(1, NumberOfRemainingTiles - 1);
        HandTileSuits.InsertRange(1, sublist);
    }
}
