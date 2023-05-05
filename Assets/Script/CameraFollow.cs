using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    Vector3 startingDistance;
    internal static object current;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerController.instance.transform;
        startingDistance = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowCharacter();
    }
    void FollowCharacter()
    {
        transform.position = new Vector3(target.position.x + startingDistance.x, startingDistance.y, target.position.z + startingDistance.z);
    }
}
