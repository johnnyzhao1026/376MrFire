using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimmerTrigger : MonoBehaviour
{
    GameParameter parameter;
    public GameObject timmer_Canvas;
    private int triggerTimes;
    public float secondsLeftToDestroy;
    public GameObject[] spawnEnemies; // index 0: zombie, index 1:

    private float nextTimeToSpawnEnemy = 1f;
    [Tooltip("proper rate is 0.5")]
    public float enemySpawnRate = 1f;
    private Vector3 spawnPos;
    private bool dangerZoneTriggered;
    

    // Start is called before the first frame update
    private void Awake()
    {
        parameter = GameObject.Find("GameParameterManager").GetComponent<GameParameter>();
        triggerTimes = 1;
        //timmer_Canvas.SetActive(false);
        secondsLeftToDestroy = parameter.Timmer_SecondsToCountDown;
        dangerZoneTriggered = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (triggerTimes <= 0)
        {
           
            Destroy(gameObject, secondsLeftToDestroy); // detroy trigger object by timmer
            
        }

        if (dangerZoneTriggered && secondsLeftToDestroy > 0)
        {
            StartCoroutine(EnemySpawner());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if (triggerTimes > 0)
            {
                StartCoroutine(waitToActiveTimer());
                 // enable a block wall
            }
            triggerTimes--;
        }
    }


    // active canvas timer ui
    IEnumerator waitToActiveTimer()
    {
        yield return new WaitForSeconds(0.5f);
        timmer_Canvas.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
        dangerZoneTriggered = true;
    }


    IEnumerator EnemySpawner()
    {
        
        yield return new WaitForSeconds(0.5f);
        if(Time.time >= nextTimeToSpawnEnemy)
        {
            spawnPos = new Vector3(transform.position.x + Random.Range(0, 10f), transform.position.y, transform.position.z + 5f);
            GameObject zombieInstance = Instantiate(spawnEnemies[0], spawnPos, Quaternion.identity);
            ExpendChaseRangeAtDangerZone(zombieInstance);
            nextTimeToSpawnEnemy = Time.time + 1/enemySpawnRate;
        }
    }

    void ExpendChaseRangeAtDangerZone(GameObject zombie)
    {
        zombie.GetComponent<EnemyAI>().chaseRange = 50f;
    }
}
