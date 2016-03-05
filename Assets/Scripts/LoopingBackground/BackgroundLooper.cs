using UnityEngine;
using System.Collections;

public class BackgroundLooper : MonoBehaviour {

    [SerializeField]
    private float loopSpeed = 0.2f;

	private Renderer bgRenderer;

	void Start () {
		bgRenderer = GetComponent<Renderer> ();
	}

	void FixedUpdate () {
        //Sets the offset of the texture to give the illusion of looping
        //Vector2 offset = new Vector2 (0,Time.time* (loopSpeed * GameSpeed.SpeedMultiplier));

        Vector2 offset = new Vector2(0, loopSpeed * GameSpeed.SpeedMultiplier);
        bgRenderer.material.mainTextureOffset = offset;﻿
	}
}
