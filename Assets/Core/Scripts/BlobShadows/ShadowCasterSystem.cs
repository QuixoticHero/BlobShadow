using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCasterSystem : MonoBehaviour
{
    private ShadowCasterSystemSettings settings;

    [SerializeField] private int currFps;
    private int m_frameCounter = 0;
    private float m_timeCounter = 0.0f;

    private void Awake()
    {
        settings = ShadowCasterSystemSettings.Instance;
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
        for(int i = 0; i < shadowCasters.Length; i++)
        {
            string name = settings.GetCasterName + ((i < 10) ? "0" : "") + i;
            Vector4 value = shadowCasters[i].Position;
            value.w = shadowCasters[i].Size;

            Shader.SetGlobalVector(name, value);
        }
    }
}
