using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawncontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField]
    GameObject enemyPrefab;
    float timer =0;
    [SerializeField]
    float timeBetweenEnemies=1.5f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >timeBetweenEnemies)
        {
        Instantiate(enemyPrefab);   
        timer = 0;
        }
    }
}
