using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Duty: To display the tiles in the hand of the player��^�Ǩƥ�
public class HandTilesUI : MonoBehaviour
{
    [SerializeField]
    protected List<HandTileUI> _TilesComponents = new List<HandTileUI>();
    // Start is called before the first frame update
    void Start()
    {
        
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
}
