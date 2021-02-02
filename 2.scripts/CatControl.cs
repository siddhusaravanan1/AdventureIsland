using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatControl : MonoBehaviour
{

	float dirX;
	public float moveSpeed = 5f;
	Rigidbody2D rb;
	bool facingRight = true;
	Vector3 localScale;

	// Use this for initialization
	void Start () {
		localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		dirX = Input.GetAxis ("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoJump();
        }
    }

	void FixedUpdate()
	{
		rb.velocity = new Vector2 (dirX * moveSpeed,rb.velocity.y);
        
	}

    void DoJump()
    {
       rb.AddForce(new Vector2(0, 700), ForceMode2D.Force); 
    }
	void LateUpdate()
	{		
		CheckWhereToFace ();
	}

	void CheckWhereToFace ()
	{
		if (dirX > 0)
			facingRight = true;
		else if (dirX < 0)
			facingRight = false;
		
		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;
		
		transform.localScale = localScale;
	}

}
