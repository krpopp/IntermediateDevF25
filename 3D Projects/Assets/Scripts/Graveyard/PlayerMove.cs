using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    [SerializeField]
    float speed;

    Camera cam;

    [SerializeField]
    float rotationSmooth;

    float currentAngle, currentVel;

    CharacterController charController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        if(movementInput.magnitude >= 0.1f)
        {
            float target = Mathf.Atan2(movementInput.x, movementInput.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            currentAngle = Mathf.SmoothDampAngle(currentAngle, target, ref currentAngle, rotationSmooth);
            transform.rotation = Quaternion.Euler(0, currentAngle, 0);
            Vector3 rotateMove = Quaternion.Euler(0, target, 0) * Vector3.forward;
            charController.Move(rotateMove * speed * Time.deltaTime);
        }
        //transform.position += movementInput * speed * Time.deltaTime;
    }
}
