using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Transform cam;
    Vector3 target = new Vector3(0f, 0f, 0f);
    Quaternion targetRot;
    public float threshold = 1.5f;
    bool isSolved = false;
    public float speed = 3f;

    void Start()
    {
        targetRot = Quaternion.Euler(target);
    }

    void Update()
    {
        if (!isSolved)
        {
            float angleDiff = Quaternion.Angle(cam.rotation, targetRot);
            if (angleDiff < threshold)
            {
                isSolved = true;
                cam.GetComponent<CameraOrbit>().enabled = false;
            }
        }
        else
        {
            cam.rotation = Quaternion.Slerp(cam.rotation, targetRot, speed * Time.deltaTime);
            if (Quaternion.Angle(cam.rotation, targetRot) < 0.05f)
            {
                cam.rotation = targetRot;
                Debug.Log("Kazandin.");
                this.enabled = false;
            }
        }
    }
}
