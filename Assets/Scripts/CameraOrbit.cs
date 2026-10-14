using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public float speed = 0.2f;
    float min = -20f;
    float max = 80f;
    float currentAngleX;
    float currentAngleY;

    Vector3 previousMousePos;
    
    void Start()
    {
        currentAngleX = transform.eulerAngles.x;
        currentAngleY = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            previousMousePos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePos = Input.mousePosition;
            Vector3 direction = currentMousePos - previousMousePos;
            
            currentAngleX -= direction.y * speed;
            currentAngleX = Mathf.Clamp(currentAngleX, min, max);
            currentAngleY += direction.x * speed;

            previousMousePos = currentMousePos;
        }

        transform.rotation = Quaternion.Euler(currentAngleX, currentAngleY, 0);
    }
}
