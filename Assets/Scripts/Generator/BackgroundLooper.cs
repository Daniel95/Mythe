using UnityEngine;
using System.Collections;

public class BackgroundLooper : MonoBehaviour {

    [SerializeField]
    private float loopSpeed = 500;

	private Renderer bgRenderer;

	void Start () {
		bgRenderer = GetComponent<Renderer> ();
	}

	void FixedUpdate () {
        //Sets the offset of the texture to give the illusion of looping

        Vector2 offset = new Vector2(0, (GameSpeed.MoveSpeed * GameSpeed.SpeedMultiplier) * loopSpeed);
        bgRenderer.material.mainTextureOffset = offset;﻿
	}
}
