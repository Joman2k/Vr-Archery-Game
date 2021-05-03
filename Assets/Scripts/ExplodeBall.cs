using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBall : MonoBehaviour
{

    public GameObject prefabBall;

    public void explodeBall()
    {
        GameObject brokenball = Instantiate(prefabBall);
        brokenball.transform.position = transform.position;
        Destroy(gameObject);
    }

}
