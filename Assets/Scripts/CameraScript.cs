using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform PlayerPos;

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = PlayerPos.position.y;
        transform.position = pos;
    }
}
