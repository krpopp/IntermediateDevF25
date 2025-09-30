using UnityEngine;

public class PinballDirection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("RotateDir", 0.2f, 0.2f);
    }

    void RotateDir()
    {
        transform.Rotate(0, 0, 90);
    }
}
