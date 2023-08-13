using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//Duty: 遊戲中的UI控制器
public class InGameUIController : MonoBehaviour
{
    private static InGameUIController _instance;    
    public static InGameUIController Instance { get { return _instance; } }
    [SerializeField] private HandTilesUI _handTilesUIViewer;
    [SerializeField] private ListeningHolesUI _meldTilesUIViewer;
    [SerializeField] private SettingUIButton _settingUIButton;
    [SerializeField] private DiscardTileUI _discardTileUIViewer;
    [SerializeField] private SocialUIButton _socialUIButton;
    [SerializeField] private SupportUIButton _supportUIButton;
    [SerializeField] private WinningSuggestUI _winningSuggestUIViewer;
    [SerializeField] private SettlementScreen _settlementScreen;

    public event EventHandler<DiscardTileEventArgs> DiscardTileEvent;

    private int NumberOfRemainingTiles = 17;
    public List<TileSuits> HandTileSuits = new List<TileSuits>() {
        TileSuits.c1,
        TileSuits.c8,TileSuits.c8,
        TileSuits.c7, TileSuits.c7,
        TileSuits.c4, TileSuits.c4,
        TileSuits.c2, TileSuits.c2,
        TileSuits.c3, TileSuits.c3,
        TileSuits.c6, TileSuits.c6,
        TileSuits.c5, TileSuits.c5,
        TileSuits.c1, TileSuits.c1
    };
    private void Awake()
    {
        if(_instance != null && _instance != this)
            Destroy(this.gameObject);
        else if(_instance == null)
            _instance = this;

        _handTilesUIViewer.DiscardTileEvent += DiscardTile;
    }    
    // Start is called before the first frame update
    void Start()
    {
        HandTileSort();
        HandTileSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DiscardTile(object sender, TileIndexEventArgs e)
    {
        //Debug.Log("UI");
        TileSuits tile = HandTileSuits[e.TileIndex];
        HandTileSuits[e.TileIndex] = TileSuits.NULL;
        HandTileSort();
        HandTileSet();
        DiscardTileEvent?.Invoke(this, new DiscardTileEventArgs(tile, 1));
    }

    public void HandTileSort()
    {
        HandTileSuits.Sort(new Comparison<TileSuits>((x, y) => x.CompareTo(y)));
    }

    public void HandTileSet()
    {
        for (int i = 0; i < 17; i++)
        {
            _handTilesUIViewer.HandTileSet(i, HandTileSuits[i]);
        }
    }
    public SettingUIButton SettingUIButton
    {
        get => default;
        set
        {
        }
    }

    public UICountdownTimer UICountdownTimer
    {
        get => default;
        set
        {
        }
    }

    public HandTilesUI HandTilesUIViewer
    {
        get => default;
        set
        {
        }
    }

    public WinningSuggestUI WinningSuggestUIViewer
    {
        get => default;
        set
        {
        }
    }

    public SocialUIButton SocialUIButton
    {
        get => default;
        set
        {
        }
    }

    public SupportUIButton SupportUIButton
    {
        get => default;
        set
        {
        }
    }

    public ListeningHolesUI ListeningHolesUI
    {
        get => default;
        set
        {
        }
    }

    public DiscardTileUI DiscardTileUIViewer
    {
        get => default;
        set
        {
        }
    }

    public SettlementScreen SettlementScreen
    {
        get => default;
        set
        {
        }
    }
}
