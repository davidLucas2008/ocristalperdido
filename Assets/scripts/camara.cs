using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // arraste o Player aqui no inspetor
    public float smoothSpeed = 0.125f; // suavização do movimento
    public Vector3 offset; // ajuste a posição da câmera em relação ao player

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}
