using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class Quiver : XRBaseInteractable
{
  //  public GameObject arrowPrefab = null;

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

    //using arguments to create arrows
    private void CreateAndSelectArrow(SelectEnterEventArgs args)
    {
        // Create arrow, force into interacting hand
        Arrow arrow = CreateArrow(args.interactor.transform);
        interactionManager.ForceSelect(args.interactor, arrow);
    }

    private Arrow CreateArrow(Transform orientation)
    {
        Debug.Log($"We're spawning an arrow like a cool guy");

        // Create arrow, and get arrow component
        GameObject arrowObject = PhotonNetwork.Instantiate("Arrow (1)", orientation.position, orientation.rotation);
        return arrowObject.GetComponent<Arrow>();
    }
}
