using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class TestChangeValues : MonoBehaviour
{
    public float newValue;
    // Start is called before the first frame update
    void Start()
    {
        Shader.SetGlobalFloat("_MyValue", newValue);

        //GetComponent<Renderer>().sharedMaterial
        //    .SetFloat("_MyValue", newValue);
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalFloat("_MyValue", newValue);

        //GetComponent<Renderer>().sharedMaterial
        //    .SetFloat("_MyValue", newValue);
    }
}
