Shader "Custom/PixelatedStars"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _Speed ("Speed", Range(0, 10)) = 1
        _StarSize ("Star Size", Range(1, 10)) = 5
        _Brightness ("Brightness", Range(0, 1)) = 1
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

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Speed;
            float _StarSize;
            float _Brightness;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float2 pixelSize = 1.0 / _ScreenParams.xy;
                
                // Convert the UV coordinates to pixel space
                uv = round(uv / pixelSize) * pixelSize;
                
                // Add time-based animation to the UV coordinates
                float2 offset = _Time.y * _Speed;
                uv += offset;
                
                // Get the color and alpha from the texture
                fixed4 col = tex2D(_MainTex, uv);
                float alpha = col.a;
                
                // Apply the star effect based on the alpha value and star size
                col.rgb += _Brightness * step(0.5 * _StarSize, frac(uv.x + uv.y));
                col.a = max(alpha, step(0.5 * _StarSize, frac(uv.x + uv.y)));
                
                return col;
            }
            ENDCG
        }
    }
}
