using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.Events;
public class SphereTriggerZoneScript : MonoBehaviour
{

    private bool Goal = false;
    public UnityEvent onGoalReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sphere" && !Goal) {
            Goal = true;
            onGoalReached.Invoke();
        }
    }
}
