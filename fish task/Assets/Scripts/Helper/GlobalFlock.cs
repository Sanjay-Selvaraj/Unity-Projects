using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour
{
    public GameObject fishPrefab;
    public static int tankSize = 5;

    static int numFish = 10;
    public static GameObject[] allFish = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numFish; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize));
            Quaternion rot = Quaternion.Euler(0, 0, 0);
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, rot);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize), 0, Random.Range(-tankSize, tankSize));
        }
    }
}
