using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkPlayer : MonoBehaviour
{

    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        XRRig rig = FindObjectOfType<XRRig>();
        //get the transform of the rig
        headRig = rig.transform.Find("Camera Offset/VR camera");
        leftHandRig = rig.transform.Find("Camera Offset/Left hand");
        rightHandRig = rig.transform.Find("Camera Offset/Right hand");
        RoundManager1.instance.netPlayers.Add(this);
        
    }

    // Update is called once per frame
    void Update()
    {

        //check if the network view is spawned on player and if it is then hide it for that player so they dont see doubles
        if(photonView.IsMine)
        {
            rightHand.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            head.gameObject.SetActive(false);
            //Use the position of the headset and controllers to track with the Nodes for the head and hands
            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);
        }
    }

    //we need to sync the transforms with the headset
    void MapPosition(Transform target, Transform rigTransform)
    {
        ////Get the input of the headset and use it as the position
        //InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        ////Get the rotation of the headset
        //InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);


        //using the rig transform we can use the world transform instead of local one
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}
