using UnityEngine;

public class FollowHead : MonoBehaviour
{
    public Transform head;
    public float distance = 2f;
    public float height = 1.5f;

    void Update()
    {
        if (head == null) return;

        Vector3 forward = head.forward;
        forward.y = 0;
        forward.Normalize();

        transform.position = head.position + forward * distance + Vector3.up * height;
        transform.rotation = Quaternion.LookRotation(transform.position - head.position);
    }
}