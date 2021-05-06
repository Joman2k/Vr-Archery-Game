using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ArrowScript : XRGrabInteractable
{
    public float ArrowSpeed = 200f;

    public Transform ArrowTip = null;

    public LayerMask masklayer = ~Physics.IgnoreRaycastLayer;

    private new Rigidbody rigidbody = null;
    private new Collider collider = null;


    private Vector3 lastPosition = Vector3.zero;
    private bool arrowlaunched = false;




    protected override void Awake()
    {
        base.Awake();
        collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
        ArrowTip = gameObject.transform.Find("Tip");
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        //This being first allows us to get the right physics values
        if (args.interactor is XRDirectInteractor)
        {
            Clear();

        }
        base.OnSelectEntering(args);
    }

    private void Clear()
    {
        SetLaunch(false);
        TogglePhysics(true);
    }

    private void SetLaunch(bool value)
    {
        collider.isTrigger = value;
        arrowlaunched = value;
    }

    private void TogglePhysics(bool value)
    {
        //While grabbing disable physics
        rigidbody.isKinematic = !value;
        rigidbody.useGravity = value;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        //if there is an arrow in the notch, launch the arrow
        if (args.interactor is ArrowNotchpoint notch)
        {
            Launch(notch);

        }

    }

    private void Launch(ArrowNotchpoint notch)
    {
            //If the notch is ready launch the arrow
            if (notch.NotchIsReady)
        {
            SetLaunch(true);
            UpdateLastPosition();
            ApplyForce(notch.StretchAmount);
        }
    }

    private void UpdateLastPosition()
    {
        //use the arrows tip as the last positon of arrow
        lastPosition = ArrowTip.position;
    }

    private void ApplyForce(stretchmesure stretchmesure)
    {
        //apply the force to the arrow itself
        float power = stretchmesure.PullAmount;
        Vector3 force = transform.forward * (power * ArrowSpeed);
        rigidbody.AddForce(force);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if(arrowlaunched)
        {
            //collision check
            if(updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
            {
                if(CollisionCheck())
                {
                    arrowlaunched = false;

                    UpdateLastPosition();

                }
                //set direction when the physics update
                if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Fixed)
                {
                    SetDirection();
                }
            }
        }
    }


    private void SetDirection()
    {
        //move in the direction the arrow is looking
        if(rigidbody.velocity.z > 0.5f)
        {
            transform.forward = rigidbody.velocity;
        }


    }
    private bool CollisionCheck()
    {
        //check if hit
        if(Physics.Linecast(lastPosition, ArrowTip.position, out RaycastHit hit, masklayer))
        {
            TogglePhysics(false);
            ChildArrowObject(hit);
            HitCheck(hit);
        }
        return hit.collider != null;
    }

    private void ChildArrowObject(RaycastHit hit)
    {
       //Child to the object its hit, so it can move with it
        Transform newParent = hit.collider.transform;
        transform.SetParent(newParent);
    }


    private void HitCheck(RaycastHit hit)
    {
        //check if this is needed in other project?
    }

    //Code to explode head when hit
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.GetComponent<ExplodeBall>())
        {
            other.transform.gameObject.GetComponent<ExplodeBall>().explodeBall();
            return;
        }


    }
}
