using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowCasterSystem : MonoBehaviour
{
    private ShadowCasterSystemSettings settings;

    [SerializeField] private int currFps;
    private int m_frameCounter = 0;
    private float m_timeCounter = 0.0f;

    private Vector4[] castersData;


    private void Awake()
    {
        settings = ShadowCasterSystemSettings.Instance;

        ResetCasterArray();
    }

    public IEnumerator Start()
    {
        while (true)
        {
            FrameCounter();
            UpdateFrame();
            yield return new WaitForSeconds(settings.GetFps);
        }
    }

    public void OnEnable()
    {
        ResetCasterArray();
    }

    public void OnDisable()
    {
        ResetCasterArray();
    }

    private void FrameCounter()
    {
        if (Time.time > m_timeCounter)
        {
            m_timeCounter = Time.time + 1;

            currFps = m_frameCounter;
            m_frameCounter = 0;
        }
        else
        {
            m_frameCounter++;
        }
    }

    private void UpdateFrame()
    {
        IShadowCaster[] shadowCasters = ShadowCasterDatabase.Instance.GetArray();

        int casterCount = shadowCasters.Length;
        for (int i = 0; i < casterCount && i < castersData.Length; i++)
        {
            castersData[i] = shadowCasters[i].CenterSize;
        }

        Shader.SetGlobalInteger("_GCasterSize", casterCount);
        Shader.SetGlobalVectorArray("_GShadowCasters", castersData);
    }

    private void ResetCasterArray()
    {
        castersData = new Vector4[settings.GetMaxCasters];

        for (int i = 0; i < castersData.Length; i++)
        {
            castersData[i] = settings.GetResetValue;
        }

        Shader.SetGlobalVectorArray("_GShadowCasters", castersData);
    }
}
