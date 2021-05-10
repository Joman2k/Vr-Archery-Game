using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class stretchmesure : XRBaseInteractable
{
    public class StretchEvent : UnityEvent<Vector3, float> { }
    public StretchEvent Stretched = new StretchEvent();


    //Start and End points for the bows string
    public Transform start = null;
    public Transform end = null;

    //Amount that the string has been pulled back by
    private float StretchAmount = 0.0f;

    //1st and 2nd part are diffrent varables not sure how they work together though
    public float PullAmount => StretchAmount;

    private XRBaseInteractor StretchInteractor = null;


    public void Start()
    {
        start = gameObject.transform.Find("Start");
        end = gameObject.transform.Find("End");
        Debug.Log($"start={start.name}, End={end.name}");
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // Set interactor for measurement
        StretchInteractor = args.interactor;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        //Clear the interactor and reset the pulled amount of the bow for the line-renderer
        StretchInteractor = null;

        //Reset everything with interaction
        SetStrechvalues(start.position, 0.0f);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (isSelected)
        {
            //Update pull values when grabbed
            if(updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
            {
                Debug.Log("The string is grabbed");
                StrechCheck();
            }

        }
    }


    private void StrechCheck()
    {
        //Get the amount pulled based on the interactors position
        Vector3 interactorPosition = StretchInteractor.transform.position;
        //find the new strech value then its position
        float newStrechvalue = CalculateStretch(interactorPosition);
        Vector3 newStrechPosition = calculatePosition(newStrechvalue);


        SetStrechvalues(newStrechPosition, newStrechvalue);
        Debug.Log("StretchCheck");

    }

    private float CalculateStretch(Vector3 stretchPosition)
    {
        //Checking the direction and the length of the pull
        Vector3 StrechDirection = stretchPosition - start.position;
        Vector3 targetDirection = end.position - start.position;

        //Figure out the pull direction
        float maxLength = targetDirection.magnitude;
        targetDirection.Normalize();

        float StretchValue = Vector3.Dot(StrechDirection, targetDirection) / maxLength;
        StretchValue = Mathf.Clamp(StretchValue, 0.0f, 1.0f);

            return StretchValue;
    }

    private Vector3 calculatePosition(float amount)
    {
        //find the hand position, by using a lerp to get a linear interpolation between the 2 points (start and end)
        return Vector3.Lerp(start.position, end.position, amount);
    }

    private void SetStrechvalues(Vector3 newStrechPosition, float newStrechAmount)
    {
        //if there is a new value do this
        if (newStrechAmount != StretchAmount)
        {
            StretchAmount = newStrechAmount;
            Stretched?.Invoke(newStrechPosition, newStrechAmount);
        }
    }

    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        //only let direct interactors use the string
        return base.IsSelectableBy(interactor) && IsDirectInteractor(interactor);
    }

    private bool IsDirectInteractor(XRBaseInteractor interactor)
    {
        return interactor is XRDirectInteractor;
    }

    private void OnDrawGizmos()
    {
        //Draw line from start to end point for Debug reasons
        if(start && end)
        {
            Gizmos.DrawLine(start.position, end.position);
        }



    }
}
