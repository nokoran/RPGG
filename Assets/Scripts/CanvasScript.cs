using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    private Image[] MyItems;
    public Text tears, speed, range, shotspeed;
    private static Image m_Image;
    public Canvas Canvas;
    public static Canvas myCanvas;

    private void Start()
    {
        myCanvas = Canvas;
        tears.text += Player.tears;
        speed.text += Player.speed;
        range.text += Bullet.range;
        shotspeed.text += Bullet.shotspeed;

    }
    private void Update()
    {
        
    }
    public static void AddNewItem(Sprite ItemImage)
    {
        M1:
        var newItem = (GameObject) Instantiate(Resources.Load("ItemImageTemplate", typeof(GameObject))) as GameObject;
        if (newItem == null) goto M1;
        newItem.gameObject.transform.SetParent(myCanvas.transform);
        newItem.gameObject.GetComponent<Image>().sprite = ItemImage;
        newItem.transform.localScale = Vector3.one;
        newItem.transform.localRotation = Quaternion.Euler (Vector3.zero);
        newItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(350f, 230f);
    }
}
