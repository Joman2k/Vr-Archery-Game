using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{

    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();

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
            MapPosition(head, XRNode.Head);
            MapPosition(leftHand, XRNode.LeftHand);
            MapPosition(rightHand, XRNode.RightHand);
        }
    }

    //we need to sync the transforms with the headset
    void MapPosition(Transform target, XRNode node)
    {
        //Get the input of the headset and use it as the position
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        //Get the rotation of the headset
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = position;
        target.rotation = rotation;
    }
}
