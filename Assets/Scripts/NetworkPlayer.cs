using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class NetworkPlayer : MonoBehaviour
{
    public List<GameObject> avatars;

    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    public Animator characterAnimator;
    public Animator leftHandAnimator;
    public Animator rightHandAnimator;

    private PhotonView photonView;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;
    private GameObject spawnedAvatar;
    private int index;

    public GlobalControl globalControl;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();

        XRRig rig = FindObjectOfType<XRRig>();
        headRig = rig.transform.Find("Camera Offset/GameObject/Main Camera");
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");

        if(photonView.IsMine)
            photonView.RPC("LoadAvatar", RpcTarget.AllBuffered, PlayerPrefs.GetInt("AvatarID"));


    }

    //Function that is responsible to load an avatar among the avatar list
    [PunRPC]
    public void LoadAvatar(int index)
    {

        //if(GlobalControl.GetAvatarID()==-1)
        //    GlobalControl.SetAvatarID(index);
        //else
        //    index = GlobalControl.GetAvatarID();
        this.index = index;

        if (spawnedAvatar)
            Destroy(spawnedAvatar);

        spawnedAvatar = Instantiate(avatars[index], transform);
        AvatarInfo avatarInfo = spawnedAvatar.GetComponent<AvatarInfo>();

        avatarInfo.head.SetParent(head, false);
        avatarInfo.leftHand.SetParent(leftHand, false);
        avatarInfo.rightHand.SetParent(rightHand, false);
        if (index == 2)
        {
            leftHandAnimator = avatarInfo.leftHandAnimator;
            rightHandAnimator = avatarInfo.rightHandAnimator;
        }

        characterAnimator = avatarInfo.animator;
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {          
            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);

            if (index != 2)
            {
                UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), characterAnimator, "Left");
                UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), characterAnimator, "Right");
            }
            else
            {
                UpdateHandAnimation2(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
                UpdateHandAnimation2(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
            }
        }
      
    }

    void UpdateHandAnimation2(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator, string whichHand)
    {
        if (!handAnimator)
            return;

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float triggerValue))
        {
            handAnimator.SetFloat("Grip_" + whichHand, triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Grip_" + whichHand, 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float gripValue))
        {
            handAnimator.SetFloat("Trigger_" + whichHand, gripValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger_" + whichHand, 0);
        }


    }


    void MapPosition(Transform target,Transform rigTransform)
    {    
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}
