using System;
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
            case Path.Scores:
                break;
            case Path.TableInit:
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
            case Path.TableEnd:
                HandleTableEnd(message.Data);
                break;
            case Path.TableAutoPlay:
                HandleTableAutoPlay(message.Data);
                break;
            case Path.TableRule:
                HandleTableRule(message.Data);
                break;
            case Path.TableDissolution:
                // HandleTableDissolution(message.Data);
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
        public object Data;
    }

    // Implement individual message handlers for each message type based on the enums in Game.tso.ts
    private void HandleAck(object data)
    {
        Debug.Log("HandleAck");
        // Implement the logic for handling the ack message
    }

    private void HandleLogin(object data)
    {
        // Implement the logic for handling the login message
    }

    private void HandleTableEnter(object data)
    {
        // Implement the logic for handling the table enter message
    }

    private void HandleTableEvent(object data)
    {
        Debug.Log("HandleTableEvent");
        // Implement the logic for handling the table event message
    }

    private void HandleTablePlay(object data)
    {
        // Implement the logic for handling the table play message
    }

    private void HandleTableResult(object data)
    {
        // Implement the logic for handling the table result message
    }

    private void HandleTableEnd(object data)
    {
        // Implement the logic for handling the table end message
    }

    private void HandleTableAutoPlay(object data)
    {
        // Implement the logic for handling the table auto-play message
    }

    private void HandleTableRule(object data)
    {
        // Implement the logic for handling the table rule message
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
