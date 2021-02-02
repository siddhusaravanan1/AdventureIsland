using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerBehaviour _playerBehaviour;

    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.gameObject.tag == "Floor")
        {
            _playerBehaviour.canJump = true;
        }
    }
}
