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
    public event EventHandler<TileSuitEventArgs> OnTileBeHoldingEvent;
    public event EventHandler<TileSuitEventArgs> LeaveTileBeHoldingEvent;
    public event EventHandler<FloatEventArgs> SetMusicEvent;
    public event EventHandler<FloatEventArgs> SetSoundEvent;

    private int NumberOfRemainingTiles = 17;
    public List<TileSuits> HandTileSuits = new() {
        TileSuits.c8,TileSuits.c8,
        TileSuits.c1, TileSuits.c1,
        TileSuits.c7, TileSuits.c7,
        TileSuits.c4, TileSuits.c4,
        TileSuits.c2, TileSuits.c2,
        TileSuits.c3, TileSuits.c3,
        TileSuits.c6, TileSuits.c6,
        TileSuits.c5, TileSuits.c5,
        TileSuits.c1
    };
    private void Awake()
    {
        if(_instance != null && _instance != this)
            Destroy(this.gameObject);
        else if(_instance == null)
            _instance = this;

        _handTilesUIViewer.DiscardTileEvent += DiscardTile;
        _handTilesUIViewer.OnPointerDownEvent += OnDiscardTileSuggestEvent;
        _handTilesUIViewer.OnPointerUpEvent += LeaveDiscardTileSuggestEvent;
        _settingUIButton.SetMusicEvent += SetMusic;
        _settingUIButton.SetSoundEvent += SetSound;
    }    
    // Start is called before the first frame update
    void Start()
    {
        HandTileSort();
        HandTileUISet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DiscardTile(object sender, TileIndexEventArgs e)
    {
        //Debug.Log("UI");
        TileSuits tile = HandTileSuits[e.TileIndex];
        //HandTileSuits[e.TileIndex] = TileSuits.NULL;
        HandTileSuits[e.TileIndex] = HandTileSuits[16];
        HandTileSuits[16] = TileSuits.NULL;

        HandTileSort();
        HandTileUISet();
        DiscardTileEvent?.Invoke(this, new DiscardTileEventArgs(tile, 0));
    }
    private void OnDiscardTileSuggestEvent(object sender, TileIndexEventArgs e)
    {
        //Debug.Log("OnDiscardTileSuggestEvent");
        //我猜你會需要這個
        //new TileSuitEventArgs(HandTileSuits[e.TileIndex])
        OnTileBeHoldingEvent?.Invoke(this, new TileSuitEventArgs(HandTileSuits[e.TileIndex]));
    }

    private void LeaveDiscardTileSuggestEvent(object sender, TileIndexEventArgs e)
    {
        //Debug.Log("LeaveDiscardTileSuggestEvent");
        LeaveTileBeHoldingEvent?.Invoke(this, new TileSuitEventArgs(HandTileSuits[e.TileIndex]));
    }

    public void HandTileSort()
    {
        List<TileSuits> sublist = HandTileSuits.GetRange(0, 16);

        sublist.Sort(new Comparison<TileSuits>((x, y) => x.CompareTo(y)));
        sublist.RemoveAll(x => x == TileSuits.NULL);
        while (sublist.Count < 16)
        {
            sublist.Insert(0, TileSuits.NULL);
        }
        
        HandTileSuits.RemoveRange(0, 16);
        HandTileSuits.InsertRange(0, sublist);
        //HandTileSuits.Sort(new Comparison<TileSuits>((x, y) => x.CompareTo(y)));
    }

    public void HandTileUISet()
    {
        for (int i = 0; i < 17; i++)
        {
            _handTilesUIViewer.HandTileSet(i, HandTileSuits[i]);
        }
    }

    public void SetHandTile(List<TileSuits> tileSuits, bool IsDrawing)
    {
        if (IsDrawing)
        {
            HandTileSuits[17] = tileSuits[tileSuits.Count - 1];
            tileSuits.RemoveAt(tileSuits.Count - 1);
        }

        for (int i = 0; i < tileSuits.Count; i++)
        {
            HandTileSuits[16 - tileSuits.Count + i] = tileSuits[i];
        }
        for (int i = 0; i < 16 - tileSuits.Count; i++)
        {
            HandTileSuits[i] = TileSuits.NULL;
        }
    }

    private void SetMusic(object sender, FloatEventArgs e)
    {
        //Debug.Log(e.f);
        SetMusicEvent?.Invoke(this, e);
    }

    private void SetSound(object sender, FloatEventArgs e)
    {
        //Debug.Log(e.f);
        SetSoundEvent?.Invoke(this, e);
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
