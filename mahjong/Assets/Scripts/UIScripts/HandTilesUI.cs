using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
//Duty: To display the tiles in the hand of the player��^�Ǩƥ�
public class HandTilesUI : MonoBehaviour
{
    [SerializeField]
    public List<HandTileUI> _TilesComponents = new List<HandTileUI>();
    [SerializeField] 
    private Sprite[] _tileMeshs;
    public event EventHandler<TileIndexEventArgs> DiscardTileEvent;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 17; i++)
        {
            //Debug.Log(i);
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
        //Debug.Log("Tiles");
        //if(_TilesComponents[0].gameObject.activeSelf)
        //    _TilesComponents[0].Disappear();
        //else
        //    _TilesComponents[0].Appear();
        //_TilesComponents[0].Appear();

        DiscardTileEvent?.Invoke(this, e);
    }
    public void HandTileSet(int index,TileSuits HandTileSuit)
    {
        if (HandTileSuit != TileSuits.NULL)
            _TilesComponents[index].SetTile(_tileMeshs[(int)HandTileSuit]);
        else
            _TilesComponents[index].Disappear();
    }
}
