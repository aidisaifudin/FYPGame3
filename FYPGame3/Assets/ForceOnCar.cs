using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceOnCar : MonoBehaviour
{
    public float speed = 1.0f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*speed* Time.deltaTime) ;
    }
}
