using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public Transform Camera;
    public int q;

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        float targetY = Camera.position.y;

        targetY = Mathf.Round(targetY * 1000f) / 1000f;

        pos.y = targetY;

        transform.position = pos;
        
        
    }
}