using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class API : MonoBehaviour
{
    public static API Instance;

    private ClientWebSocket socket;
    private CancellationTokenSource cancellationTokenSource;
    private Uri uri;

    private bool isLoggedInAndEnterTable = false; // 僅在初次按下進入遊戲登入且成功進桌時會被設定

    private void Awake()
    {
        Instance = this;
        uri = new Uri("ws://localhost:80/api/v1/games/mahjong16");
    }

    private async void Start()
    {
        await Connect();
    }

    private async Task Connect()
    {
        socket = new ClientWebSocket();
        cancellationTokenSource = new CancellationTokenSource();

        try
        {
            await socket.ConnectAsync(uri, cancellationTokenSource.Token);
            Debug.Log("WebSocket connected.");
            await Login();
            _ = StartListening();
        }
        catch (Exception ex)
        {
            Debug.LogError($"WebSocket connection failed: {ex.Message}");
        }
    }

    private async Task StartListening()
    {
        try
        {
            var receiveBuffer = new List<byte>();
            var bufferSize = 1024; // Use a larger buffer size
            while (socket.State == WebSocketState.Open)
            {
                var buffer = new byte[bufferSize];
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationTokenSource.Token);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    receiveBuffer.AddRange(buffer.Take(result.Count)); // Add received bytes to the buffer

                    if (result.EndOfMessage) // Check if it's the end of the message
                    {
                        var message = Encoding.UTF8.GetString(receiveBuffer.ToArray());
                        // Handle incoming message
                        HandleMessage(message);

                        receiveBuffer.Clear(); // Clear the buffer for the next message
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"WebSocket listening error: {ex.Message}");
        }
    }

    public async Task Login(string token = null)
    {
        var requestData = new LoginObject
        {
            Path = Path.Login,
            Data = new LoginData
            {
                IsGuest = true,
                Token = token
            }
        };

        string jsonData = JsonUtility.ToJson(requestData);
        Debug.Log("Login request: " + jsonData);
        await SendDataToServer(jsonData);
    }

    public async Task TableEnter(object config = null)
    {
        // Simulate sending data
        var requestData = new TableEnterObject
        {
            Path = "game.table.enter",
            Data = config
        };

        string jsonData = JsonUtility.ToJson(requestData);
        Debug.Log("TableEnter request: " + jsonData);
        await SendDataToServer(jsonData);
    }

    private void HandleMessage(string data)
    {
        Debug.Log("From Server: " + data);
        // Parse the incoming JSON data into a Unity C# object
        MessageObject message = JsonUtility.FromJson<MessageObject>(data);

        // Switch based on the Path to handle different message types
        switch (message.Path)
        {
            case Path.Ack:
                HandleAck(message.Data);
                break;
            case Path.Login:
                HandleLogin(message.Data);
                break;
            case Path.TableEnter:
                HandleTableEnter(message.Data);
                break;
            case Path.TableEvent:
                HandleTableEvent(message.Data);
                break;
            case Path.TablePlay:
                HandleTablePlay(message.Data);
                break;
            case Path.TableResult:
                HandleTableResult(message.Data);
                break;
            default:
                Debug.LogError("Unknown message Path: " + message.Path);
                break;
        }
    }

    // Implement individual message handlers for each message type based on the enums in Game.tso.ts
    private void HandleAck(string data)
    {
        Debug.Log("Ack");
    }

    private async void HandleLogin(string data)
    {
        await TableEnter();
    }

    private void HandleTableEnter(string data)
    {
        if (!this.isLoggedInAndEnterTable)
        {
            this.isLoggedInAndEnterTable = true;
        }
    }

    private void HandleTableEvent(string data)
    {
        try
        {
            TableEventData eventData = JsonUtility.FromJson<TableEventData>(data);
            Debug.Log("TableEvent: " + eventData.State);

            switch (eventData.State)
            {
                case "Waiting":
                    //GameClass.instance.HandleWaitingState(eventData);
                    break;
                case "RandomSeat":
                    //GameClass.instance.HandleRandomSeatState(eventData);
                    break;
                case "DecideBanker":
                    //GameClass.instance.HandleDecideBankerState(eventData);
                    break;
                case "OpenDoor":
                    //GameClass.instance.HandleOpenDoorState(eventData);
                    break;
                case "GroundingFlower":
                    //GameClass.instance.HandleGroundingFlowerState(eventData);
                    break;
                case "SortingTiles":
                    //GameClass.instance.HandleSortingTiles(eventData);
                    break;
                case "Playing":
                    //GameClass.instance.HandlePlayingState(eventData);
                    break;
                case "DelayPlaying":
                    //GameClass.instance.HandleDelayPlayingState(eventData);
                    break;
                case "WaitingAction":
                    //GameClass.instance.HandleWaitingActionState(eventData);
                    break;
                case "HandEnd":
                    //GameClass.instance.HandleHandEndState(eventData);
                    break;
                case "GameEnd":
                    //GameClass.instance.HandleGameEndState(eventData);
                    break;
                case "Closing":
                    //GameClass.instance.HandleClosingState(eventData);
                    break;
                default:
                    Debug.LogError("Unknown state: " + eventData.State);
                    break;
            }

            // GameClass.instance.UpdateEventTimer(); eventTimer = System.DateTime.Now.Ticks / 10000;
        }
        catch (Exception e)
        {
            Debug.LogError("Error deserializing TableEventData: " + e.Message);
        }


        /*if (GameClass.instance == null)
        {
            Global.UpdateTableBasicInfo(eventData);
            return;
        }*/


    }

    private void HandleTablePlay(string data)
    {
        TablePlayData playData = JsonUtility.FromJson<TablePlayData>(data);
        Debug.Log("TablePlay");
        if (playData != null)
        {
            switch (playData.Action)
            {
                case Action.Pass:
                    break;
                case Action.Discard:
                    break;
                case Action.Chow:
                    break;
                case Action.Pong:
                    break;
                case Action.Kong:
                case Action.AdditionKong:
                case Action.ConcealedKong:
                    break;
                case Action.ReadyHand:
                    break;
                case Action.Win:
                    break;
                case Action.Drawn: // 抽
                    break;
                case Action.SelfDrawnWin:
                    break;
                case Action.GroundingFlower:
                    break;
                case Action.DrawnFromDeadWall:
                    break;
            }
        }
        else
        {
            //CloseAllBtn();
        }
    }

    private void HandleTableResult(string data)
    {
        // Implement the logic for handling the table result message
    }

    // Call this method to send data to the WebSocket server
    public async Task SendDataToServer(string data)
    {
        if (socket != null && socket.State == WebSocketState.Open)
        {
            await SendData(data);
        }
    }

    private async Task SendData(string data)
    {

        var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(data));
        await socket.SendAsync(buffer, WebSocketMessageType.Text, true, cancellationTokenSource.Token);
    }

    private async Task CloseConnection()
    {
        if (socket != null && socket.State == WebSocketState.Open)
        {
            cancellationTokenSource.Cancel();
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed by user", cancellationTokenSource.Token);
            Debug.Log("WebSocket connection closed.");
        }
    }

    private void OnDestroy()
    {
        CloseConnection().Wait();
    }
}
