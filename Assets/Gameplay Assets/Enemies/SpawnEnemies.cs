﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public float baseSpawnRate = 2;
    public GameObject enemyObject;
    private int difficulty;
    private float cameraWidth;
    private float randPos;
    private int randSprite;
    private string[] enemySprites = { "redGub", "blueGub", "greenGub" };
    private Vector2 spriteSize;
    private float spawnTimer;

    // Use this for initialization
    void Start() {
        spawnTimer = 0;
        spriteSize = enemyObject.GetComponent<SpriteRenderer>().bounds.extents;
        TriggerSpawn();
    }

    // Update is called once per frame
    void Update() {
        TriggerSpawn();
    }

    void TriggerSpawn(){
        cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
        if (spawnTimer <= 0) Spawn();
        spawnTimer -= Time.deltaTime;
    }

    private void ResetSpawnTimer(){
        spawnTimer = baseSpawnRate/PlayerPrefs.GetInt("difficulty", 1);
    }

    private void Spawn() {
        randSprite = Random.Range(0, enemySprites.Length - 1);
        enemyObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(enemySprites[randSprite]);
        randPos = Random.Range(-cameraWidth+spriteSize.x, cameraWidth-spriteSize.x);
        Vector2 position = new Vector2(randPos, 2f * Camera.main.orthographicSize);
        ResetSpawnTimer();
        Instantiate(enemyObject, position, transform.rotation);
    }
}
