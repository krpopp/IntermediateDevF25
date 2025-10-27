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
        Vector3 newPos = transform.position;
        if (Input.GetKey(KeyCode.W)) newPos.z += speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) newPos.z -= speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) newPos.x -= speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) newPos.x += speed * Time.deltaTime;
        transform.position = newPos;
    }
}
