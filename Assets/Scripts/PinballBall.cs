using UnityEngine;

public class PinballBall : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D myBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myBody.bodyType = RigidbodyType2D.Dynamic;
            //myBody.linearVelocity = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "bumper":
                myBody.AddForce(transform.up * 500);
                break;
            case "flipper":
                myBody.AddForce(transform.up * 500);
                break;
            default:
                break;
        }
    }
}
