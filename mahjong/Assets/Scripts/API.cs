using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class API : MonoBehaviour
{
    public static API Instance;

    private ClientWebSocket socket;
    private CancellationTokenSource cancellationTokenSource;
    private Uri uri;

    private void Awake()
    {
        Instance = this;
        uri = new Uri("wss://s9628.nyc1.piesocket.com/v3/1?api_key=XOToxWSiT1gPHYVVzxOjHWBLelW9tbB3U8g5Cbz9&notify_self=1");
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
            /*var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("WebSocket connected."));
            await socket.SendAsync(buffer, WebSocketMessageType.Text, true, cancellationTokenSource.Token);
*/
            // Start listening for incoming messages
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
            var buffer = new byte[1024];
            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationTokenSource.Token);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    // Handle incoming message
                    HandleMessage(message);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"WebSocket listening error: {ex.Message}");
        }
    }

    private async Task SendData(string data)
    {
        var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(data));
        await socket.SendAsync(buffer, WebSocketMessageType.Text, true, cancellationTokenSource.Token);
    }

    private void HandleMessage(string data)
    {
        Debug.Log(data);
        // Parse the incoming JSON data into a Unity C# object
        MessageObject message = JsonUtility.FromJson<MessageObject>(data);

        // Switch based on the Path to handle different message types
        switch (message.Path)
        {
            case Path.Ack:
                HandleAck(message.Data);
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

    // Define the MessageObject structure to match the incoming JSON data
    [System.Serializable]
    private class MessageObject
    {
        public string Path;
        public TablePlayInfo Data;
    }

    // Implement individual message handlers for each message type based on the enums in Game.tso.ts
    private void HandleAck(object data)
    {
        Debug.Log("Ack");
        // Implement the logic for handling the ack message
    }

    private void HandleTableEvent(object data)
    {
        Debug.Log("TableEvent");
        // Implement the logic for handling the table event message
    }

    private void HandleTablePlay(TablePlayInfo data)
    {
        Debug.Log("TablePlay");
        if (data != null)
        {
            switch (data.Action)
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
                case Action.Drawn: // йт
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

    private void HandleTableResult(object data)
    {
        // Implement the logic for handling the table result message
    }

    // Call this method to send data to the WebSocket server
    public async void SendDataToServer(string data)
    {
        if (socket != null && socket.State == WebSocketState.Open)
        {
            await SendData(data);
        }
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
