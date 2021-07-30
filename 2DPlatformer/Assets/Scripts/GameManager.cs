using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public int platformSpawnCount;
    public Vector3 lastEndPoint;


    public void SpawnPlatforms()
    {
        // 8 times
        for (int i = 0; i < platformSpawnCount; i++)
        {
           GameObject platform = GameObject.Instantiate(platformPrefab);
            Platform platformscript = platform.GetComponent<Platform>();
            
            platform.transform.position = lastEndPoint;

            lastEndPoint = platformscript.ReturnEndPoint();

        }
    }




    private void Awake()
    {
        //referance
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlatforms();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
