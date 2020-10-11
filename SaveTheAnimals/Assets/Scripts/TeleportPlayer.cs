using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public void TeleportarPlayer(Transform checkpoint)
    {
        transform.position = checkpoint.position;
    }
}
