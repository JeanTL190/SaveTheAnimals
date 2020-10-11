using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake  Instance { get; private set;  }

    private CinemachineVirtualCamera vc;
    private float shakeTimer;
    private float totalShakeTimer;
    private float startingIntensity;

    private void Awake()
    {
        Instance = this;
        vc = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cbmcp = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cbmcp.m_AmplitudeGain = intensity;

        startingIntensity = intensity;
        totalShakeTimer = time;
        shakeTimer = time;
    }

    void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            CinemachineBasicMultiChannelPerlin cbmcp = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cbmcp.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, 1 - shakeTimer / totalShakeTimer);
        }
    }
}
