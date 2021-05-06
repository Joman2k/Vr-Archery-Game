using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Bow : XRGrabInteractable
{
    private ArrowNotchpoint NotchonBow = null;
    //Bow is ready when picked up
    protected override void Awake()
    {
        base.Awake();
        NotchonBow = GetComponentInChildren<ArrowNotchpoint>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        selectEntered.AddListener(NotchonBow.SetReady);
        selectExited.AddListener(NotchonBow.SetReady);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(NotchonBow.SetReady);
        selectExited.RemoveListener(NotchonBow.SetReady);
    }

}
