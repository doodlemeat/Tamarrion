// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:783,x:32719,y:32712,varname:node_783,prsc:2|emission-9845-OUT,alpha-9773-OUT;n:type:ShaderForge.SFN_Tex2d,id:2062,x:31570,y:32928,ptovrint:False,ptlb:Beam1,ptin:_Beam1,varname:node_4271,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c2e2a0c4ba746a9468c4d69ab06765bf,ntxv:0,isnm:False|UVIN-17-UVOUT;n:type:ShaderForge.SFN_Panner,id:17,x:31370,y:32974,varname:node_17,prsc:2,spu:0,spv:2|UVIN-4862-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:2375,x:31435,y:33137,ptovrint:False,ptlb:Beam2,ptin:_Beam2,varname:node_1213,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e5256936abefb9a47a2007c48dfa8818,ntxv:0,isnm:False|UVIN-3152-UVOUT;n:type:ShaderForge.SFN_Add,id:2788,x:31826,y:33054,varname:node_2788,prsc:2|A-2062-B,B-5678-OUT;n:type:ShaderForge.SFN_Panner,id:3152,x:31254,y:33120,varname:node_3152,prsc:2,spu:0,spv:-2|UVIN-5791-UVOUT;n:type:ShaderForge.SFN_Multiply,id:5678,x:31654,y:33154,varname:node_5678,prsc:2|A-2375-B,B-5447-OUT,C-4024-B;n:type:ShaderForge.SFN_Vector1,id:5447,x:31456,y:33378,varname:node_5447,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:4024,x:31254,y:33305,ptovrint:False,ptlb:Disturbance,ptin:_Disturbance,varname:node_6399,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-8000-UVOUT;n:type:ShaderForge.SFN_Panner,id:8000,x:31047,y:33293,varname:node_8000,prsc:2,spu:-0.1,spv:-0.1|UVIN-1956-UVOUT;n:type:ShaderForge.SFN_Color,id:4262,x:31570,y:32727,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9473,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:6223,x:31847,y:32744,varname:node_6223,prsc:2|A-4262-RGB,B-2788-OUT;n:type:ShaderForge.SFN_Tex2d,id:5998,x:31570,y:32554,ptovrint:False,ptlb:Gradient,ptin:_Gradient,varname:node_6370,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5ba07aac9c2697747acc66e995b0a3c0,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1598,x:31847,y:32584,varname:node_1598,prsc:2|A-5998-B,B-5998-B,C-5998-B,D-5998-B;n:type:ShaderForge.SFN_Multiply,id:2021,x:32160,y:32706,varname:node_2021,prsc:2|A-1598-OUT,B-6223-OUT;n:type:ShaderForge.SFN_Add,id:7785,x:32160,y:32558,varname:node_7785,prsc:2|A-1598-OUT,B-6223-OUT;n:type:ShaderForge.SFN_Multiply,id:7605,x:32369,y:32624,varname:node_7605,prsc:2|A-7785-OUT,B-2021-OUT;n:type:ShaderForge.SFN_Add,id:8493,x:32160,y:32856,varname:node_8493,prsc:2|A-1598-OUT,B-2788-OUT;n:type:ShaderForge.SFN_Add,id:8176,x:32745,y:32401,varname:node_8176,prsc:2|A-7785-OUT,B-7605-OUT;n:type:ShaderForge.SFN_Tex2d,id:8008,x:31570,y:32369,ptovrint:False,ptlb:BreakGradient,ptin:_BreakGradient,varname:node_646,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6f4a6a22452da824781e424581661283,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9773,x:32403,y:32819,varname:node_9773,prsc:2|A-8008-B,B-8493-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8836,x:32486,y:32357,ptovrint:False,ptlb:Emissive Power,ptin:_EmissivePower,varname:node_8836,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:9845,x:32792,y:32582,varname:node_9845,prsc:2|A-8176-OUT,B-8836-OUT;n:type:ShaderForge.SFN_TexCoord,id:4862,x:31167,y:32974,varname:node_4862,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:5791,x:31060,y:33120,varname:node_5791,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:1956,x:30845,y:33293,varname:node_1956,prsc:2,uv:0;proporder:2062-2375-4024-4262-5998-8008-8836;pass:END;sub:END;*/

Shader "Custom/Beam" {
    Properties {
        _Beam1 ("Beam1", 2D) = "white" {}
        _Beam2 ("Beam2", 2D) = "white" {}
        _Disturbance ("Disturbance", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Gradient ("Gradient", 2D) = "white" {}
        _BreakGradient ("BreakGradient", 2D) = "white" {}
        _EmissivePower ("Emissive Power", Float ) = 1
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
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Beam1; uniform float4 _Beam1_ST;
            uniform sampler2D _Beam2; uniform float4 _Beam2_ST;
            uniform sampler2D _Disturbance; uniform float4 _Disturbance_ST;
            uniform float4 _Color;
            uniform sampler2D _Gradient; uniform float4 _Gradient_ST;
            uniform sampler2D _BreakGradient; uniform float4 _BreakGradient_ST;
            uniform float _EmissivePower;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _Gradient_var = tex2D(_Gradient,TRANSFORM_TEX(i.uv0, _Gradient));
                float node_1598 = (_Gradient_var.b*_Gradient_var.b*_Gradient_var.b*_Gradient_var.b);
                float4 node_3397 = _Time + _TimeEditor;
                float2 node_17 = (i.uv0+node_3397.g*float2(0,2));
                float4 _Beam1_var = tex2D(_Beam1,TRANSFORM_TEX(node_17, _Beam1));
                float2 node_3152 = (i.uv0+node_3397.g*float2(0,-2));
                float4 _Beam2_var = tex2D(_Beam2,TRANSFORM_TEX(node_3152, _Beam2));
                float2 node_8000 = (i.uv0+node_3397.g*float2(-0.1,-0.1));
                float4 _Disturbance_var = tex2D(_Disturbance,TRANSFORM_TEX(node_8000, _Disturbance));
                float node_2788 = (_Beam1_var.b+(_Beam2_var.b*0.5*_Disturbance_var.b));
                float3 node_6223 = (_Color.rgb*node_2788);
                float3 node_7785 = (node_1598+node_6223);
                float3 emissive = ((node_7785+(node_7785*(node_1598*node_6223)))*_EmissivePower);
                float3 finalColor = emissive;
                float4 _BreakGradient_var = tex2D(_BreakGradient,TRANSFORM_TEX(i.uv0, _BreakGradient));
                return fixed4(finalColor,(_BreakGradient_var.b*(node_1598+node_2788)));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
