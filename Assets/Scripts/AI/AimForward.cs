using UnityEngine;
using System.Collections;

public class AimForward : MonoBehaviour {
    private Transform target;
    [SerializeField]
    private float speed = 10;
    private Vector2 direction;
    public bool moves;
    [SerializeField]
    private float distanceDetection;
    private float distance;
    private GameObject player;
    public void OnEnable()
    {
        player = GameObject.Find("Player");
        if (player != null)
        {
            target = player.transform;
            StartCoroutine(Aim());
        }
        
    }
    IEnumerator Aim()
    {
        moves = false;
        distance = Vector2.Distance(target.position, transform.position);
        while ( distance > distanceDetection)
            {
                direction = new Vector2((target.position.x - transform.position.x), (target.position.y - transform.position.y));
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                yield return new WaitForFixedUpdate();
            }
        moves = true;
        yield return new WaitForSeconds(10f);

        transform.Translate(new Vector3(0f, -100f, 0f));
    }
    
    void FixedUpdate () {
        if(moves)
        {
            transform.Translate(Vector2.right / 100 * speed);
        }
        else if(player != null)
        {
            distance = Vector2.Distance(target.position, transform.position);
        }
        
    }
}
