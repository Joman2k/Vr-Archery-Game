using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer))]

public class StringRenderer : MonoBehaviour
{
    public stretchmesure stretchAmount = null;

    //areas for the string renderers vertices ?
    public Transform start = null;
    public Transform middle = null;
    public Transform end = null;


    private LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        
     
            UpdatePositions();
        
    }

    private void UpdatePositions()
    {
        //set positions of line renderer. Middle of the line renderer will be the attach notch for the arrow
        Vector3[] positions = new Vector3[] { start.position, middle.position, end.position };
        lineRenderer.SetPositions(positions);
    }

    private void OnEnable()
    {
        //update before the render makes it look better
        Application.onBeforeRender -= UpdatePositions;
    }

    private void OnDisable()
    {
        Application.onBeforeRender -= UpdatePositions;
    }
}
