using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ForceDeslect : XRInteractionManager
{

    //takes the arrow out of the users hand
   public void ForceArrowDeselect(XRBaseInteractor interactor)
    {
        if (interactor.selectTarget)
        {
            SelectExit(interactor, interactor.selectTarget);

        }
    }
}
