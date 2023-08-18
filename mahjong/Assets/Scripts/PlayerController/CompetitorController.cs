using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UIScripts
{
    public class CompetitorController : PlayerControllerBase
    {
        [SerializeField] private HandTilesAreaController _handTilesAreaController;
        [SerializeField] private DrawedTileAreaController _drawedTileAreaController;
        
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public override void Init()
        {
            _handTilesAreaController.Init();
            _drawedTileAreaController.Init();          
            base.Init();
        }
        public override void SetHandTiles(int tileCount, bool IsDrawing = false)
        {
            _drawedTileAreaController.Init();
            if(IsDrawing)
            {
                _drawedTileAreaController.AddTile(TileSuits.b1);
                tileCount--;
            }
            if (_handTilesAreaController.GetTileSuits().Length == tileCount)
                return;
            else 
            {
                _handTilesAreaController.Init();
                for(int i=0;i<tileCount;i++)
                {
                    _handTilesAreaController.AddTile(TileSuits.b1);
                }                       
            }
        }
        public override void SetHandTiles(List<TileSuits> tileSuits, bool IsDrawing=false)
        {
            _drawedTileAreaController.Init();
            if (IsDrawing)
            {
                _drawedTileAreaController.AddTile(tileSuits.Last());                
            }
            if (_handTilesAreaController.GetTileSuits().Length == tileSuits.Count -( IsDrawing ? 1 : 0))
                return;
            else
            {
                _handTilesAreaController.Init();
                for(int i=0;i<tileSuits.Count-(IsDrawing?1:0);i++)
                {
                    _handTilesAreaController.AddTile(tileSuits[i]);
                }
            }                       
        }
        public override void AddDrawedTile(TileSuits tileSuit)
        {
            _drawedTileAreaController.AddTile(tileSuit);
        }
        /*public override void AddHandTile(TileSuits tileSuit)
        {
            _handTilesAreaController.AddTile(tileSuit);
        }*/
        public override void DiscardTile(TileSuits tileSuit)
        {
            _drawedTileAreaController.PopLastTile();
        }
        /*public override void RemoveHandTile(TileSuits tileSuit)
        {
            _handTilesAreaController.PopLastTile();
        }*/
    }
}