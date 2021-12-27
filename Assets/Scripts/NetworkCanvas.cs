using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UNET;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkCanvas : MonoBehaviour
{
    public TMP_Dropdown kek;
    public TMP_InputField kek2;
    public Canvas _Canvas;
    public Canvas me;
    public Camera main;
    public NetworkManager nm;
    private string selectedClass;

    public void StartServer()
    {
        me.gameObject.SetActive(false);
        _Canvas.gameObject.SetActive(true); 
        //main.gameObject.SetActive(false);
        NetworkManager.Singleton.StartServer();
        Debug.Log("Server started...");
        //SceneManager.LoadScene("Main");
    }
    public void StartClient()
    {
        Player.ChangeClass(kek.options[kek.value].text);
        //nm.NetworkConfig.NetworkTransport = new UNetTransport().ConnectAddress;
        me.gameObject.SetActive(false);
        _Canvas.gameObject.SetActive(true);
        //main.gameObject.SetActive(false);
        NetworkManager.Singleton.StartClient();
        Debug.Log("Client started...");
        //SceneManager.LoadScene("Main");

    }    
    public void StartHost()
    {
        Player.ChangeClass(kek.options[kek.value].text);
        me.gameObject.SetActive(false);
        _Canvas.gameObject.SetActive(true);
        //main.gameObject.SetActive(false);
        NetworkManager.Singleton.StartHost();
        Debug.Log("Host started...");
        //SceneManager.LoadScene("Main");
    }
    
}