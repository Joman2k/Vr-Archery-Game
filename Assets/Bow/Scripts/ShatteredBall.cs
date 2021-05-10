using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredBall : MonoBehaviour
{
    public GameObject PrefabBall;

    //Shatters ball when hit with arrow

    public void ShatterBall()
    {
        GameObject brokenball = Instantiate(PrefabBall);
        brokenball.transform.position = transform.position;
        Destroy(gameObject);

    }
}
