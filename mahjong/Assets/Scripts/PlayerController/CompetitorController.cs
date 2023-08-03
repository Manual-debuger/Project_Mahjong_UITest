using System.Collections;
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