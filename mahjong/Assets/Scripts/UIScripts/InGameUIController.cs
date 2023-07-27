using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Duty: 遊戲中的UI控制器
public class InGameUIController : MonoBehaviour
{
    private static InGameUIController _instance = new InGameUIController();
    private InGameUIController() { }
    public static InGameUIController Instance { get { return _instance; } }
    private HandTilesUI _handTilesUIViewer;
    private ListeningHolesViewer _meldTilesUIViewer;
    private SettingUIButton _settingUIButton;
    private DiscardTileUI _discardTileUIViewer;
    private SocialUIButton _socialUIButton;
    private SupportUIButton _supportUIButton;
    private WinningSuggestUI _winningSuggestUIViewer;
    private SettlementScreen _settlementScreen;


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

    public ListeningHolesViewer ListeningHolesViewer
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
