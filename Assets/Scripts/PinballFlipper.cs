using UnityEngine;

public class PinballFlipper : MonoBehaviour
{

    [SerializeField]
    KeyCode flipKey;

    [SerializeField]
    Rigidbody2D myBody;

    [SerializeField]
    float flipPower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(flipKey))
        {
            myBody.AddForce(transform.up * flipPower);
        }
    }
}
