using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCaster : MonoBehaviour, IShadowCaster
{
    [SerializeField] private float size = .5f;

    public Vector3 Position => transform.position;

    public float Size => size;


    private void OnEnable()
    {
        ShadowCasterDatabase.Instance.Add(this);
    }

    private void OnDisable()
    {
        ShadowCasterDatabase.Instance.Remove(this);
    }
}
