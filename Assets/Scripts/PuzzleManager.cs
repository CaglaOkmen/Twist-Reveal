using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Transform cam;
    Vector3 target = new Vector3(0f, 0f, 0f);
    Quaternion targetRot;
    public float threshold = 2f;
    bool isSolved = false;

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
            }
        }
        else
        {
            Debug.Log("Kazandin.");
        }
    }
}
