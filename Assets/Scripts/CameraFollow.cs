using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offsetX = 0f;
    [SerializeField] private float offsetY = 0f;

    void LateUpdate()
    {
        transform.position = new Vector3(
            player.position.x + offsetX,
            player.position.y + offsetY,
            transform.position.z
        );
    }
}
