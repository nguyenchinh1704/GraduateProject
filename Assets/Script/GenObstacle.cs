using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenObstacle : MonoBehaviour
{

    public GameObject wall, wallFire;
    public GameObject wallContainer, wallFireContainer;
    public int numberWall, distanceWall, numberWallFire, distanceWallFire;

    public void GenObject()
    {
        for (int i = 0; i < numberWall; i++)
        {
            GameObject wallClone = Instantiate(wall, wallContainer.transform);
            wallClone.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y, wall.transform.position.z +  distanceWall*i);
        }
        for (int i = 0; i < numberWallFire; i++)
        {
            GameObject wallFireClone = Instantiate(wallFire, wallFireContainer.transform);
            wallFireClone.transform.position = new Vector3(wallFire.transform.position.x, wallFire.transform.position.y, wallFire.transform.position.z + distanceWallFire * i);
        }
    }    
    // Start is called before the first frame update
    void Start()
    {
        GenObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
