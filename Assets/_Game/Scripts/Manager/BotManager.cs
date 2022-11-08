using System.Collections.Generic;
using UnityEngine;

public class BotManager : Singleton<BotManager>
{
    public Transform transform;
    public Transform player;
    public GameObject botPrefab;
    private Queue<GameObject> botQueue;
    [SerializeField] private List<GameObject> spawnedList;
    public LayerMask groundLayer;
    private float xPos;
    private float zPos;
    [SerializeField] private int enemyCount;
    [SerializeField] private int botAlive;
    [SerializeField] private int poolSize;

    private void Start() 
    {
        botQueue = new Queue<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject newBot = GenerateNewBot();

            botQueue.Enqueue(newBot);
        }
    }

    public GameObject GenerateNewBot()
    {
        GameObject gameObject = Instantiate(botPrefab);
        gameObject.SetActive(false);
        gameObject.transform.position = player.position;
        gameObject.transform.parent = transform;
        return gameObject;
    }

    public void SpawnBotFromPool()
    {   
        while(enemyCount < 7 && botAlive >= 7)
        {
            Vector3 playerPos = player.position;
            Vector3 spawnPos;

            playerPos = player.position;
            Vector2 randomPos = Random.insideUnitCircle.normalized;
            int randomRange = Random.Range(10, 40);
            xPos = randomPos.x * randomRange;
            zPos = randomPos.y * randomRange;

            spawnPos = new Vector3(playerPos.x + xPos, playerPos.y, playerPos.z + zPos); 

            if(Physics.Raycast(spawnPos, -player.transform.up, Mathf.Infinity, groundLayer))
            {
                GameObject objectToSpawn = botQueue.Dequeue();
                spawnedList.Add(objectToSpawn);
                objectToSpawn.SetActive(true);
                objectToSpawn.transform.position = spawnPos;

                Character botScript = objectToSpawn.GetComponent<Character>();
                botScript.BotOnSpawn();
                enemyCount++;
            }
        }
    }
    public void ReturnBotToPool(GameObject returnedBot)
    {
        spawnedList.Remove(returnedBot);
        botQueue.Enqueue(returnedBot);
        enemyCount--;
        botAlive--;
    }

    public void Restart()
    {
        for(int i = 0; i < spawnedList.Count; i++)
        {
            spawnedList[i].SetActive(false);
            botQueue.Enqueue(spawnedList[i]);
        }
        spawnedList.Clear();
    }

    public int GetBotAlive()
    {
        return botAlive;
    }
}
