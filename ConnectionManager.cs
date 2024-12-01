using UnityEngine;
using Photon.Chat;
using ExitGames.Client.Photon;
using System;

public class ConnectionManager : MonoBehaviour, IChatClientListener
{
    private ChatClient chatClient;
    public string DefaultChannel = "GlobalChannel"; // Default chat channel
    private string currentUserId;
    public string currentMessage = "0";
    //public bool newCount = false;
    //public int messageCount = 0;


    private void Start()
    {
        // Initialize the Chat Client
        chatClient = new ChatClient(this, ConnectionProtocol.Udp);
        chatClient.Connect("4d689ee7-f21f-4815-af5a-6818cd060876", "1.0", 
            new AuthenticationValues("User_" + UnityEngine.Random.Range(1000, 9999)));
    }

    public void SendChatMessage(string message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            // Publish the message to the default channel
            chatClient.PublishMessage(DefaultChannel, message);
            Debug.Log($"Sent message: {message}");
        }
    }
    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < messages.Length; i++)
        {

            string newMessage = messages[i].ToString();
            currentMessage = newMessage;
        }
    }

    private void Update()
    {
        // Ensure the chat client is updated
        if (chatClient != null)
        {
            chatClient.Service();
        }
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log($"Photon Chat Debug ({level}): {message}");
    }

    public void OnConnected()
    {
        Debug.Log("Connected to Photon Chat!");
        chatClient.Subscribe(new string[] { DefaultChannel }); // Subscribe to the default channel

        currentUserId = chatClient.AuthValues.UserId;
    }

    public void OnDisconnected()
    {
        Debug.Log("Disconnected from Photon Chat.");
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log($"Chat state changed: {state}");
    }

    

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        
        Debug.Log($"Private message from {sender}: {message}");
        
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log($"Subscribed to channel(s): {string.Join(", ", channels)}");
    }

    public void OnUnsubscribed(string[] channels)
    {
        Debug.Log($"Unsubscribed from channel(s): {string.Join(", ", channels)}");
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log($"Status update from {user}: {status} - {message}");
    }

    public void OnUserSubscribed(string channel, string user)
    {
        Debug.Log($"User {user} subscribed to channel {channel}.");
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        Debug.Log($"User {user} unsubscribed from channel {channel}.");
    }

    

    

    public void SendMessagePrivatley(string message)
    {
        if (!string.IsNullOrEmpty(currentUserId))
        {
            chatClient.SendPrivateMessage(currentUserId, message);
        }
    }
    private void OnApplicationQuit()
    {
        chatClient?.Disconnect();
    }
}
