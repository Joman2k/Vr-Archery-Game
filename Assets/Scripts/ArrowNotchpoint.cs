using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(stretchmesure))]
public class ArrowNotchpoint : XRSocketInteractor
{
    //Range to control how far the player will need to pull back on the bow string

    [Range(0, 1)] public float releaseAmountmax = 0.25f;

    public bool NotchIsReady { get; private set; } = false;

    public stretchmesure StretchAmount {get; private set; } = null;


    private InteractionManager customManager => interactionManager as InteractionManager;


    protected override void Awake()
    {
        base.Awake();

        StretchAmount = GetComponent<stretchmesure>();
    }



    //protected override void OnEnable()
    //{
    //    base.OnEnable();
    //    //when the puller is realsed, realse the arrow
    //    StretchAmount.onSelectExited.AddListener(ReleaseArrow);

    //    StretchAmount.Stretched.AddListener(MoveAttach);

    //}

    //protected override void OnDisable()
    //{
    //    base.OnDisable();
    //    StretchAmount.selectExited.RemoveListener(ReleaseArrow);
    //    StretchAmount.Stretched.RemoveListener(MoveAttach);

    //}

    //public void ReleaseArrow(SelectExitEventArgs args)
    //{
    //    //Only release the object if it is an arrow 
    //    if (selectTarget is ArrowScript && StretchAmount.PullAmount > releaseAmountmax)
    //    {
    //        customManager.Deselect(this);
    //    }
    //}

    public void MoveAttach(Vector3 stretchPosition, float stretchAmount)
    {
        //Updates the renderer and the attach transform for the notch
        attachTransform.position = stretchPosition;
    }

    //public void SetReady(BaseInteractionEventArgs args)
    //{
    //    //if the bow is picked up set the notch as ready
    //    NotchIsReady = args.Interactable.isSelected;
    //}

    public override bool CanSelect(XRBaseInteractable interactable)
    {

        return base.CanSelect(interactable) && CanHover(interactable) && IsArrow(interactable);
    }

    private bool IsArrow(XRBaseInteractable interactable)
    {
        //Arrow check, could be tag or layer interaction
        return interactable is ArrowScript;
    }

    public override XRBaseInteractable.MovementType? selectedInteractableMovementTypeOverride
    {
        // Use instantaneous so the arrow is smooth
        get { return XRBaseInteractable.MovementType.Instantaneous; }
    }
    // Enables the socket to grab the arrow immediately
    public override bool requireSelectExclusive => false;
}
