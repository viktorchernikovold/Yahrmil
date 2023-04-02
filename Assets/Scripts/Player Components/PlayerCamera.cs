using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : PlayerModule
{
    [SerializeField] Transform player;
    private Vector3 offset;
    private void Start()
    {
        offset = player.transform.position - transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y - offset.y, -offset.z);
    }
}
