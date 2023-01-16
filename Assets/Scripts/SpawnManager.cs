using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(38.8f, 0f, 0f);
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //Debug.Log(playerControllerScript.gameOver);
        StartCoroutine(SpawnObstacle(obstaclePrefab, 3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnObstacle(GameObject go, float delay)
    {
        //fonctionne mais spawn un dernier obstacle après game over(solved dans move left avec un else)
        while(playerControllerScript.gameOver == false)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(go, spawnPos, go.transform.rotation);
        }

    }
}
