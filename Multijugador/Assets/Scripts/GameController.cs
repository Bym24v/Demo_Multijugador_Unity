using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using System;

public class GameController : MonoBehaviour {

    [Header("Login")]
    public GameObject panelLogin;
    public InputField inputUsr;
    public InputField inputPwd;

    // Socket
    public SocketIOComponent socket;


    void Start () {

        // Get Socket
        socket = GetComponent<SocketIOComponent>();

        // Events
        socket.On("login", OnLogin);
	}

    

    void Update () {
		
	}

    public void UILogin()
    {

    }

    private void OnLogin(SocketIOEvent obj)
    {
        throw new NotImplementedException();
    }
}
