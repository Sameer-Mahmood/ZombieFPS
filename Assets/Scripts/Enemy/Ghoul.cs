using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghoul : MonoBehaviour
{
    public GameObject player;
    Animation anim;
    public float damage = 20f;
    public float zHealth = 100f;
    public AudioSource aud_a, aud_d;

    public void zHit(float pDamage)
    {
        zHealth -= pDamage;
        if (zHealth <= 0)
        {
            foreach (AnimationState state in anim)
            {
                anim.Play("Death");
            }
            aud_d.Play();
            playerCasting.score += 50;
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            foreach (AnimationState state in anim)
            {
                anim.Play("Run");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<playerCasting>().Hit(damage);
            foreach (AnimationState state in anim)
            {
                anim.Play("Attack1");
            }
            aud_a.Play();
        }
    }
}
