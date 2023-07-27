using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  AssetsPoolController:MonoBehaviour
{
    [SerializeField] private Mesh[] _tileMeshs;
    public Mesh[] TileMeshs {
        get { return _instance._tileMeshs; }
    }
    private static AssetsPoolController _instance;
    public static AssetsPoolController Instance
    {
        get
        {
            if (_instance == null)
                _instance = new AssetsPoolController();
            return _instance;
        }
    }
    private AssetsPoolController()
    {
        if (_instance == null)
            _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
