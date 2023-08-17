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
//public class DiscardTileSuggestArgs:DiscardTileEventArgs
//{
//    public DiscardTileSuggestArgs(TileSuits tileSuits, int playerIndex) : base(tileSuits, playerIndex)
//    {
//    }
//}
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
public class TileIndexEventArgs : EventArgs
{
    public int TileIndex;
    public TileIndexEventArgs(int tileIndex)
    {
        TileIndex = tileIndex;
    }
}

public class TileSuitEventArgs : EventArgs
{
    public TileSuits TileSuit;
    public TileSuitEventArgs(TileSuits tileSuit)
    {
        TileSuit = tileSuit;
    }
}

#region State Event
public class RandomSeatEventArgs : EventArgs
{
    public int Index;
    public SeatInfo[] SeatInfos;
    public RandomSeatEventArgs(int index, SeatInfo[] seats)
    {
        Index = index;
        SeatInfos = seats;
    }
}

public class DecideBankerEventArgs : EventArgs
{
    public int? BankerIndex;
    public DecideBankerEventArgs(int? bankerIndex)
    {
        BankerIndex = bankerIndex;
    }
}

public class OpenDoorEventArgs : EventArgs
{
    public int? WallCount;
    public List<TileSuits> Tiles;
    public OpenDoorEventArgs(int? wallCount, List<TileSuits> tiles)
    {
        WallCount = wallCount;
        Tiles = tiles;
    }
}

public class GroundingFlowerEventArgs : EventArgs
{
    public int? WallCount;
    public List<TileSuits> Tiles;
    public SeatInfo[] Seats;
    public GroundingFlowerEventArgs(int? wallCount, List<TileSuits> tiles, SeatInfo[] seats)
    {
        WallCount = wallCount;
        Tiles = tiles;
        Seats = seats;
    }
}

public class PlayingEventArgs : EventArgs
{
    public int? PlayingIndex;
    public long? PlayingDeadline;
    public int? WallCount;
    public List<TileSuits> Tiles;
    public SeatInfo[] Seats;
    public PlayingEventArgs(int? playingIndex, long? playingDeadline, int? wallCount, List<TileSuits> tiles, SeatInfo[] seats)
    {
        PlayingIndex = playingIndex;
        PlayingDeadline = playingDeadline;
        WallCount = wallCount;
        Tiles = tiles;
        Seats = seats;
    }
}

public class WaitingActionEventArgs : EventArgs
{
    public int? PlayingIndex;
    public long? PlayingDeadline;
    public int? WallCount;
    public List<TileSuits> Tiles;
    public ActionData[] Actions;
    public SeatInfo[] Seats;
    public WaitingActionEventArgs(int? playingIndex, long? playingDeadline, int? wallCount, List<TileSuits> tiles, ActionData[] actions, SeatInfo[] seats)
    {
        PlayingIndex = playingIndex;
        PlayingDeadline = playingDeadline;
        WallCount = wallCount;
        Tiles = tiles;
        Actions = actions;
        Seats = seats;
    }
}
#endregion
#region Action Event
public class PassActionEventArgs : EventArgs
{
    public int Index;
    public Action Action;
    public PassActionEventArgs(int index, Action action)
    {
        Index = index;
        Action = action;
    }
}

public class DiscardActionEventArgs : EventArgs
{
    public int Index;
    public Action Action;
    public List<string[]> Options;
    public DiscardActionEventArgs(int index, Action action, List<string[]> options)
    {
        Index = index;
        Action = action;
        Options = options;
    }
}

public class ChowActionEventArgs : EventArgs
{
    public int Index;
    public Action Action;
    public List<string[]> Options;
    public ChowActionEventArgs(int index, Action action, List<string[]> options)
    {
        Index = index;
        Action = action;
        Options = options;
    }
}

public class DrawnActionEventArgs : EventArgs
{
    public int Index;
    public Action Action;
    public int? DrawnCount;
    public DrawnActionEventArgs(int index, Action action, int? drawnCount)
    {
        Index = index;
        Action = action;
        DrawnCount = drawnCount;
    }
}

public class GroundingFlowerActionEventArgs : EventArgs
{
    public int Index;
    public Action Action;
    public int? DrawnCount;
    public GroundingFlowerActionEventArgs(int index, Action action, int? drawnCount)
    {
        Index = index;
        Action = action;
        DrawnCount = drawnCount;
    }
}
#endregion

public class FloatEventArgs : EventArgs
{
    public float f;
    public FloatEventArgs(float Float)
    {
        f = Float;
    }
}
#endregion