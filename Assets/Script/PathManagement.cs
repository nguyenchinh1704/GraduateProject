using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManagement : MonoBehaviour
{

    public GameObject slidingGate, gateContainer, finishLine, coin1, coin2, coin3, coinContainer;
    public int gateNumber, distanceGate;
    public float lengthPath;
    public GameObject path1, path2, path3, pathContainer;
    public int numCoinInPath1, numCoinInPath2, numCoinInPath3, startPositionCoinPath1, startPositionCoinPath2, startPositionCoinPath3;

    public static PathManagement instance;
    private void OnEnable()
    {
        instance = this;
    }

    public void GenGate()
    {
        for (int i = 0; i < gateNumber ; i++)
        {
            GameObject gateClone = Instantiate(slidingGate, gateContainer.transform);
            gateClone.transform.position = new Vector3(slidingGate.transform.position.x, slidingGate.transform.position.y, slidingGate.transform.position.z + distanceGate * i);
        }
    }

    public void GenPath(GameObject path)
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject pathClone = Instantiate(path, pathContainer.transform);
            pathClone.transform.position = new Vector3(path.transform.position.x, path.transform.position.y, path.transform.position.z + lengthPath);
        }
    }
    public void GenCoin(int numCoin,int startPositionCoinPath, GameObject path, GameObject coin)
    {
        float heightCoin = 0.5f;
        for (int i = 0; i < numCoin; i++)
        {
            GameObject coinClone = Instantiate(coin, coinContainer.transform);
            coinClone.transform.position = new Vector3(path.transform.position.x, path.transform.position.y + heightCoin, startPositionCoinPath + i* (lengthPath- startPositionCoinPath)/numCoin);
        }
    }
    
    void Start()
    {
        finishLine.transform.position = new Vector3(finishLine.transform.position.x, finishLine.transform.position.y, finishLine.transform.position.z + lengthPath);
        GenCoin(numCoinInPath1, startPositionCoinPath1, path1, coin1);
        GenCoin(numCoinInPath2, startPositionCoinPath2, path2, coin2);
        GenCoin(numCoinInPath3, startPositionCoinPath3, path3, coin3);
        GenGate();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Die1")
        {
            GameManagement.instance.menuDefeat.show();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
