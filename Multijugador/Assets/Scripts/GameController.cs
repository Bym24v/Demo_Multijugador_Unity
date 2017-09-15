using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using System;

public class GameController : MonoBehaviour
{

    [Header("Login")]
    public GameObject panelLogin;
    public InputField inputUsr;
    public InputField inputPwd;

    [Header("Local Player")]
    public GameObject localPlayer;

    [Header("Other Client")]
    public GameObject otherClient;

    // Socket
    public SocketIOComponent socket;


    void Start()
    {

        // Get Socket
        socket = GetComponent<SocketIOComponent>();

        // Events
        socket.On("otherClient", OnReceiveClient);
        socket.On("login", OnLogin);


        // Start
        StartCoroutine("StartServer");
    }



    private IEnumerator StartServer()
    {
        yield return new WaitForSeconds(1f);

        // Todos los clientes 
        socket.Emit("otherClient");

    }

    void Update()
    {

    }

    public void UILogin()
    {

        if (inputUsr.text != "" && inputPwd.text != "")
        {
            // Packet Data Login
            var data = new Dictionary<string, string>();
            data["name"] = inputUsr.text;
            data["pwd"] = inputPwd.text;
            socket.Emit("login", new JSONObject(data));
        }
        else
        {
            inputUsr.text = "dev";
            inputPwd.text = "dev";
        }

    }

    // Local client
    private void OnLogin(SocketIOEvent obj)
    {
        Debug.Log("recv >> " + "Name" + obj.data.GetField("name"));
    }

    // Other Client
    private void OnReceiveClient(SocketIOEvent obj)
    {
        Debug.Log(obj);
    }

    public void OnApplicationExit()
    {
        Debug.Log("close");
    }
}
