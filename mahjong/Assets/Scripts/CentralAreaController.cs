using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//Duty: 處理中間的贏分，風位，莊家等等
public class CentralAreaController : MonoBehaviour,IInitiable
{
    [SerializeField] private TextMeshPro _numberOfRemainedTilesTextMeshPro;    
    [SerializeField] private List<TextMeshPro> _scoresTextMeshProList; // Default ESWN
    [SerializeField] private List<TextMeshPro> _dealersTextMeshProList;// Default ESWN
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init()
    {
        foreach(var scoreTextMeshPro in _scoresTextMeshProList)
        {
            scoreTextMeshPro.text = "0";
        }
        foreach(var dealerTextMeshPro in _dealersTextMeshProList)
        {
            dealerTextMeshPro.text = "";
        }
        _numberOfRemainedTilesTextMeshPro.text = "88";
        throw new System.NotImplementedException();
    }
    public void SetScore()
    {
        throw new System.NotImplementedException();
    }
    public void SetDealer()
    {
        throw new System.NotImplementedException();
    }
    public void SetNumberOfRemainedTiles(int number)
    {
        _numberOfRemainedTilesTextMeshPro.text = number.ToString();
    }
    public void ReduceNumberOfRemainedTilesByOne()
    {
        throw new System.NotImplementedException();
    }
}
