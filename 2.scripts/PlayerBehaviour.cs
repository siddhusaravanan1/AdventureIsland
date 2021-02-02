using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerBehaviour : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject dagger;
    public GameObject GameOverMenu;
    public GameObject Egg;
    public GameObject AttackB;
    public GameObject MoveR;
    public GameObject MoveL;

    public float moveSpeed = 5f;
    float dirX;

    int Life;

    Rigidbody2D rb;
    Animator anim;

    public bool canJump = false;
    bool facingRight = true;
    bool isSkating = false;

    Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Life = 3;
    }

    void DoJump()
    {
        if (canJump)
        {
            anim.SetTrigger("isJump");
            rb.AddForce(new Vector2(0, 675), ForceMode2D.Force);
            canJump = false;
        }

    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (facingRight)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (!facingRight)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }

    void Update()
    {
        //  dirX = Input.GetAxis("Horizontal");
        if (dirX != 0)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoJump();
        }
        if (Life == 0)
        {
            StartCoroutine(RestartMenu());
            StartCoroutine(Dead());
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }
    void LateUpdate()
    {
        CheckWhereToFace();
    }
    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.gameObject.tag == "Enemy")
        {
            if (!isSkating)
            {
                Life -= 1;
            }
            else if (isSkating)
            {
                dirX = 0;
                anim.SetBool("isSkating", false);
                AttackB.SetActive(true);
                Destroy(cd.gameObject);
            }
        }
        if (cd.gameObject.tag == "Snail")
        {
            if (!isSkating)
            {
                StartCoroutine(RestartMenu());
                StartCoroutine(Dead());
            }
            else if (isSkating)
            {
                dirX = 0;
                anim.SetBool("isSkating", false);
                AttackB.SetActive(true);
                MoveL.SetActive(true);
                MoveR.SetActive(true);
                Destroy(cd.gameObject);
            }
        }
        if (cd.gameObject.tag == "EndLevel")
        {
            SceneManager.LoadScene("Level2");
        }
        if (cd.gameObject.tag == "EndLevel2")
        {
            SceneManager.LoadScene("Level3");
        }
        if (cd.gameObject.tag == "EndLevel3")
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (cd.gameObject.tag == "Egg")
        {
            dirX = 1;
            isSkating = true;
            anim.SetBool("isSkating", true);
            Destroy(cd.gameObject);
            AttackB.SetActive(false);
            MoveL.SetActive(false);
            MoveR.SetActive(false);
        }
        else
        {
            MoveL.SetActive(true);
            MoveR.SetActive(true);
            AttackB.SetActive(true);
        }
    }
    public void Attack()
    {
        Instantiate(dagger, spawnPoint.transform.position, spawnPoint.transform.rotation);
        anim.SetTrigger("isAttack");
    }
    public void Right()
    {
        dirX = 1;
    }
    public void Left()
    {
        dirX = -1;
    }
    public void Stop()
    {
        dirX = 0;
    }
    public void Jump()
    {
        DoJump();
    }
    IEnumerator RestartMenu()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
    }
    IEnumerator Dead()
    {
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(1.5f);
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
