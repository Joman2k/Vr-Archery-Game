using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Quiver2 : XRBaseInteractable
{
    public GameObject Arrow = null;

    protected override void OnEnable()
    {
        base.OnEnable();
        selectEntered.AddListener(CreateAndSelectArrow);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(CreateAndSelectArrow);
    }

    private void CreateAndSelectArrow(SelectEnterEventArgs args)
    {
        //Create the arrow and force it to the users hand
        ArrowScript arrow = CreateArrow(args.interactor.transform);
        interactionManager.ForceSelect(args.interactor, arrow);
    }

    private ArrowScript CreateArrow(Transform orientation)
    {
        //create the arrow
        GameObject arrowObject = Instantiate(Arrow, orientation.position, orientation.rotation);
        return arrowObject.GetComponent<ArrowScript>();

    }

}
