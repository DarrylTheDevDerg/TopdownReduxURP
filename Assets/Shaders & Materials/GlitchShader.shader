Shader "Custom/GlitchShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GlitchIntensity ("Glitch Intensity", Range(-1, 1)) = 0
    }
 
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
 
        CGPROGRAM
        #pragma surface surf Lambert
 
        sampler2D _MainTex;
        fixed _GlitchIntensity;
 
        struct Input
        {
            float2 uv_MainTex;
        };
 
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed2 uv = IN.uv_MainTex;
            uv += _GlitchIntensity * (0.1 * sin(uv.y * 40 + _Time.y * 100) + 0.1 * sin(uv.y * 30 + _Time.y * 80) + 0.1 * sin(uv.y * 20 + _Time.y * 60) + 0.1 * sin(uv.y * 10 + _Time.y * 40));
 
            fixed4 c = tex2D(_MainTex, uv);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
