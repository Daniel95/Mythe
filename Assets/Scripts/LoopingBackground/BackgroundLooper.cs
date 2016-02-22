using UnityEngine;
using UnityEngine;
using System.Collections;

public class BackgroundLooper : MonoBehaviour {

    [SerializeField]
    private float loopSpeed = 0.2f;

	[SerializeField]
	private Material skyMaterial;

	private Renderer bgRenderer;

	void Start () {
		bgRenderer = GetComponent<Renderer> ();
	}

	void FixedUpdate () {
		//Sets the offset of the texture to give the illusion of looping
		Vector2 offset = new Vector2 (0,Time.time* (loopSpeed * GameSpeed.Speed));
		bgRenderer.material.mainTextureOffset = offset;﻿


		if (Input.GetKey (KeyCode.Space)) {
			ChangeMaterial (skyMaterial);
		}
	}
	public void ChangeMaterial(Material newMaterial)
	{
		bgRenderer.material = newMaterial;
	}
}