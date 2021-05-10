using UnityEngine.XR.Interaction.Toolkit;

public class CustomInteractionManager : XRInteractionManager
{

    //takes the arrow out of the users hand?
    public void ForceDeselect(XRBaseInteractor interactor)
    {
        if (interactor.selectTarget)
            SelectExit(interactor, interactor.selectTarget);
    }
}
