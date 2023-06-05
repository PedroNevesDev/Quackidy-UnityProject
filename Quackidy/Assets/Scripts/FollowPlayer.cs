using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Vector2 xLims;
    [SerializeField] Vector2 yLims;
    [SerializeField] Transform player;
    [SerializeField] float lerpAmmount;

    public Vector2 YLims { get => yLims; set => yLims = value; }
    public Vector2 XLims { get => xLims; set => xLims = value; }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(player.position.x,xLims.x,xLims.y), Mathf.Clamp(player.position.y, yLims.x, yLims.y), transform.position.z), lerpAmmount * Time.deltaTime);
    }
}
