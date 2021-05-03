using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class InteractionManager : XRInteractionManager
{
    public void Deselect(XRBaseInteractor interactor)
    {
        if (interactor.selectTarget)
        {
            SelectExit(interactor, interactor.selectTarget);
        }
    }
}
