using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileComponent : MonoBehaviour
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
        if(_transform.rotation.z!=0)
            _transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    
    public void ShowTileBackSide()
    {
        if (_transform.rotation.z != 180)
            _transform.rotation = Quaternion.Euler(0, 0, 180);
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
