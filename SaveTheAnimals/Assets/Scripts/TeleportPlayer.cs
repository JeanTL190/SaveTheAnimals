using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public CameraFade fade;
    [SerializeField] private float timeToFade;

    public void TeleportarPlayer(Transform checkpoint)
    {
        StartCoroutine(Teleport(checkpoint));
    }

    IEnumerator Teleport(Transform checkpoint)
    {
        CameraShake.Instance.ShakeCamera(5f, 0.1f);
        fade.TriggerFade();
        yield return new WaitForSeconds(timeToFade);
        transform.position = checkpoint.position;
        yield return new WaitForSeconds(timeToFade);
        fade.TriggerFade();
    }

}
