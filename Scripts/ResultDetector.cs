using UnityEngine;
using System.Collections;

public class ResultDetector : MonoBehaviour {

    bool hitting;
    int hitTime;

    public int result;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "ball")
        {
            hitting = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "ball")
        {
            hitting = false;
        }
    }

    void Update()
    {
        if (hitting && ResultManager.spinning)
        {
            hitTime++;
        } else
        {
            hitTime = 0;
        }

        if (hitTime > 100)
        {
            ResultManager.SetResult(result);
        }
    }
}
