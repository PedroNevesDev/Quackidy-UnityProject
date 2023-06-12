using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    Transform target;
    
    public Transform Target { get => target; set => target = value; }

    // Update is called once per frame
    void Update()
    {
        if (target)
            transform.up = target.position - transform.position;
        else
            Destroy(gameObject);
    }
}
