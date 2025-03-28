using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  
    public Transform endPoint; 
    public Transform background; 
    public float smoothSpeed = 2f; 
    private float minX; 
    private float maxX; 

    void Start()
    {
        minX = transform.position.x; 
        maxX = endPoint.position.x;  
    }

    void Update()
    {
        if (player != null)
        {
            float targetX = Mathf.Clamp(player.position.x, minX, maxX);
            Vector3 newPos = new Vector3(targetX, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed * Time.deltaTime);

            if (background != null)
            {
                background.position = new Vector3(targetX * 0.9f, background.position.y, background.position.z);
            }
        }
    }
}

