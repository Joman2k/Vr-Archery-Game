using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    void Update()
    {
        //spins object constantly on the Z axis
        transform.Rotate(0, 0, 25 * Time.deltaTime);

    }
}
