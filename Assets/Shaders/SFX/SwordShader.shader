// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:783,x:32719,y:32712,varname:node_783,prsc:2|emission-2717-OUT,alpha-8218-OUT;n:type:ShaderForge.SFN_Tex2d,id:2354,x:32167,y:32810,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_2354,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:246,x:32463,y:33222,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_246,prsc:2,glob:False,v1:0.75;n:type:ShaderForge.SFN_Multiply,id:6538,x:32256,y:32645,varname:node_6538,prsc:2|A-3503-RGB,B-618-OUT,C-9283-OUT;n:type:ShaderForge.SFN_Color,id:3503,x:31963,y:32625,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3503,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ViewVector,id:5700,x:31722,y:32980,varname:node_5700,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:7669,x:31722,y:33106,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:1126,x:31953,y:33036,varname:node_1126,prsc:2,dt:0|A-5700-OUT,B-7669-OUT;n:type:ShaderForge.SFN_Multiply,id:8218,x:32436,y:33018,varname:node_8218,prsc:2|A-1126-OUT,B-246-OUT;n:type:ShaderForge.SFN_OneMinus,id:618,x:31963,y:32764,varname:node_618,prsc:2|IN-1126-OUT;n:type:ShaderForge.SFN_Add,id:2717,x:32498,y:32712,varname:node_2717,prsc:2|A-6538-OUT,B-5896-OUT,C-341-OUT;n:type:ShaderForge.SFN_Multiply,id:5896,x:32416,y:32838,varname:node_5896,prsc:2|A-2354-RGB,B-1855-OUT;n:type:ShaderForge.SFN_Vector1,id:1855,x:32416,y:32958,varname:node_1855,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:9283,x:32256,y:32589,varname:node_9283,prsc:2,v1:2;n:type:ShaderForge.SFN_Tex2d,id:1311,x:32498,y:32538,ptovrint:False,ptlb:Emissive Map,ptin:_EmissiveMap,varname:node_1311,prsc:2,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:341,x:32699,y:32517,varname:node_341,prsc:2|A-7008-RGB,B-1311-RGB,C-9512-OUT;n:type:ShaderForge.SFN_Color,id:7008,x:32498,y:32377,ptovrint:False,ptlb:Emissive Color,ptin:_EmissiveColor,varname:node_7008,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:9512,x:32699,y:32436,ptovrint:False,ptlb:Emissive Power,ptin:_EmissivePower,varname:node_9512,prsc:2,glob:False,v1:0;proporder:2354-246-3503-1311-7008-9512;pass:END;sub:END;*/

Shader "Custom/MagicOrb" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Opacity ("Opacity", Float ) = 0.75
        _Color ("Color", Color) = (1,1,1,1)
        _EmissiveMap ("Emissive Map", 2D) = "black" {}
        _EmissiveColor ("Emissive Color", Color) = (1,1,1,1)
        _EmissivePower ("Emissive Power", Float ) = 0
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _Opacity;
            uniform float4 _Color;
            uniform sampler2D _EmissiveMap; uniform float4 _EmissiveMap_ST;
            uniform float4 _EmissiveColor;
            uniform float _EmissivePower;
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
                float node_1126 = dot(viewDirection,i.normalDir);
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float4 _EmissiveMap_var = tex2D(_EmissiveMap,TRANSFORM_TEX(i.uv0, _EmissiveMap));
                float3 emissive = ((_Color.rgb*(1.0 - node_1126)*2.0)+(_Diffuse_var.rgb*0.5)+(_EmissiveColor.rgb*_EmissiveMap_var.rgb*_EmissivePower));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(node_1126*_Opacity));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
