using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speedRun, speedJump;
    public int jumHeight;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCubeRun();
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }
    public void MoveCubeRun()
    {
        Vector3 movement = new Vector3(0, 0, 1);
        rb.AddForce(movement * speedRun * Time.deltaTime);
    }

    public float fallingSpeed;
    public void Jump()

    {
        //float yPosition = 0.5f;
        //// Don't let player fall through floor
        //if (transform.position.y <= 0.5f)
        //{
        //    fallingSpeed = 0.0f;
        //}
        //else
        //{
        //    fallingSpeed -= 9.8f * Time.deltaTime;
        //    yPosition += fallingSpeed * Time.deltaTime;
        //}
        //// Translate y-position
        //transform.Translate(new Vector3(0.0f, yPosition, 0.0f));
        transform.Translate(new Vector3(0, jumHeight * speedJump * Time.deltaTime, 0));
    }
}
