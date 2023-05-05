using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenCube : MonoBehaviour
{
    public List<GameObject> listObjectParent;
    public GameObject parentObject1;
    public GameObject parentObject2;
    public GameObject parentObject3;
    public GameObject parentObject4;
    public GameObject parentObject5;
    public GameObject parentObject6;
    public GameObject parentObject7;
    public GameObject parentObject8;
    public GameObject objectContainer1;
    public GameObject objectContainer2;
    public GameObject objectContainer3;
    public GameObject objectContainer4;
    public GameObject objectContainer5;
    public GameObject objectContainer6;
    public GameObject objectContainer7;
    public GameObject objectContainer8;
    public int numberChildpath;
    /* public Transform childObject1;
     public Transform childObject2;
     public Transform childObject3;
     public Transform childObject4;
     public Transform childObject5;
     public Transform childObject6;
     public Transform childObject7;
     public Transform childObject8;*/
    // Start is called before the first frame update
    void Start()
    {
        GenChildCube();
    }

    public void GenChildCube()
    {
        for (int i = 0; i < numberChildpath; i++)
        {
            GameObject childObject1 = Instantiate(parentObject1, objectContainer1.transform);
            childObject1.transform.position = new Vector3(parentObject1.transform.position.x, parentObject1.transform.position.y, parentObject1.transform.position.z + 6 * i);

            GameObject childObject2 = Instantiate(parentObject2, objectContainer2.transform);
            childObject2.transform.position = new Vector3(parentObject2.transform.position.x, parentObject2.transform.position.y, parentObject2.transform.position.z + 6 * i);

            GameObject childObject3 = Instantiate(parentObject3, objectContainer3.transform);
            childObject3.transform.position = new Vector3(parentObject3.transform.position.x, parentObject3.transform.position.y, parentObject3.transform.position.z + 6 * i);

            GameObject childObject4 = Instantiate(parentObject4, objectContainer4.transform);
            childObject4.transform.position = new Vector3(parentObject4.transform.position.x, parentObject4.transform.position.y, parentObject4.transform.position.z + 6 * i);

            GameObject childObject5 = Instantiate(parentObject5, objectContainer5.transform);
            childObject5.transform.position = new Vector3(parentObject5.transform.position.x, parentObject5.transform.position.y, parentObject5.transform.position.z + 6 * i);

            GameObject childObject6 = Instantiate(parentObject6, objectContainer6.transform);
            childObject6.transform.position = new Vector3(parentObject6.transform.position.x, parentObject6.transform.position.y, parentObject6.transform.position.z + 6 * i);

            GameObject childObject7 = Instantiate(parentObject7, objectContainer7.transform);
            childObject7.transform.position = new Vector3(parentObject7.transform.position.x, parentObject7.transform.position.y, parentObject7.transform.position.z + 6 * i);

            GameObject childObject8 = Instantiate(parentObject8, objectContainer8.transform);
            childObject8.transform.position = new Vector3(parentObject8.transform.position.x, parentObject8.transform.position.y, parentObject8.transform.position.z + 6 * i);

        }
       
    }
    // Update is called once per frame
    void Update()
    {

    }
}
