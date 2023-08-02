using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {


    private Vector3 startPosition;
    private Quaternion startRotation;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        startRotation = transform.rotation;

        GetComponent<Rigidbody>().isKinematic = true;
	}

    public void Fire(float speed)
    {
        GetComponent<Rigidbody>().isKinematic = false;

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        transform.position = startPosition;
        transform.rotation = startRotation;

        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    void Update()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude < 2)
        {
            AudioManager.getInstance().BallStopped();
        }
        else {
            AudioManager.getInstance().BallRolling();
        }

    }
}
