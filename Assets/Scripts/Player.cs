using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Rigidbody2D _rb;
    private float _userInputHorizontal, _userInputVertical;
    private Vector3 _vec;
    public static float angle;
    private bool fire = false, abilitytofire = true;
    public GameObject Bullet;
    public Transform Mouth;
    public static Vector3 position;

    
    void FireDelay()
    {
        abilitytofire = true;
    }
    
    void Update()
    {
        position = transform.position;
        _userInputHorizontal = Input.GetAxis("Horizontal");
        _userInputVertical = Input.GetAxis("Vertical");
        _vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(_vec.y, _vec.x) * Mathf.Rad2Deg;
        if (Input.GetMouseButton(0) && abilitytofire)
        {
            fire = true;
            abilitytofire = false;
            Invoke("FireDelay", 0.1f);
        }

    }

    private void FixedUpdate()
    {

        _rb.velocity = new Vector2(_userInputHorizontal*7, _userInputVertical*7);
        _rb.rotation = angle;
        if (fire)
        {
            Instantiate(Bullet, Mouth.position, transform.rotation);
            fire = false;
        }

    }

}