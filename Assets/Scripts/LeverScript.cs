using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverScript : MonoBehaviour
{
    private bool isPulled;
    private ConfigurableJoint joint;
    private float startX;

    public UnityEvent onPulled, onReleased;
    public AudioSource audioSource;
    public AudioClip LeverPulled;
    // Start is called before the first frame update
    void Start()
    {
        startX = this.transform.localRotation.eulerAngles.x;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPulled && GetValue() >= 90)
        {
            Pulled();
        }
        if (isPulled && GetValue() < 90)
        {
            Released();
        }
    }
    private float GetValue()
    {
        float currentX = this.transform.localRotation.eulerAngles.x;
        float xAngle = Mathf.Abs(startX - currentX);
       
        return Mathf.Clamp(xAngle, 0f, 120f);
    }

    private void Pulled()
    {
        isPulled = true;
        audioSource.PlayOneShot(LeverPulled);
        onPulled.Invoke();
    }
    private void Released()
    {
        isPulled = false;
        onReleased.Invoke();
    }
}
