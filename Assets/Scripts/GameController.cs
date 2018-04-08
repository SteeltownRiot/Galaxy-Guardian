using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWaveDelay,
                 startDelay,
                 waveWait;

    // Use this for initialization
    void Start()
    {
        StartCoroutine (SpawnWaves());
    }

    // Coroutine to allow wave spawning to pause without pausing the whole game
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPostion = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPostion, spawnRotation);
                yield return new WaitForSeconds(startDelay);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
	
	//// Update is called once per frame
	//void Update ()
    //{
		
	//}
}
