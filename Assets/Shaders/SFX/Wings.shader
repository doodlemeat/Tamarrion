// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:3,bdst:7,culm:2,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:783,x:32719,y:32712,varname:node_783,prsc:2|emission-8756-OUT,alpha-7469-OUT,voffset-803-OUT,tess-7802-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7742,x:32188,y:33117,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_7742,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Add,id:8756,x:32420,y:32727,varname:node_8756,prsc:2|A-7678-OUT,B-3069-RGB,C-2425-OUT;n:type:ShaderForge.SFN_Slider,id:2101,x:31874,y:32529,ptovrint:False,ptlb:Emissive Power,ptin:_EmissivePower,varname:node_2101,prsc:2,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Color,id:3069,x:31941,y:32823,ptovrint:False,ptlb:Emissive Color,ptin:_EmissiveColor,varname:node_3069,prsc:2,glob:False,c1:0.9926471,c2:0.7006921,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:7678,x:32001,y:32650,varname:node_7678,prsc:2|A-7760-RGB,B-3069-RGB;n:type:ShaderForge.SFN_Tex2d,id:7760,x:31670,y:32709,ptovrint:False,ptlb:Emissive Filter,ptin:_EmissiveFilter,varname:node_7760,prsc:2,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False|UVIN-2812-UVOUT;n:type:ShaderForge.SFN_Panner,id:2812,x:31508,y:32709,varname:node_2812,prsc:2,spu:-1,spv:1|UVIN-1125-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1125,x:31347,y:32709,varname:node_1125,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:7802,x:32671,y:33242,ptovrint:False,ptlb:Tesselation,ptin:_Tesselation,varname:node_7802,prsc:2,min:1,cur:1,max:20;n:type:ShaderForge.SFN_Subtract,id:1635,x:31285,y:33333,varname:node_1635,prsc:2|A-5259-OUT,B-4366-OUT;n:type:ShaderForge.SFN_Vector1,id:4366,x:31024,y:33388,varname:node_4366,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Abs,id:8345,x:31516,y:33279,varname:node_8345,prsc:2|IN-1635-OUT;n:type:ShaderForge.SFN_Frac,id:5259,x:30992,y:33164,varname:node_5259,prsc:2|IN-4446-OUT;n:type:ShaderForge.SFN_Panner,id:4103,x:30632,y:33179,varname:node_4103,prsc:2,spu:-0.3,spv:0;n:type:ShaderForge.SFN_ComponentMask,id:4446,x:30805,y:33190,varname:node_4446,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-4103-UVOUT;n:type:ShaderForge.SFN_Multiply,id:3690,x:31689,y:33208,cmnt:Triangle Wave,varname:node_3690,prsc:2|A-8345-OUT,B-3421-OUT;n:type:ShaderForge.SFN_Vector1,id:3421,x:31379,y:33229,varname:node_3421,prsc:2,v1:2;n:type:ShaderForge.SFN_ValueProperty,id:8786,x:31689,y:33423,ptovrint:False,ptlb:Bulge Shape,ptin:_BulgeShape,varname:_BulgeShape,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Power,id:2300,x:31970,y:33265,cmnt:Panning gradient,varname:node_2300,prsc:2|VAL-3690-OUT,EXP-8786-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6774,x:31970,y:33478,ptovrint:False,ptlb:Glow Intensity,ptin:_GlowIntensity,varname:_GlowIntensity,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:4898,x:31970,y:33412,ptovrint:False,ptlb:Bulge Scale,ptin:_BulgeScale,varname:_BulgeScale,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:3128,x:32315,y:33377,varname:node_3128,prsc:2|A-2300-OUT,B-4898-OUT,C-2381-OUT,D-6774-OUT;n:type:ShaderForge.SFN_NormalVector,id:2381,x:32039,y:33673,prsc:2,pt:False;n:type:ShaderForge.SFN_Tex2d,id:2649,x:32297,y:33209,ptovrint:False,ptlb:Gradient,ptin:_Gradient,varname:node_2649,prsc:2,tex:63d3406a3784ed845a29c65ff8abb566,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:803,x:32483,y:33253,varname:node_803,prsc:2|A-3128-OUT,B-2649-RGB;n:type:ShaderForge.SFN_Multiply,id:2425,x:32280,y:32567,varname:node_2425,prsc:2|A-2101-OUT,B-3069-RGB,C-7227-OUT;n:type:ShaderForge.SFN_Multiply,id:7469,x:32453,y:33029,varname:node_7469,prsc:2|A-7227-OUT,B-7742-OUT;n:type:ShaderForge.SFN_Tex2d,id:1936,x:31360,y:32916,ptovrint:False,ptlb:Blur,ptin:_Blur,varname:node_1936,prsc:2,tex:74478dcb94220c0439e1973b1eb50e0c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Power,id:7227,x:31779,y:33023,varname:node_7227,prsc:2|VAL-1936-B,EXP-934-OUT;n:type:ShaderForge.SFN_Slider,id:934,x:31320,y:33133,ptovrint:False,ptlb:Softness,ptin:_Softness,varname:node_934,prsc:2,min:1,cur:1,max:100;n:type:ShaderForge.SFN_Tex2d,id:2653,x:32025,y:33010,ptovrint:False,ptlb:Emissive_copy,ptin:_Emissive_copy,varname:_Emissive_copy,prsc:2,tex:3f9fcc76dc4ddae4787a00d60aa37349,ntxv:0,isnm:False;proporder:7742-7760-3069-2101-7802-8786-4898-6774-2649-1936-934;pass:END;sub:END;*/

