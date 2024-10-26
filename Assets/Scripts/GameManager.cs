using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Falling_Object;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate; // jak szybko bed¹ siê spawnowa³y spadaj¹ce obiekty

    bool gameStarted = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)// kiedy klikniemy na ekran i gra sie jeszcze sie nie zaczê³a
        {
            StartSpawn(); //zaczynamy spawnowac
            gameStarted = true;
        } 
    }

    private void StartSpawn()
    {
        InvokeRepeating("SpawnBlock", 3f, spawnRate);
    }
    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position; // odnosimy sie do naszego Spawn pointu
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(Falling_Object, spawnPos, Quaternion.identity); 
        
    }

}
