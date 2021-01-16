using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public CameraFade fade;
    private PlayerWalk pw;
    [SerializeField] private float timeToFade;

    private void Awake()
    {
        pw = GetComponent<PlayerWalk>();
    }

    public void TeleportarPlayer(Transform checkpoint)
    {
        StartCoroutine(Teleport(checkpoint));
    }

    // Se não tiver checkpoint definido, transporta o player pro começo do nível
    public void TeleportarPlayer()
    {
        Transform checkpoint = GameObject.Find("CheckPoint").transform;
        StartCoroutine(Teleport(checkpoint));
    }

    IEnumerator Teleport(Transform checkpoint)
    {
        pw.SetPermitMove(false);
        CameraShake.Instance.ShakeCamera(5f, 0.1f);
        fade.TriggerFade();
        yield return new WaitForSeconds(timeToFade);
        transform.position = checkpoint.position;
        yield return new WaitForSeconds(timeToFade);
        fade.TriggerFade();
        pw.SetPermitMove(true);
    }

}
