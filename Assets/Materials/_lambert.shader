Shader "_lambert"{
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
	}

		SubShader
	{
		pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
				//user defined variables
			uniform float4 _Color;
			
			//unity defined variables
			uniform float4 _LightColor0;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			
			};

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 col : COLOR;
			};

			//vertex function
			vertexOutput vert(vertexInput v)
			{
				vertexOutput o;

				float3 normalDirection = mul(float4(v.normal, 0.0), _World2Object).xyz;

				o.col = float4(v.normal, 1.0);
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);

				return o;
			}
			//fragment function
			float4 frag(vertexOutput i) : COLOR
			{
				return i.col;
			}

			ENDCG

		};
	}

}
