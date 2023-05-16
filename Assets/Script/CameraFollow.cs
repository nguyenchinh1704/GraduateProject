using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 startingDistance;
    public SOCoin data;
    internal static object current;
    public static CameraFollow instance;

    private void OnEnable()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        /*target = PlayerController.instance.transform;*/
        startingDistance = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowCharacter();
    }
    void FollowCharacter()
    {
        transform.position = new Vector3(target.position.x + startingDistance.x, transform.position.y, target.position.z - 3);
    }
}
