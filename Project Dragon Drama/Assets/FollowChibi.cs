using UnityEngine;

public class FollowChibi : MonoBehaviour
{

    public Transform player;

    private Vector3 offset = new Vector3(0, 7, -10); // Offset

    void Update()
    {
        transform.position = player.position + offset;
        transform.LookAt(player.position + Vector3.up);
    }

}
