﻿using UnityEngine;
using System.Collections;

public class GenerateOneObject : MonoBehaviour {

    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private float delayTime;

    void Start()
    {
        SpawnObject();
    }
    void SpawnObject()
    {
        GameObject temp = ObjectPool.instance.GetObjectForType("destroyablePickUp", false);
        Vector3 pos = transform.position;
        if(temp != null)
        {
            temp.gameObject.transform.position = pos;
            
        }
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(delayTime);
        SpawnObject();
    }
}