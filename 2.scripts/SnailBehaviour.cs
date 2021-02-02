using UnityEngine;

public class SnailBehaviour : MonoBehaviour
{
    public bool isDead = false;

    Animator anim;

    float initialPos;
    bool isTurn = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        initialPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Tuner();
            transform.Translate(2.5f * Time.deltaTime, 0, 0);
        }
    }
    public void DeathAnimation()
    {
        GetComponent<Collider2D>().isTrigger = true;
        anim.SetTrigger("isDead");
        Destroy(gameObject, 0.5f);
    }
    void Tuner()
    {
        if (transform.position.x > initialPos + 5)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (transform.position.x < initialPos - 5)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
