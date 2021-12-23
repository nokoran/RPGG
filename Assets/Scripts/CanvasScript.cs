using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    private Image[] MyItems;
    public Text tears, speed, range, shotspeed;
    public static Text tears1, speed1, range1, shotspeed1;
    private static Image m_Image;
    public Canvas Canvas;
    public static Canvas MyCanvas;

    private void Start()
    {
        MyCanvas = Canvas;
        tears1 = tears;
        speed1 = speed;
        range1 = range;
        shotspeed1 = shotspeed;
        
        StatsChanged();
    }

    public static void StatsChanged()
    {
        tears1.text = "Tears: " + Convert.ToString(Player.tears);
        speed1.text = "Speed: " + Convert.ToString(Player.speed);
        range1.text = "Range: " + Convert.ToString(Bullet.range);
        shotspeed1.text = "ShotSpeed: " + Convert.ToString(Bullet.shotspeed);
    }
    
    public static void AddNewItem(Sprite ItemImage)
    {
        M1:
        var newItem = (GameObject) Instantiate(Resources.Load("ItemImageTemplate", typeof(GameObject))) as GameObject;
        if (newItem == null) goto M1;
        newItem.gameObject.transform.SetParent(MyCanvas.transform);
        newItem.gameObject.GetComponent<Image>().sprite = ItemImage;
        newItem.transform.localScale = Vector3.one;
        newItem.transform.localRotation = Quaternion.Euler (Vector3.zero);
        newItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(350f, 230f);
    }
}
