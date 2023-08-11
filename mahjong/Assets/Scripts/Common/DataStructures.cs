using System;
using System.Collections;
using UnityEngine;

#region Event Args
public class DiscardTileEventArgs:EventArgs
{
    public TileSuits TileSuits;
    public int PlayerIndex;
    public DiscardTileEventArgs(TileSuits tileSuits,int playerIndex)
    {
        TileSuits = tileSuits;
        PlayerIndex = playerIndex;
    }
}

public class ChowTileEventArgs : EventArgs
{
    public TileSuits TileSuits;
    public int PlayerIndex;
    public ChowTileEventArgs(TileSuits tileSuits, int playerIndex)
    {
        TileSuits = tileSuits;
        PlayerIndex = playerIndex;
    }
}
public class PongTileEventArgs : EventArgs
{
    public TileSuits TileSuits;
    public int PlayerIndex;
    public PongTileEventArgs(TileSuits tileSuits, int playerIndex)
    {
        TileSuits = tileSuits;
        PlayerIndex = playerIndex;
    }
}
public class KongTileEventArgs : EventArgs
{
    public bool IsConcealedKong;
    public TileSuits TileSuits;
    public int PlayerIndex;
    public KongTileEventArgs(bool isConcealedKong,TileSuits tileSuits, int playerIndex)
    {
        TileSuits = tileSuits;
        PlayerIndex = playerIndex;
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