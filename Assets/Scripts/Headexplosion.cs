using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headexplosion : MonoBehaviour
{
    public GameObject HeadshatteredPrefab;

    //When head is hit with arrow , explode into the shattered prefab
    public void ExplodeHead()
    {
        GameObject explodedhead = Instantiate(HeadshatteredPrefab);
        explodedhead.transform.position = transform.position;
        Destroy(gameObject);

    }
}
