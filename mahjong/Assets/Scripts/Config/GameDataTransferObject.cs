using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum Action
{
    Pass,
    Discard,
    Chow,
    Pong,
    Kong,
    AdditionKong,
    ConcealedKong,
    ReadyHand,
    Win,
    Drawn,
    GroundingFlower,
    DrawnFromDeadWall,
    SelfDrawnWin,
}

[System.Serializable]
public class TablePlayInfo
{
    public int Index;
    public Action Action;
    public string[] Option;
    public int? DrawnCount;
}

[System.Serializable]
public class ActionInfo
{
    public Action ID;
    public string[][] Options;
    public ReadyInfoType ReadyInfo;
}

[System.Serializable]
public class PointType
{
    public string Describe;
    public int Point;
}

[System.Serializable]
public class PlayerResultData<T>
{
    public T[] Tiles;
    public int Points;
    public PointType[] PointList;
    public int? WinScores;
    public bool? SelfDrawn;
    public bool? Winner;
    public bool? Loser;
    public bool? Banker;
    public bool? Bankruptcy;
    public bool? Disconnected;
    public bool? InsufficientBalance;
    public int? TableFee;
    public bool? HandWin;
}

[System.Serializable]
public class PlayerGameResultData
{
    public string Avatar;
    public string AvatarBackground; // 頭像背景
    public int Gender;
    public int VoiceLanguage;
    public string Name;
    public string Nickname;
    public int Scores;
    public int Index;
    public int WinCount;
    public int LoseCount;
    public int WinScores;
    public int? Compensation;
    public int? TableFee;
    public bool? Bankruptcy;
    public bool? Disconnected;
    public bool? TableOwner;
    public bool? InsufficientBalance;
}
/**
 * ReadyInfo => {
 * 
	丟的牌: {

		 聽的牌: 幾台,
		 聽的牌: 幾台   [key: string]: ListeningTilesType;
	}
  }
 */
[System.Serializable]
public class ReadyInfoType
{
    public Dictionary<string, ListeningTilesType> ListeningTilesType;
}

/**
 * {
 * 聽的牌: 幾台 [mahjong: string]: number;
 * }
 */
[System.Serializable]
public class ListeningTilesType
{
    public Dictionary<string, int> Mahjong;
}

public static class Path
{
    public const string Ack = "auth.ack";
    public const string Login = "auth.login";
    public const string Scores = "auth.scores";
    public const string TableInit = "game.table.init";
    public const string TableEnter = "game.table.enter";
    public const string TableEvent = "game.table.event";
    public const string TablePlay = "game.table.play";
    public const string TableResult = "game.table.result";
    public const string TableEnd = "game.table.end";
    public const string TableAutoPlay = "game.table.autoplay";
    public const string TableRule = "game.table.rule";
    public const string TableDissolution = "game.table.dissolution";
    public const string TableReady = "game.table.ready";
}

[System.Serializable]
public class TableResultData
{
    public string Path;
    public string Err;
    public ResultData[] Data;
}

[System.Serializable]
public class ResultData
{
    public int Index;
    public string NickName;
    public int PlayerID;
    public int WinScores;
    public int Scores;
    public bool Winner;
    public bool Loser;
    public bool Banker;
    public bool SelfDrawn;
    public int CardinalDirection;
    public int Points;
    public PointType[] PointList;
    public string[] Door;
    public string[] Tiles;
    public string LastTile;
}