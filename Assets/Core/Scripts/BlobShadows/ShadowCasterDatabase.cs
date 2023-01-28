using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[System.Serializable]
[CreateAssetMenu(fileName = "ShadowCasterDatabase", menuName = "Database/ShadowCasterDatabase", order = 120)]
public class ShadowCasterDatabase : ScriptableObject
{
    private static ShadowCasterDatabase _instance;
    public static ShadowCasterDatabase Instance
    {
        get
        {
            if (_instance != null) return _instance;

            // Should be removed from Property
            CreateShadowCasterSystem();

            _instance = Resources.Load("ShadowCasterDatabase") as ShadowCasterDatabase;
            return _instance;
        }
    }

    private static void CreateShadowCasterSystem()
    {
        GameObject shadowCasterSystem = new GameObject();
        shadowCasterSystem.AddComponent<ShadowCasterSystem>();
        shadowCasterSystem.name = "ShadowCasterSystem";

        DontDestroyOnLoad(shadowCasterSystem);
    }

    private HashSet<IShadowCaster> shadowCasters = new HashSet<IShadowCaster>();

    public IShadowCaster[] GetArray()
    {
        return shadowCasters.ToArray();
    }

    public void Add(IShadowCaster caster)
    {
        shadowCasters.Add(caster);
    }

    public void Remove(IShadowCaster caster)
    {
        ResetGlobalValue();

        shadowCasters.Remove(caster);
    }

    public void ResetGlobalValue()
    {
        ShadowCasterSystemSettings settings = ShadowCasterSystemSettings.Instance;

        int count = shadowCasters.Count - 1;
        string name = settings.GetCasterName + ((count < 10) ? "0" : "") + count;

        Shader.SetGlobalVector(name, settings.GetResetValue);
    }

}
