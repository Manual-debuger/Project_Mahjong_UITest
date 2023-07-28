using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeldsAreaController : MonoBehaviour,IInitiable
{
    [SerializeField] private List<Meld> _meldControllers = new List<Meld>();
    public void Init()
    {
        foreach(var meld in _meldControllers)
        {
            meld.Init();
        }
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
