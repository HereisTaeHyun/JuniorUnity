using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public GameObject Propeller;
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI flightTimeText;
    private bool isGameover;
    private float flightTime;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        isGameover = false;
        rb = GetComponent<Rigidbody>();
        flightTime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isGameover == true)
        {
            return;
        }
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right, verticalInput * rotationSpeed * Time.deltaTime);

        Propeller.transform.Rotate(new Vector3(0, 0, 1000) * Time.deltaTime);

        flightTime += Time.deltaTime;

        flightTimeText.text = $"{(int)flightTime}";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Wall"))
        {
            rb.velocity = Vector3.zero;
            gameoverText.text = "Game Over ! ";
            isGameover = true;
            Debug.Log("GameOver");
        }
    }
}
