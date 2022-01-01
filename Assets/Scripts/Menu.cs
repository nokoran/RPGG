using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UNET;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public TMP_Dropdown Dropdown;

    private string selectedClass;
    
    public void StartMain()
    {
        Player.ChangeClass(Dropdown.options[Dropdown.value].text);
        SceneManager.LoadScene("Main");
    }
}