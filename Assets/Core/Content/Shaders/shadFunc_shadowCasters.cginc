//UNITY_SHADER_NO_UPGRADE
#ifndef MYHLSLINCLUDE_INCLUDED
#define MYHLSLINCLUDE_INCLUDED

#define MAX_CASTERS 16
uniform int _GCasterSize;
uniform float4 _GShadowCasters[MAX_CASTERS];

void ShadowCasters_float(float3 Coords, float Hardness, out float3 Out)
{
    float3 result = float3(0, 0, 0);
    for (int i = 0; i < _GCasterSize; i++)
    {
        float3 center = _GShadowCasters[i];
        float radius = _GShadowCasters[i].w;
        result += (1 - saturate((distance(Coords, center) - radius) / (1 - Hardness)));
    }

    Out = result;
}

#endif //MYHLSLINCLUDE_INCLUDED