// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:0,bdst:1,culm:2,dpts:2,wrdp:True,dith:0,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.07255622,fgcg:0.3495891,fgcb:0.4485294,fgca:1,fgde:0.02,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1630,x:32719,y:32712,varname:node_1630,prsc:2|diff-4785-RGB,emission-9062-OUT,clip-353-OUT;n:type:ShaderForge.SFN_Tex2d,id:4785,x:32307,y:32605,varname:node_4785,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-9179-UVOUT,TEX-748-TEX;n:type:ShaderForge.SFN_Panner,id:9179,x:31876,y:32626,varname:node_9179,prsc:2,spu:-0.2,spv:-1|UVIN-8014-UVOUT;n:type:ShaderForge.SFN_Color,id:7215,x:32307,y:32437,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7215,prsc:2,glob:False,c1:0,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:9062,x:32521,y:32502,varname:node_9062,prsc:2|A-7215-RGB,B-4785-RGB,C-2296-OUT,D-9738-RGB;n:type:ShaderForge.SFN_Vector1,id:2296,x:32307,y:32352,varname:node_2296,prsc:2,v1:4;n:type:ShaderForge.SFN_TexCoord,id:8014,x:31692,y:32626,varname:node_8014,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2dAsset,id:748,x:32029,y:32745,ptovrint:False,ptlb:node_748,ptin:_node_748,varname:node_748,glob:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9738,x:32307,y:32790,varname:node_9738,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-6280-UVOUT,TEX-748-TEX;n:type:ShaderForge.SFN_Panner,id:6280,x:32108,y:32940,varname:node_6280,prsc:2,spu:0.5,spv:0;n:type:ShaderForge.SFN_Multiply,id:353,x:32509,y:32790,varname:node_353,prsc:2|A-4785-B,B-6712-OUT;n:type:ShaderForge.SFN_Vector1,id:6712,x:32277,y:33008,varname:node_6712,prsc:2,v1:0.8;proporder:7215-748;pass:END;sub:END;*/

Shader "Maans/FlameOrb" {
    Properties {
        _Color ("Color", Color) = (0,1,1,1)
        _node_748 ("node_748", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _node_748; uniform float4 _node_748_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float4 node_4226 = _Time + _TimeEditor;
                float2 node_9179 = (i.uv0+node_4226.g*float2(-0.2,-1));
                float4 node_4785 = tex2D(_node_748,TRANSFORM_TEX(node_9179, _node_748));
                clip((node_4785.b*0.8) - 0.5);
////// Lighting:
////// Emissive:
                float2 node_6280 = (i.uv0+node_4226.g*float2(0.5,0));
                float4 node_9738 = tex2D(_node_748,TRANSFORM_TEX(node_6280, _node_748));
                float3 emissive = (_Color.rgb*node_4785.rgb*4.0*node_9738.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _node_748; uniform float4 _node_748_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float4 node_4159 = _Time + _TimeEditor;
                float2 node_9179 = (i.uv0+node_4159.g*float2(-0.2,-1));
                float4 node_4785 = tex2D(_node_748,TRANSFORM_TEX(node_9179, _node_748));
                clip((node_4785.b*0.8) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
