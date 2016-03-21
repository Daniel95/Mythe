using UnityEngine;

public class OutOfBoundsHandler : MonoBehaviour {

    [SerializeField]
    private int yDestroyPosition = -6;

	void Update () {
		if (transform.position.y < yDestroyPosition) {
            //This puts the object pack into the object pool.
            OutOfBounds();
		}
	}

    virtual protected void OutOfBounds() {

    }
}
