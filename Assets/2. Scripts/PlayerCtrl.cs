using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float speed = 20.0f;
    private float turmSpeed = 20.0f;
    private float h;
    private float v;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        // 장비 움직이기
        transform.Translate(Vector3.forward * Time.deltaTime * speed * v);
        // transform.Rotate(Vector3.up, h * turmSpeed * Time.deltaTime);

        if(v != 0)
        {
            transform.Rotate(Vector3.up, h * turmSpeed * Time.deltaTime);
        }
    }
}
