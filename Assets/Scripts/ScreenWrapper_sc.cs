using UnityEngine;

public class ScreenWrapper_sc : MonoBehaviour
{
    public float padding = 0.4f;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        if (cam == null) return;

        Vector3 pos = transform.position;

        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        float minX = cam.transform.position.x - halfWidth - padding;
        float maxX = cam.transform.position.x + halfWidth + padding;
        float minY = cam.transform.position.y - halfHeight - padding;
        float maxY = cam.transform.position.y + halfHeight + padding;

        if (pos.x > maxX)
            pos.x = minX;
        else if (pos.x < minX)
            pos.x = maxX;

        if (pos.y > maxY)
            pos.y = minY;
        else if (pos.y < minY)
            pos.y = maxY;

        transform.position = pos;
    }
}
