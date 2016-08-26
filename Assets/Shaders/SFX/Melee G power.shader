// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:8935,x:32719,y:32712,varname:node_8935,prsc:2|emission-6102-OUT,alpha-4426-OUT;n:type:ShaderForge.SFN_Color,id:4179,x:31127,y:32497,ptovrint:False,ptlb:Emissive,ptin:_Emissive,varname:node_4179,prsc:2,glob:False,c1:0.9558824,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:2732,x:30985,y:32295,varname:node_2732,prsc:2,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False|UVIN-2063-UVOUT,TEX-2334-TEX;n:type:ShaderForge.SFN_Multiply,id:7735,x:31382,y:32409,varname:node_7735,prsc:2|A-2732-RGB,B-4179-RGB;n:type:ShaderForge.SFN_Panner,id:2063,x:30764,y:32295,varname:node_2063,prsc:2,spu:0,spv:-0.5;n:type:ShaderForge.SFN_Add,id:7448,x:31382,y:32288,varname:node_7448,prsc:2|A-2732-RGB,B-4179-RGB,C-708-RGB;n:type:ShaderForge.SFN_Multiply,id:6102,x:31715,y:32376,varname:node_6102,prsc:2|A-7163-OUT,B-7735-OUT,C-1403-OUT;n:type:ShaderForge.SFN_Slider,id:4426,x:32083,y:32897,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:_Opacity_copy,prsc:2,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Tex2dAsset,id:2334,x:30563,y:32190,ptovrint:False,ptlb:Emissive Texture,ptin:_EmissiveTexture,varname:node_2334,glob:False,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:708,x:31085,y:32102,varname:node_708,prsc:2,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False|UVIN-7249-UVOUT,TEX-2334-TEX;n:type:ShaderForge.SFN_Panner,id:7249,x:30909,y:31945,varname:node_7249,prsc:2,spu:-0.1,spv:0;n:type:ShaderForge.SFN_Power,id:7163,x:31488,y:32108,varname:node_7163,prsc:2|VAL-7448-OUT,EXP-9071-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9071,x:31311,y:32142,ptovrint:False,ptlb:Emissive Power,ptin:_EmissivePower,varname:node_9071,prsc:2,glob:False,v1:2;n:type:ShaderForge.SFN_OneMinus,id:1403,x:31359,y:32563,varname:node_1403,prsc:2|IN-2732-RGB;proporder:4179-4426-2334-9071;pass:END;sub:END;*/

Shader "SpellFX/WeaponMeleeGlow" {
    Properties {
        _Emissive ("Emissive", Color) = (0.9558824,0,0,1)
        _Opacity ("Opacity", Range(0, 1)) = 0.5
        _EmissiveTexture ("Emissive Texture", 2D) = "white" {}
        _EmissivePower ("Emissive Power", Float ) = 2
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
            uniform float4 _Emissive;
            uniform float _Opacity;
            uniform sampler2D _EmissiveTexture; uniform float4 _EmissiveTexture_ST;
            uniform float _EmissivePower;
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
////// Lighting:
////// Emissive:
                float4 node_4135 = _Time + _TimeEditor;
                float2 node_2063 = (i.uv0+node_4135.g*float2(0,-0.5));
                float4 node_2732 = tex2D(_EmissiveTexture,TRANSFORM_TEX(node_2063, _EmissiveTexture));
                float2 node_7249 = (i.uv0+node_4135.g*float2(-0.1,0));
                float4 node_708 = tex2D(_EmissiveTexture,TRANSFORM_TEX(node_7249, _EmissiveTexture));
                float3 emissive = (pow((node_2732.rgb+_Emissive.rgb+node_708.rgb),_EmissivePower)*(node_2732.rgb*_Emissive.rgb)*(1.0 - node_2732.rgb));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,_Opacity);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
