Shader "Unlit/光照"
{
    Properties
    {
       _SpecularColor("SpecularColor",color) = (1,1,1,1)
       _Gloss("Gloss", range(1, 128)) = 4
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Pass{
            Tags{"LightMode"="Shadowcaster"}//阴影投射
}
        Pass
        {
            Tags{"LightMode"="ForwardBase"}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Lighting.cginc"
            #include "UnityCG.cginc"

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 vertex:TEXCOORD0;
                float3 normal:TEXCOORD1;
            };
           fixed4 _SpecularColor;
           float _Gloss;
            v2f vert (appdata_base v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.vertex = v.vertex;
                o.normal = v.normal;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 worldNormal =normalize(UnityObjectToWorldNormal(i.normal));
                float3 worldLight = WorldSpaceLightDir(i.vertex);
                float3 worldView = WorldSpaceViewDir(i.vertex);
                fixed4 diffuseColor = saturate(dot(worldNormal, worldLight)) * _LightColor0;//漫反射光

                float specularScale = saturate(dot(normalize(worldLight + worldView), worldNormal));//高光系数
                fixed4 specular = _SpecularColor * pow(specularScale, _Gloss);//高光
                return diffuseColor*0.7 + UNITY_LIGHTMODEL_AMBIENT+specular;
            }
            ENDCG
        }
    }
}
