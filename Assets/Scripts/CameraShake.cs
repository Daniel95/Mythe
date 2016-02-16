using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    [SerializeField]
    private int minShakeTime;

    [SerializeField]
    private int maxShakeTime;

    [SerializeField]
    private float minShakeStrength;

    [SerializeField]
    private float maxShakeStrength;

    private bool shaking;

    void FixedUpdate() {
        //temp code for testing the function
        if (Random.Range(0, 0.99f) < 0.03f)
            StartShake(); 
    }

    public void StartShake() {
        //can only shake if not already shaking
        if (!shaking)
            StartCoroutine(Shake());
            print("startshake");
    }

    private IEnumerator Shake()
    {
        shaking = true;

        //save the initual position when when start shaking
        Vector3 startPos = transform.position;

        float shakeTime = Random.Range(minShakeTime, maxShakeTime);

        //decrement the shakeTime until its 0 or below, then we stop shaking
        while (shakeTime >= 0)
        {
            shakeTime--;

            float positionChange = Random.Range(minShakeStrength, maxShakeStrength);
            if (Random.Range(0, 0.99f) < 0.5f)
                positionChange *= -1;

            //shake on the x or y as is randomly chosen
            if (Random.Range(0, 0.99f) < 0.5f)
                //the new pos is the startpos plus the position change on the x or y axis
                transform.position = new Vector3(startPos.x + positionChange, startPos.y, startPos.z);
            else
                transform.position = new Vector3(startPos.x, startPos.y + positionChange, startPos.z);
            yield return new WaitForFixedUpdate();
        }

        transform.position = startPos;

        shaking = false;
    }
}
