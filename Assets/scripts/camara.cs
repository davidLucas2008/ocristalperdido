using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // arraste o Player aqui no inspetor
    public float smoothSpeed = 0.125f; // suaviza��o do movimento
    public Vector3 offset; // ajuste a posi��o da c�mera em rela��o ao player

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
