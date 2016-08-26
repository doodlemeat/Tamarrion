// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:783,x:32719,y:32712,varname:node_783,prsc:2|emission-309-OUT,alpha-2992-OUT,clip-645-OUT;n:type:ShaderForge.SFN_Slider,id:7802,x:31748,y:33065,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_7802,prsc:2,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Color,id:1079,x:32083,y:32513,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,varname:node_1079,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:927,x:32083,y:32697,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_927,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4983,x:32140,y:33175,ptovrint:False,ptlb:Clipping Mask,ptin:_ClippingMask,varname:node_4983,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:645,x:32430,y:33152,varname:node_645,prsc:2|A-4983-B,B-1352-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1352,x:32140,y:33352,ptovrint:False,ptlb:Clipping Power,ptin:_ClippingPower,varname:node_1352,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Add,id:309,x:32349,y:32599,varname:node_309,prsc:2|A-1079-RGB,B-927-RGB;n:type:ShaderForge.SFN_Multiply,id:2992,x:32261,y:32952,varname:node_2992,prsc:2|A-7183-B,B-7802-OUT;n:type:ShaderForge.SFN_Tex2d,id:7183,x:31776,y:32845,ptovrint:False,ptlb:Opacity Mask,ptin:_OpacityMask,varname:node_7183,prsc:2,ntxv:2,isnm:False;proporder:7802-1079-927-4983-1352-7183;pass:END;sub:END;*/

Shader "Custom/SingleSidedTrans" {
    Properties {
        _Opacity ("Opacity", Range(0, 1)) = 1
        _DiffuseColor ("Diffuse Color", Color) = (1,1,1,1)
        _Diffuse ("Diffuse", 2D) = "white" {}
        _ClippingMask ("Clipping Mask", 2D) = "white" {}
        _ClippingPower ("Clipping Power", Float ) = 1
        _OpacityMask ("Opacity Mask", 2D) = "black" {}
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
            uniform float4 _DiffuseColor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _ClippingMask; uniform float4 _ClippingMask_ST;
            uniform float _ClippingPower;
            uniform sampler2D _OpacityMask; uniform float4 _OpacityMask_ST;
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
                float4 _ClippingMask_var = tex2D(_ClippingMask,TRANSFORM_TEX(i.uv0, _ClippingMask));
                clip((_ClippingMask_var.b*_ClippingPower) - 0.5);
////// Lighting:
////// Emissive:
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 emissive = (_DiffuseColor.rgb+_Diffuse_var.rgb);
                float3 finalColor = emissive;
                float4 _OpacityMask_var = tex2D(_OpacityMask,TRANSFORM_TEX(i.uv0, _OpacityMask));
                fixed4 finalRGBA = fixed4(finalColor,(_OpacityMask_var.b*_Opacity));
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
            uniform sampler2D _ClippingMask; uniform float4 _ClippingMask_ST;
            uniform float _ClippingPower;
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
                float4 _ClippingMask_var = tex2D(_ClippingMask,TRANSFORM_TEX(i.uv0, _ClippingMask));
                clip((_ClippingMask_var.b*_ClippingPower) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
