using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
//Duty: To display the tiles in the hand of the player跟回傳事件
public class HandTileUI : MonoBehaviour
{
    [SerializeField] 
    private Image _image;
    public event EventHandler<TileIndexEventArgs> DiscardTileEvent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetTile(Sprite texture)
    {
        this._image.sprite = texture;
    }
    public void Click(int index)
    {
        //Debug.Log(index);
        DiscardTileEvent?.Invoke(this, new TileIndexEventArgs(index));
    }
    public void Appear()
    {
        this.gameObject.SetActive(true);
    }
    public void Disappear()
    {
        this.gameObject.SetActive(false);
    }
}
