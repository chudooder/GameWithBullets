Shader "Custom/CelShader" {

	Properties {
		_Color ("Color", Color) = (1,1,1,1)
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf CelShader fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		half4 LightingCelShader (SurfaceOutput s, half3 lightDir, half atten) {
			half NdotL = dot (s.Normal, lightDir);
			half4 c;
			bool clamped = false;
			for(half i = 0.2; i < 1.0; i += 0.2) {
				if(NdotL <= i) {
					NdotL = i;
					clamped = true;
					break;
				}
			}
			if(!clamped) {
				NdotL = 1.0;
			}

			c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten * 2);
			c.a = s.Alpha;
			return c;
		}


		struct Input {
			int asdf;
		};

		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			o.Albedo = _Color.rgb;
			o.Alpha = _Color.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
