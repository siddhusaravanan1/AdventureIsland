using UnityEngine;

public class CameraController3 : MonoBehaviour
{
    public GameObject player;

    float newX;
    // Update is called once per frame
    void LateUpdate()
    {
        newX = player.transform.position.x;
        if (newX < -1)
        {
            newX = 0;
        }
        if(newX> 175)
        {
            newX = 176;
        }

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
