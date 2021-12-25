using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float maxHP, HP, armor;
    public Transform player;
    private void Start()
    {
        maxHP = HP;
    }
    private void Update()
    {
        transform.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            HP -= Bullet.damage;
            Destroy(other.gameObject);
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
            transform.GetChild(0).gameObject.transform.localScale -= new Vector3(Bullet.damage/maxHP, 0, 0);
            if (HP <= 50 && HP > 20)
            {
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color32(233, 124, 0, 255);
            }
            if (HP <= 20)
            {
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
