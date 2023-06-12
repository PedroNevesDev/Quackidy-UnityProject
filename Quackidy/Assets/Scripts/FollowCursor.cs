using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FollowCursor : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        FaceMouse();
    }

    void FaceMouse()
    {
        if(Time.deltaTime == 0f)
        { return; }
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 dir= new Vector2( mousePosition.x - transform.position.x, mousePosition.y - transform.position.y); 
        transform.up = -dir;
    }
}
