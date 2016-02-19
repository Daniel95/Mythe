using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    [SerializeField]
    private int minShakeTime;

    [SerializeField]
    private int maxShakeTime;

    [SerializeField]
    private float shakeStrength;

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
    }

    private IEnumerator Shake()
    {
        shaking = true;

        //save the initual position when when start shaking
        Vector3 startPos = transform.position;

        //choose a random number between minshake and maxshake, that is the amount of times we are going to shake
        float shakeTimes = Random.Range(minShakeTime, maxShakeTime);

        //decrement the shakeTime until its 0 or below, then we stop shaking
        while (shakeTimes >= 0)
        {
            //decrement the amount of shakes we have left
            shakeTimes--;

            //says the position is startpos x/y incremented by a random number between minShakeStrength and maxShakeStrength
            transform.position = new Vector3(startPos.x + Random.Range(-shakeStrength, shakeStrength), startPos.y + Random.Range(-shakeStrength, shakeStrength), startPos.z);

            yield return new WaitForFixedUpdate();
        }

        //reset the position to the position before we started shaking
        transform.position = startPos;

        shaking = false;
    }
}
