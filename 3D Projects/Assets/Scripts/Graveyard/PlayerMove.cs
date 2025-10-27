using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    [SerializeField]
    float speed;

    Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        transform.position += movementInput * speed * Time.deltaTime;
    }
}
