using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerBehaviour : MonoBehaviour
{
    [SerializeField]
    int speed;

    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
	}

    void OnCollisionEnter2D(Collision2D cd)
    {
        if(cd.gameObject.tag=="Enemy")
        {
            Destroy(cd.gameObject);
        }
        else if(cd.gameObject.tag=="Snail")
        {
            cd.gameObject.GetComponent<SnailBehaviour>().isDead = true;
            cd.gameObject.GetComponent<SnailBehaviour>().DeathAnimation();
        }
        Destroy(gameObject);
    }

}
