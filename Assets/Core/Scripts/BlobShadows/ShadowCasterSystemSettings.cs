using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "ShadowCasterSystemSettings", menuName = "Database/ShadowCasterSystemSettings", order = 120)]
public class ShadowCasterSystemSettings : ScriptableObject
{
    private static ShadowCasterSystemSettings _instance;
    public static ShadowCasterSystemSettings Instance
    {
        get
        {
            if (_instance != null) return _instance;

            _instance = Resources.Load("ShadowCasterSystemSettings") as ShadowCasterSystemSettings;
            return _instance;
        }
    }

    [SerializeField] private int maxCaster = 16;
    [SerializeField] private string casterName = "_Caster";
    [SerializeField] private float fps = 0.04167f;
    [SerializeField] private Vector4 resetValue = new Vector4(-1000, -1000, -1000, 0);
    
    public int GetMaxCasters { get { return maxCaster; } }
    public string GetCasterName { get => casterName; }
    public float GetFps { get => fps;}
    public Vector4 GetResetValue { get => resetValue; }
}
