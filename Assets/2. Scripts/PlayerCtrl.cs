using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] private float horsePower = 20.0f;
    [SerializeField] private float turmSpeed = 20.0f;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    private float h;
    private float v;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        // 장비 움직이기
        speed = Mathf.Round(rb.velocity.magnitude * 2.237f);
        speedometerText.SetText($"Speed : {speed}");

        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText($"RPM : {rpm}");

        rb.AddRelativeForce(Vector3.forward * horsePower * v);

        if(v != 0)
        {
            transform.Rotate(Vector3.up, h * turmSpeed * Time.deltaTime);
        }
    }
}
