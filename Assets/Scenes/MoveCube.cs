using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speedRun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCubeRun();
    }
    public void MoveCubeRun()
    {
        transform.Translate(1 * speedRun * Time.deltaTime, 0, 0);
    }
}
