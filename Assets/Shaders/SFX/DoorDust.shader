// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:783,x:32719,y:32712,varname:node_783,prsc:2|emission-6222-OUT,alpha-8108-OUT;n:type:ShaderForge.SFN_Tex2d,id:43,x:31998,y:32796,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_43,prsc:2,ntxv:2,isnm:False|UVIN-6611-UVOUT;n:type:ShaderForge.SFN_ViewVector,id:5501,x:31581,y:33007,varname:node_5501,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:4390,x:31581,y:33130,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:7194,x:31799,y:33054,varname:node_7194,prsc:2,dt:0|A-5501-OUT,B-4390-OUT;n:type:ShaderForge.SFN_Panner,id:6611,x:31794,y:32823,varname:node_6611,prsc:2,spu:0.001,spv:0.005;n:type:ShaderForge.SFN_Power,id:6701,x:32012,y:33082,varname:node_6701,prsc:2|VAL-7194-OUT,EXP-1039-OUT;n:type:ShaderForge.SFN_Vector1,id:1039,x:31799,y:33200,varname:node_1039,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:8108,x:32319,y:32991,varname:node_8108,prsc:2|A-43-B,B-6701-OUT;n:type:ShaderForge.SFN_Multiply,id:6222,x:32336,y:32784,varname:node_6222,prsc:2|A-4599-RGB,B-43-RGB;n:type:ShaderForge.SFN_Color,id:4599,x:31998,y:32625,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_4599,prsc:2,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:43-4599;pass:END;sub:END;*/

Shader "Custom/DoorDust" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "black" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 node_5228 = _Time + _TimeEditor;
                float2 node_6611 = (i.uv0+node_5228.g*float2(0.001,0.005));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(node_6611, _Diffuse));
                float3 emissive = (_Color.rgb*_Diffuse_var.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(_Diffuse_var.b*pow(dot(viewDirection,i.normalDir),2.0)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
