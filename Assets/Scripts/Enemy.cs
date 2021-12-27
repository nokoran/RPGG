using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float maxHP, HP, armor;
    private Vector3 eposition, pposition;
    private void Start()
    {
        maxHP = HP;
    }
    private void Update()
    {
        transform.GetComponent<NavMeshAgent>().SetDestination(Player.CurentPosition);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }
    public void TakeDamage()
    {
        HP -= PlayerCombat.damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        transform.GetChild(0).gameObject.transform.localScale -= new Vector3(PlayerCombat.damage / maxHP, 0, 0);
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
