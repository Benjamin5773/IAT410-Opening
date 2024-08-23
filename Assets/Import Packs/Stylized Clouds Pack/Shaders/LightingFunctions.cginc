#ifndef _LIGHTFUNC_INCLUDED
#define _LIGHTFUNC_INCLUDED

uniform float4 _WorldSpaceLightPos0;
uniform float4 _LightColor0;

void NdotL_float(float3 n, out float output)
{
    float l = dot(n , _WorldSpaceLightPos0.xyz);
    output = (l + 1) / 2;
}

void LightColor_float(out float3 output)
{
    output = _LightColor0.xyz;
}

#endif