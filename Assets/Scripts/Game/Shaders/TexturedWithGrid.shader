
Shader "Custom/TexturedWithGrid" 
{

	Properties
	{
		_TopTexTint("Top Texture Tint", Color) = (1,1,1,1)
		_TopTex("Top Texture", 2D) = "white" {}

		_SideTexTint("Side Texture Tint", Color) = (1,1,1,1)
		_SideTex("Side Texture", 2D) = "white" {}

		[Toggle] _GridEnabled("Grid Enable", float) = 0

		_GridColor("Grid Color", Color) = (1,1,1,1)	
		_GridStep("Grid size", Float) = 10
		_GridWidth("Grid width", Float) = 1
	}
	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _TopTex;
		fixed4 _TopTexTint;
		float4 _TopTex_ST;

		sampler2D _SideTex;
		fixed4 _SideTexTint;
		float4 _SideTex_ST;

		struct Input
		{
			float2 uv_TopTex;
			float3 worldPos;
			float3 worldNormal;
		};

		float _GridEnabled;
		fixed4 _GridColor;
		float _GridStep;
		float _GridWidth;

		void surf(Input IN, inout SurfaceOutputStandard o) 
		{
			float2 UV;
			fixed4 c;


			if (abs(IN.worldNormal.x)>0.5)
			{
				UV = IN.worldPos.yz; // side
				c = tex2D(_SideTex, UV / _SideTex_ST.xy) * _SideTexTint;
			}
			else if (abs(IN.worldNormal.z)>0.5)
			{
				UV = IN.worldPos.xy; // side
				c = tex2D(_SideTex, UV / _SideTex_ST.xy) * _SideTexTint;
			}
			else
			{
				UV = IN.worldPos.xz; // top
				c = tex2D(_TopTex, UV / _TopTex_ST.xy) * _TopTexTint;

				if (_GridEnabled == 1)
				{
					float2 pos;
					float2 f;
					float2 df;
					float2 g;
					float grid;

					pos = UV / _GridStep;
					f = abs(frac(pos));
					df = fwidth(pos) * _GridWidth;
					g = smoothstep(-df, df, f);
					grid = 1.0 - saturate(g.x * g.y);

					c.rgb = lerp(c.rgb, _GridColor, grid);
				}
			}

			o.Albedo = c.rgb;
			o.Alpha = c.a;

		}
		ENDCG
	}
	FallBack "Diffuse"
}