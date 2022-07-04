using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private LevelManager levelManager;

    public int damageGiven;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")  && gameObject.CompareTag("Enemy"))
        {
            //anim.SetBool("attack", true);

            levelManager.HurtPlayer(damageGiven);
            levelManager.Respawn();

            //anim.SetBool("attack", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Obstacle"))
        {
            levelManager.HurtPlayer(damageGiven);
            levelManager.Respawn();
        }
    }


}
