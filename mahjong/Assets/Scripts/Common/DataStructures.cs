using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Event Args
public class DiscardTileEventArgs:EventArgs
{
    public TileSuits TileSuit;
    public int PlayerIndex;
    public DiscardTileEventArgs(TileSuits tileSuits,int playerIndex)
    {
        TileSuit = tileSuits;
        PlayerIndex = playerIndex;
    }
}
public class TileSuitsLIstEventArgs:EventArgs
{
    public List<TileSuits> TileSuitsList;
    public int PlayerIndex;
    public TileSuitsLIstEventArgs(List<TileSuits> tileSuitsList, int playerIndex)
    {
        TileSuitsList = tileSuitsList;
        PlayerIndex = playerIndex;
    }
}
public class ChowTileEventArgs : TileSuitsLIstEventArgs
{

    public ChowTileEventArgs(List<TileSuits> tileSuitsList, int playerIndex):base(tileSuitsList,playerIndex)
    {
        
    }
}
public class PongTileEventArgs : TileSuitsLIstEventArgs
{
    
    public PongTileEventArgs(List<TileSuits> tileSuitsList, int playerIndex):base (tileSuitsList,playerIndex) { }
}
public class KongTileEventArgs : TileSuitsLIstEventArgs
{
    public bool IsConcealedKong;
   
    public KongTileEventArgs(bool isConcealedKong,List<TileSuits> tileSuitsList, int playerIndex):base(tileSuitsList,playerIndex)
    {       
        IsConcealedKong = isConcealedKong;
    }
}
public class DiscardTileSuggestArgs:DiscardTileEventArgs
{
    public DiscardTileSuggestArgs(TileSuits tileSuits, int playerIndex) : base(tileSuits, playerIndex)
    {
    }
}
public class WinningSuggestArgs : EventArgs
{
    public TileSuits TileSuits;
    public int PlayerIndex;
    public WinningSuggestArgs(TileSuits tileSuits, int playerIndex)
    {
        TileSuits = tileSuits;
        PlayerIndex = playerIndex;
    }
}
#endregion