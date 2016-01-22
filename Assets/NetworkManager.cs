using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System;

//Script to handle and and send UDP messages
public class NetworkManager : MonoBehaviour
{
    //Port should be 4445
    //Variables to be set by incoming message
    //public bool reset;
    public bool end;
    public string emotion;
    public string game;
    public int number;
    public bool goOn = false;
    public string[] pictures;

    // Singleton membership
    static NetworkManager instance;//used by all other scripts to access variables and methods in NetworkManager

    bool shouldQuit = false;//becomes true if recieves message "exit" meaning program will quit
    // Read Thread
    Thread readThread;
    // Udpclient object
    UdpClient client;

    // Port number
    public int port = 4445;
    //public string remote_ip = "127.0.0.1";

    // UDP packet store
    string lastReceivedPacket = "";
    public List<string> allReceivedPackets; // this one has to be cleaned up from time to time

    // Get Instance
    public static NetworkManager GetInstance()
    {
        return instance;
    }

    // Use for initialization
    void Awake()
    {
        // Check for singleton membership
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        // Create thread for reading UDP messages
        readThread = new Thread(new ThreadStart(ReceiveData));
        readThread.IsBackground = true;
        readThread.Start();
    }

    // Unity Update Function
    void Update()
    {
        // check button "s" to abort the read-thread
        if (Input.GetKeyDown("q"))
            stopThread();
        if (shouldQuit)
        {
            Application.Quit();
        }

    }

    // Unity Application Quit Function
    void OnApplicationQuit()
    {
        stopThread();
    }

    // Stop reading UDP messages
    private void stopThread()
    {
        if (readThread.IsAlive)
        {
            readThread.Abort();
        }
        client.Close();
    }

    // Receive thread function
    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (true)
        {
            try
            {
                // Receive bytes
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);

                // Encode UTF8-coded bytes to text format
                string text = Encoding.UTF8.GetString(data);

                // Show received message
                Debug.Log("Recieved message from UDP: " + text);

                // Store new massage as latest message
                lastReceivedPacket = text;

                //Call HandleMessage
                HandleUDPMessage(text);

                // Update received messages
                allReceivedPackets.Add(text);

            }
            catch (Exception err)
            {
                Debug.Log(err.ToString());
            }
        }
    }

    // Send a message to some client
    public void SendUDPMessage(String message)
    {
        try
        {

            Byte[] data = Encoding.UTF8.GetBytes(message);
            if (client != null)
            {
                Debug.Log("Sent UDP message: " + message + " on port " + port.ToString()/*+ " to " + remote_ip + ":" + port.ToString()*/);
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Broadcast /*IPAddress.Parse("192.168.0.104")*/, port);
                client.Send(data, data.Length, anyIP);
            }
            else
            {
                client = new UdpClient(port);
                SendUDPMessage(message);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    // Return the latest message
    public string getLatestPacket()
    {
        return lastReceivedPacket;
    }

    // Handle a recieved message
    void HandleUDPMessage(String message)
    {

        Debug.Log("Handled Message from server:" +
                   " " + message);
        string[] temp = message.Split(" ".ToCharArray());
        Debug.Log("First word is  " + temp[0]);
        switch (temp[0])
        {
            case "play":
            case "copy":
			case "eye":
                game = temp[0];
                break;
            case "recognize":
                game = temp[0];
                Debug.Log("Second word is  " + temp[1]);
                emotion = temp[1];
                break;
            case "select":
                game = temp[0];
                Debug.Log("Second word is  " + temp[1]);
                emotion = temp[1];
                pictures = temp;
                break;
            case "identify":
                game = temp[0];
                Debug.Log("Second word is  " + temp[1]);
                emotion = temp[1];
                number = Convert.ToInt32(temp[2]);
                break;
            case "default":
            case "main":
                game = "Main Game Screen";
                break;
            case "go":
                goOn = true;
                break;
            case "exit":
                shouldQuit = true;
                break;
            case "finished":
                end = true;
                break;

            //case "reset":
            //    reset = true;
            //    break;
            default:
                Debug.Log("Recieved non-command message: " + message);
                break;
        }


    }

    public void GoToMain()
    {
        SendUDPMessage("finished");
        game = "Main Game Screen";
        Application.LoadLevel(game);
    }
}
