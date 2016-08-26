// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:783,x:32719,y:32712,varname:node_783,prsc:2|emission-473-OUT,alpha-7469-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7742,x:31891,y:32972,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_7742,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Slider,id:2101,x:31815,y:32594,ptovrint:False,ptlb:Emissive Power,ptin:_EmissivePower,varname:node_2101,prsc:2,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Frac,id:5259,x:30992,y:33164,varname:node_5259,prsc:2|IN-4446-OUT;n:type:ShaderForge.SFN_Panner,id:4103,x:30632,y:33179,varname:node_4103,prsc:2,spu:-0.3,spv:0;n:type:ShaderForge.SFN_ComponentMask,id:4446,x:30805,y:33190,varname:node_4446,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-4103-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7469,x:32432,y:32888,varname:node_7469,prsc:2|A-2101-OUT,B-7742-OUT,C-8368-OUT;n:type:ShaderForge.SFN_ViewVector,id:3888,x:31942,y:33278,varname:node_3888,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:5773,x:31942,y:33409,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:4520,x:32192,y:33360,varname:node_4520,prsc:2,dt:0|A-3888-OUT,B-5773-OUT;n:type:ShaderForge.SFN_Multiply,id:8368,x:32434,y:33268,varname:node_8368,prsc:2|A-4520-OUT,B-3889-OUT;n:type:ShaderForge.SFN_Vector1,id:3889,x:32189,y:33594,varname:node_3889,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:473,x:32494,y:32730,varname:node_473,prsc:2|A-2101-OUT,B-8368-OUT,C-2675-RGB;n:type:ShaderForge.SFN_Color,id:2675,x:32248,y:32529,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_2675,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;proporder:2101-7742-2675;pass:END;sub:END;*/

Shader "Maans/Hands" {
    Properties {
        _EmissivePower ("Emissive Power", Range(0, 10)) = 1
        _Opacity ("Opacity", Float ) = 1
        _Color ("Color", Color) = (1,1,1,1)
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
            uniform float _Opacity;
            uniform float _EmissivePower;
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
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
                float node_8368 = (dot(viewDirection,i.normalDir)*1.5);
                float3 emissive = (_EmissivePower*node_8368*_Color.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(_EmissivePower*_Opacity*node_8368));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
