using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaler : MonoBehaviour
{
    [SerializeField]
    private float defaultHeight = 1.7f;
    [SerializeField]
    private Camera camera;

    public VRIK ik;
    public float scaleMlp = 1f;

    private void Resize()
    {
        //float headHeight = camera.transform.localPosition.y;
        //float scale = defaultHeight / headHeight;
        //transform.localScale = Vector3.one * scale;

        float sizeF = (ik.solver.spine.headTarget.position.y - ik.references.root.position.y) / (ik.references.head.position.y - ik.references.root.position.y);
        ik.references.root.localScale *= sizeF * scaleMlp;
    }

    void onEnable()
    {
        Resize();
    }
}
