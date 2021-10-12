Shader "Unlit/波纹"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _A("A",range(0.01,0.1)) = 0.01
        _B("B",range(10,100)) = 10
        _R("R",range(0,1))=0
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
            #include "Lighting.cginc"
            #include "UnityCG.cginc"
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _A;
            float _B;
            float _R;

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                //i.uv += _A*sin(i.uv*_B+ _Time.y);横竖波纹
                float dis = distance(i.uv,float2(0.5,0.5));
                if (dis < _R) 
                {
                 _A *= 1-(dis / _R);
                 i.uv += i.uv * _A * sin(-dis * _B + _Time.y);//圆形波纹
                }
                return tex2D(_MainTex, i.uv);
                
            }
            ENDCG
        }
    }
}
