using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Duty: �C������UI���
public class InGameUIController : MonoBehaviour
{
    private static InGameUIController _instance = new InGameUIController();
    private InGameUIController() { }
    public static InGameUIController Instance { get { return _instance; } }
    [SerializeField] private HandTilesUI _handTilesUIViewer;
    [SerializeField] private ListeningHolesUI _meldTilesUIViewer;
    [SerializeField] private SettingUIButton _settingUIButton;
    [SerializeField] private DiscardTileUI _discardTileUIViewer;
    [SerializeField] private SocialUIButton _socialUIButton;
    [SerializeField] private SupportUIButton _supportUIButton;
    [SerializeField] private WinningSuggestUI _winningSuggestUIViewer;
    [SerializeField] private SettlementScreen _settlementScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
