using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float speed;
    public float angSpeed;


    private Rigidbody rb;

 

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {

        transform.Rotate(0f, 50f, 0f);
    }
}

