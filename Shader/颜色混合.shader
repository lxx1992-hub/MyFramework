Shader "Unlit/Shader6"
{
    Properties
    {
        _Center("Range",range(-0.5,0.5)) = 0
        _R("R",range(0,0.5)) = 0.2
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 vertex:TEXCOORD0;
            };
            float _Center;
            float _R;
            v2f vert (appdata_base v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.vertex = v.vertex;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 color0 = fixed4(1,0,0,1);
                fixed4 color1 = fixed4(0,1,0,1);
                float d = i.vertex.y - _Center;
                float s = abs(d);
                d = d / s;
                float f = s / _R;
                f = saturate(f);
                d *= f;
                d = d / 2 + 0.5;
                return lerp(color0, color1, d);
            }
            ENDCG
        }
    }
}
