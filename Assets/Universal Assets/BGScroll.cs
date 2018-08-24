﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

    public float baseScrollSpeed = 5;
    private float cameraWidth;
    private float cameraHeight;
    private float scaleValue;
    private Vector2 savedOffset;

    void Start() {
        savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
        MaximizeToCamera();

    }

    void MaximizeToCamera(){
        cameraWidth = Camera.main.orthographicSize * Camera.main.aspect * 2f;
        cameraHeight = 2f * Camera.main.orthographicSize;
        scaleValue = cameraWidth > cameraHeight ? cameraWidth : cameraHeight;
        GetComponent<Renderer>().transform.localScale = new Vector3(scaleValue, scaleValue);
    }

    void Update() {
        MaximizeToCamera();
        float y = Mathf.Repeat( ScrollSpeed() * Time.time, 1);
        Vector2 offset = new Vector2(savedOffset.x, y);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable() {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }

    float ScrollSpeed(){
        switch (PlayerPrefs.GetInt("difficulty", 1)){
            default: return 0.4f;
            case 2: return 0.475f;
            case 3: return 0.55f;
        }
    }
}