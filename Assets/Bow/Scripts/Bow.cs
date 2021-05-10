using UnityEngine.XR.Interaction.Toolkit;

public class Bow : XRGrabInteractable
{
    private Notch Bownotch = null;
    //Script marks the bow as ready when its picked up
    protected override void Awake()
    {
        base.Awake();
        Bownotch = GetComponentInChildren<Notch>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        // Only notch an arrow if the bow is held
        selectEntered.AddListener(Bownotch.SetReady);
        selectExited.AddListener(Bownotch.SetReady);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(Bownotch.SetReady);
        selectExited.RemoveListener(Bownotch.SetReady);
    }
}
