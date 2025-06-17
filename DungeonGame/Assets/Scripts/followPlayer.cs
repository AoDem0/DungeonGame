using UnityEngine;

public class followPlayer : MonoBehaviour
{
    [SerializeField]private Transform player;
    private Vector3 offset;
    [SerializeField] private float followSpeed = 2f;


    void FixedUpdate()
    { 
        offset = new Vector3(player.position.x, player.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, offset, followSpeed);
    }
}
