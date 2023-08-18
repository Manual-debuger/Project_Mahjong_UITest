using System.Collections;
using System.Collections.Generic;
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
        public override void SetHandTiles(int tileCount)
        {
            for(int i=0;i<tileCount;i++)
            {
                _handTilesAreaController.AddTile(TileSuits.b1);
            }           
        }
        public override void SetHandTiles(List<TileSuits> tileSuits)
        {
            foreach(var tileSuit in tileSuits)
            {
                _handTilesAreaController.AddTile(tileSuit);
            }            
        }
        public override void AddDrawedTile(TileSuits tileSuit)
        {
            _drawedTileAreaController.AddTile(tileSuit);
        }
        public override void AddHandTile(TileSuits tileSuit)
        {
            _handTilesAreaController.AddTile(tileSuit);
        }
        public override void RemoveDrawedTile(TileSuits tileSuit)
        {
            _drawedTileAreaController.PopLastTile();
        }
        public override void RemoveHandTile(TileSuits tileSuit)
        {
            _handTilesAreaController.PopLastTile();
        }
    }
}