Shader "SpellFX/Wings" {
    Properties {
        _Opacity ("Opacity", Float ) = 1
        _EmissiveFilter ("Emissive Filter", 2D) = "white" {}
        _EmissiveColor ("Emissive Color", Color) = (0.9926471,0.7006921,0,1)
        _EmissivePower ("Emissive Power", Range(0, 10)) = 1
        _Tesselation ("Tesselation", Range(1, 20)) = 1
        _BulgeShape ("Bulge Shape", Float ) = 1
        _BulgeScale ("Bulge Scale", Float ) = 0.5
        _GlowIntensity ("Glow Intensity", Float ) = 1
        _Gradient ("Gradient", 2D) = "white" {}
        _Blur ("Blur", 2D) = "white" {}
        _Softness ("Softness", Range(1, 100)) = 1
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float _Opacity;
            uniform float _EmissivePower;
            uniform float4 _EmissiveColor;
            uniform sampler2D _EmissiveFilter; uniform float4 _EmissiveFilter_ST;
            uniform float _Tesselation;
            uniform float _BulgeShape;
            uniform float _GlowIntensity;
            uniform float _BulgeScale;
            uniform sampler2D _Gradient; uniform float4 _Gradient_ST;
            uniform sampler2D _Blur; uniform float4 _Blur_ST;
            uniform float _Softness;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
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
                float4 node_6287 = _Time + _TimeEditor;
                float4 _Gradient_var = tex2Dlod(_Gradient,float4(TRANSFORM_TEX(o.uv0, _Gradient),0.0,0));
                v.vertex.xyz += ((pow((abs((frac((o.uv0+node_6287.g*float2(-0.3,0)).r)-0.5))*2.0),_BulgeShape)*_BulgeScale*v.normal*_GlowIntensity)*_Gradient_var.rgb);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    return _Tesselation;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                
                float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
                i.normalDir *= nSign;
                normalDirection *= nSign;
                
////// Lighting:
////// Emissive:
                float4 node_6287 = _Time + _TimeEditor;
                float2 node_2812 = (i.uv0+node_6287.g*float2(-1,1));
                float4 _EmissiveFilter_var = tex2D(_EmissiveFilter,TRANSFORM_TEX(node_2812, _EmissiveFilter));
                float4 _Blur_var = tex2D(_Blur,TRANSFORM_TEX(i.uv0, _Blur));
                float node_7227 = pow(_Blur_var.b,_Softness);
                float3 emissive = ((_EmissiveFilter_var.rgb*_EmissiveColor.rgb)+_EmissiveColor.rgb+(_EmissivePower*_EmissiveColor.rgb*node_7227));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(node_7227*_Opacity));
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float _Tesselation;
            uniform float _BulgeShape;
            uniform float _GlowIntensity;
            uniform float _BulgeScale;
            uniform sampler2D _Gradient; uniform float4 _Gradient_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_4162 = _Time + _TimeEditor;
                float4 _Gradient_var = tex2Dlod(_Gradient,float4(TRANSFORM_TEX(o.uv0, _Gradient),0.0,0));
                v.vertex.xyz += ((pow((abs((frac((o.uv0+node_4162.g*float2(-0.3,0)).r)-0.5))*2.0),_BulgeShape)*_BulgeScale*v.normal*_GlowIntensity)*_Gradient_var.rgb);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    return _Tesselation;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                
                float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
                i.normalDir *= nSign;
                normalDirection *= nSign;
                
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
