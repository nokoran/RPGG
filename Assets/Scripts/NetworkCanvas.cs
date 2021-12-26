using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UNET;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkCanvas : MonoBehaviour
{
    public InputField kek;

    private string selectedClass;

    public void StartServer()
    {
        NetworkManager.Singleton.StartServer();
        Debug.Log("Server started...");
        SceneManager.LoadScene("Main");
    }    
    public void StartClient()
    {
        //Player.ChangeClass(selectedClass);
        NetworkManager.Singleton.StartClient();
        Debug.Log("Client started...");
        SceneManager.LoadScene("Main");

    }    
    public void StartHost()
    {
        Player.ChangeClass(Convert.ToInt32(kek.transform.GetChild(1).GetComponent<Text>().text));
        Debug.Log("");
        NetworkManager.Singleton.StartHost();
        Debug.Log("Host started...");
        SceneManager.LoadScene("Main");
    }
}