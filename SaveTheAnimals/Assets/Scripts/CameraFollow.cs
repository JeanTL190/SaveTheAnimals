using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector2 maxXandY;
    [SerializeField] private Vector2 minXandY;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Transform player;
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - player.position;
    }
    private void FixedUpdate()
    {
        if (player)
        {
            /*float x = Mathf.Clamp(player.position.x, minXandY.x, maxXandY.x);
            float y = Mathf.Clamp(player.position.y, minXandY.y, maxXandY.y);
            this.transform.position = new Vector3(x, y, this.transform.position.z);*/
            Vector3 desiredPosition = player.position + offset;
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = SmoothedPosition;
        }
    }
}
