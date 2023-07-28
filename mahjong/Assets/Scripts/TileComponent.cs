using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileComponent : MonoBehaviour,IInitiable
{
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Transform _transform;
    private TileSuits _tileSuits;
    
    public TileSuits TileSuit { 
        get { return this._tileSuits; }
        set {
                _meshFilter.mesh= AssetsPoolController.Instance.TileMeshs[(int)value];
            }
    }
    public void Init()
    {
        this.Disappear();
        this.ShowTileBackSide();
    }
    private void Awake()
    {
        if (_meshFilter == null)
            _meshFilter = this.GetComponent<MeshFilter>();
        if (_meshRenderer == null)
            _meshRenderer = this.GetComponent<MeshRenderer>();
        if(_transform==null)
            _transform = this.GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTileFrontSide()
    {
        Debug.Log($"_transform.eulerAngles:{_transform.eulerAngles.x}");
        Debug.Log($"_transform.localEulerAngles:{_transform.localEulerAngles.x}");
        if (_transform.eulerAngles.x==270)//牌是直立的
        {
            
        }            
        else
        {           
            _transform.rotation = Quaternion.Euler(_transform.eulerAngles.x, _transform.eulerAngles.y, 180);
        }            
    }
    
    public void ShowTileBackSide()
    {
        if(_transform.eulerAngles.x== 270)//牌是直立的
        {
           
        }            
        else
        {
            _transform.rotation = Quaternion.Euler(_transform.eulerAngles.x, _transform.eulerAngles.y, 0);
        }            
    }
    public void Disappear()
    {
        this._meshRenderer.enabled = false;
    }
    public void Appear()
    {
        this._meshRenderer.enabled = true;
    }
}
