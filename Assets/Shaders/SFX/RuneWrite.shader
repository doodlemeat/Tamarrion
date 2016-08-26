// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:0,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4825,x:32719,y:32712,varname:node_4825,prsc:2|diff-3073-OUT,normal-8512-RGB,emission-4834-OUT,difocc-5714-B,clip-5120-OUT;n:type:ShaderForge.SFN_Tex2d,id:3373,x:32871,y:32365,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_3373,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8512,x:32412,y:32377,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_8512,prsc:2,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:5714,x:31574,y:32783,ptovrint:False,ptlb:AO,ptin:_AO,varname:node_5714,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3073,x:32871,y:32541,varname:node_3073,prsc:2|A-3373-RGB,B-3343-RGB;n:type:ShaderForge.SFN_Color,id:3343,x:32718,y:32541,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,varname:node_3343,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:8197,x:32063,y:32610,varname:node_8197,prsc:2|A-5791-RGB,B-1845-OUT,C-5003-OUT,D-5315-OUT;n:type:ShaderForge.SFN_Tex2d,id:5791,x:31833,y:32351,ptovrint:False,ptlb:Emmissive Map,ptin:_EmmissiveMap,varname:node_5791,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:1845,x:31787,y:32780,ptovrint:False,ptlb:Emissive Power,ptin:_EmissivePower,varname:node_1845,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_Color,id:5147,x:31251,y:32453,ptovrint:False,ptlb:Start Emissive Color,ptin:_StartEmissiveColor,varname:node_5147,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Lerp,id:5003,x:31565,y:32542,varname:node_5003,prsc:2|A-5147-RGB,B-8478-RGB,T-5028-OUT;n:type:ShaderForge.SFN_Color,id:8478,x:31251,y:32618,ptovrint:False,ptlb:End Emissive Color,ptin:_EndEmissiveColor,varname:node_8478,prsc:2,glob:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:5028,x:31173,y:32795,ptovrint:False,ptlb:Emissive Color Slider,ptin:_EmissiveColorSlider,varname:node_5028,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:7377,x:31748,y:32977,ptovrint:False,ptlb:Emissive Noise,ptin:_EmissiveNoise,varname:node_7377,prsc:2,ntxv:0,isnm:False|UVIN-8564-UVOUT;n:type:ShaderForge.SFN_Panner,id:8564,x:31574,y:32977,varname:node_8564,prsc:2,spu:0.02,spv:0.01;n:type:ShaderForge.SFN_Tex2d,id:9300,x:31391,y:33258,ptovrint:False,ptlb:Clipping Mask,ptin:_ClippingMask,varname:node_9300,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:5120,x:31851,y:33339,varname:node_5120,prsc:2|A-5393-OUT,B-3145-OUT,T-8186-OUT;n:type:ShaderForge.SFN_Multiply,id:3145,x:31599,y:33356,varname:node_3145,prsc:2|A-9300-B,B-6168-OUT;n:type:ShaderForge.SFN_Vector1,id:6168,x:31391,y:33426,varname:node_6168,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Slider,id:8186,x:31773,y:33513,ptovrint:False,ptlb:Clipping Slider,ptin:_ClippingSlider,varname:node_8186,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector3,id:5393,x:31851,y:33240,varname:node_5393,prsc:2,v1:1,v2:1,v3:1;n:type:ShaderForge.SFN_OneMinus,id:5052,x:32392,y:33278,varname:node_5052,prsc:2|IN-2725-OUT;n:type:ShaderForge.SFN_Lerp,id:2725,x:32210,y:33278,varname:node_2725,prsc:2|A-5393-OUT,B-9300-B,T-8186-OUT;n:type:ShaderForge.SFN_Add,id:4834,x:32390,y:32738,varname:node_4834,prsc:2|A-8197-OUT,B-4226-OUT;n:type:ShaderForge.SFN_Multiply,id:4226,x:32130,y:32924,varname:node_4226,prsc:2|A-8478-RGB,B-5052-OUT;n:type:ShaderForge.SFN_Multiply,id:5315,x:31986,y:32787,varname:node_5315,prsc:2|A-7377-RGB,B-1689-OUT;n:type:ShaderForge.SFN_Vector1,id:1689,x:31748,y:32899,varname:node_1689,prsc:2,v1:1;proporder:3373-3343-8512-5714-5791-1845-5147-8478-5028-7377-9300-8186;pass:END;sub:END;*/

Shader "Custom/RuneWrite" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _DiffuseColor ("Diffuse Color", Color) = (1,1,1,1)
        _Normal ("Normal", 2D) = "bump" {}
        _AO ("AO", 2D) = "white" {}
        _EmmissiveMap ("Emmissive Map", 2D) = "white" {}
        _EmissivePower ("Emissive Power", Float ) = 0
        _StartEmissiveColor ("Start Emissive Color", Color) = (1,1,1,1)
        _EndEmissiveColor ("End Emissive Color", Color) = (0,0,0,1)
        _EmissiveColorSlider ("Emissive Color Slider", Range(0, 1)) = 0
        _EmissiveNoise ("Emissive Noise", 2D) = "white" {}
        _ClippingMask ("Clipping Mask", 2D) = "white" {}
        _ClippingSlider ("Clipping Slider", Range(0, 1)) = 0
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            uniform float4 _DiffuseColor;
            uniform sampler2D _EmmissiveMap; uniform float4 _EmmissiveMap_ST;
            uniform float _EmissivePower;
            uniform float4 _StartEmissiveColor;
            uniform float4 _EndEmissiveColor;
            uniform float _EmissiveColorSlider;
            uniform sampler2D _EmissiveNoise; uniform float4 _EmissiveNoise_ST;
            uniform sampler2D _ClippingMask; uniform float4 _ClippingMask_ST;
            uniform float _ClippingSlider;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
            #endif
            #ifdef DYNAMICLIGHTMAP_ON
                o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
            #endif
            o.normalDir = UnityObjectToWorldNormal(v.normal);
            o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
            o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
            o.posWorld = mul(unity_ObjectToWorld, v.vertex);
            float3 lightColor = _LightColor0.rgb;
            o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
            UNITY_TRANSFER_FOG(o,o.pos);
            TRANSFER_VERTEX_TO_FRAGMENT(o)
            return o;
        }
        float4 frag(VertexOutput i) : COLOR {
            i.normalDir = normalize(i.normalDir);
            float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
            float3 normalLocal = _Normal_var.rgb;
            float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
            float3 node_5393 = float3(1,1,1);
            float4 _ClippingMask_var = tex2D(_ClippingMask,TRANSFORM_TEX(i.uv0, _ClippingMask));
            float node_3145 = (_ClippingMask_var.b*0.5);
            clip(lerp(node_5393,float3(node_3145,node_3145,node_3145),_ClippingSlider) - 0.5);
            float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
            float3 lightColor = _LightColor0.rgb;
// Lighting:
            float attenuation = LIGHT_ATTENUATION(i);
            float3 attenColor = attenuation * _LightColor0.xyz;
/// GI Data:
            UnityLight light;
            #ifdef LIGHTMAP_OFF
                light.color = lightColor;
                light.dir = lightDirection;
                light.ndotl = LambertTerm (normalDirection, light.dir);
            #else
                light.color = half3(0.f, 0.f, 0.f);
                light.ndotl = 0.0f;
                light.dir = half3(0.f, 0.f, 0.f);
            #endif
            UnityGIInput d;
            d.light = light;
            d.worldPos = i.posWorld.xyz;
            d.worldViewDir = viewDirection;
            d.atten = attenuation;
            #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                d.ambient = 0;
                d.lightmapUV = i.ambientOrLightmapUV;
            #else
                d.ambient = i.ambientOrLightmapUV;
            #endif
            UnityGI gi = UnityGlobalIllumination (d, 1, 0, normalDirection);
            lightDirection = gi.light.dir;
            lightColor = gi.light.color;
/// Diffuse:
            float NdotL = max(0.0,dot( normalDirection, lightDirection ));
            float3 directDiffuse = max( 0.0, NdotL) * attenColor;
            float3 indirectDiffuse = float3(0,0,0);
            indirectDiffuse += gi.indirect.diffuse;
            float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
            indirectDiffuse *= _AO_var.b; // Diffuse AO
            float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
            float3 diffuseColor = (_Diffuse_var.rgb*_DiffuseColor.rgb);
            float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
// Emissive:
            float4 _EmmissiveMap_var = tex2D(_EmmissiveMap,TRANSFORM_TEX(i.uv0, _EmmissiveMap));
            float4 node_4614 = _Time + _TimeEditor;
            float2 node_8564 = (i.uv0+node_4614.g*float2(0.02,0.01));
            float4 _EmissiveNoise_var = tex2D(_EmissiveNoise,TRANSFORM_TEX(node_8564, _EmissiveNoise));
            float3 emissive = ((_EmmissiveMap_var.rgb*_EmissivePower*lerp(_StartEmissiveColor.rgb,_EndEmissiveColor.rgb,_EmissiveColorSlider)*(_EmissiveNoise_var.rgb*1.0))+(_EndEmissiveColor.rgb*(1.0 - lerp(node_5393,float3(_ClippingMask_var.b,_ClippingMask_var.b,_ClippingMask_var.b),_ClippingSlider))));
// Final Color:
            float3 finalColor = diffuse + emissive;
            fixed4 finalRGBA = fixed4(finalColor,1);
            UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
            return finalRGBA;
        }
        ENDCG
    }
    Pass {
        Name "FORWARD_DELTA"
        Tags {
            "LightMode"="ForwardAdd"
        }
        Blend One One
        
        
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #define UNITY_PASS_FORWARDADD
        #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
        #include "UnityCG.cginc"
        #include "AutoLight.cginc"
        #include "Lighting.cginc"
        #include "UnityPBSLighting.cginc"
        #include "UnityStandardBRDF.cginc"
        #pragma multi_compile_fwdadd_fullshadows
        #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
        #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
        #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
        #pragma multi_compile_fog
        #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
        #pragma target 3.0
        uniform float4 _TimeEditor;
        uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
        uniform sampler2D _Normal; uniform float4 _Normal_ST;
        uniform float4 _DiffuseColor;
        uniform sampler2D _EmmissiveMap; uniform float4 _EmmissiveMap_ST;
        uniform float _EmissivePower;
        uniform float4 _StartEmissiveColor;
        uniform float4 _EndEmissiveColor;
        uniform float _EmissiveColorSlider;
        uniform sampler2D _EmissiveNoise; uniform float4 _EmissiveNoise_ST;
        uniform sampler2D _ClippingMask; uniform float4 _ClippingMask_ST;
        uniform float _ClippingSlider;
        struct VertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            float4 tangent : TANGENT;
            float2 texcoord0 : TEXCOORD0;
            float2 texcoord1 : TEXCOORD1;
            float2 texcoord2 : TEXCOORD2;
        };
        struct VertexOutput {
            float4 pos : SV_POSITION;
            float2 uv0 : TEXCOORD0;
            float2 uv1 : TEXCOORD1;
            float2 uv2 : TEXCOORD2;
            float4 posWorld : TEXCOORD3;
            float3 normalDir : TEXCOORD4;
            float3 tangentDir : TEXCOORD5;
            float3 bitangentDir : TEXCOORD6;
            LIGHTING_COORDS(7,8)
        };
        VertexOutput vert (VertexInput v) {
            VertexOutput o = (VertexOutput)0;
            o.uv0 = v.texcoord0;
            o.uv1 = v.texcoord1;
            o.uv2 = v.texcoord2;
            o.normalDir = UnityObjectToWorldNormal(v.normal);
            o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
            o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
            o.posWorld = mul(unity_ObjectToWorld, v.vertex);
            float3 lightColor = _LightColor0.rgb;
            o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
            TRANSFER_VERTEX_TO_FRAGMENT(o)
            return o;
        }
        float4 frag(VertexOutput i) : COLOR {
            i.normalDir = normalize(i.normalDir);
            float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
            float3 normalLocal = _Normal_var.rgb;
            float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
            float3 node_5393 = float3(1,1,1);
            float4 _ClippingMask_var = tex2D(_ClippingMask,TRANSFORM_TEX(i.uv0, _ClippingMask));
            float node_3145 = (_ClippingMask_var.b*0.5);
            clip(lerp(node_5393,float3(node_3145,node_3145,node_3145),_ClippingSlider) - 0.5);
            float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
            float3 lightColor = _LightColor0.rgb;
// Lighting:
            float attenuation = LIGHT_ATTENUATION(i);
            float3 attenColor = attenuation * _LightColor0.xyz;
/// Diffuse:
            float NdotL = max(0.0,dot( normalDirection, lightDirection ));
            float3 directDiffuse = max( 0.0, NdotL) * attenColor;
            float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
            float3 diffuseColor = (_Diffuse_var.rgb*_DiffuseColor.rgb);
            float3 diffuse = directDiffuse * diffuseColor;
// Final Color:
            float3 finalColor = diffuse;
            return fixed4(finalColor * 1,0);
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
        #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
        #include "UnityCG.cginc"
        #include "Lighting.cginc"
        #include "UnityPBSLighting.cginc"
        #include "UnityStandardBRDF.cginc"
        #pragma fragmentoption ARB_precision_hint_fastest
        #pragma multi_compile_shadowcaster
        #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
        #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
        #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
        #pragma multi_compile_fog
        #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
        #pragma target 3.0
        uniform sampler2D _ClippingMask; uniform float4 _ClippingMask_ST;
        uniform float _ClippingSlider;
        struct VertexInput {
            float4 vertex : POSITION;
            float2 texcoord0 : TEXCOORD0;
            float2 texcoord1 : TEXCOORD1;
            float2 texcoord2 : TEXCOORD2;
        };
        struct VertexOutput {
            V2F_SHADOW_CASTER;
            float2 uv0 : TEXCOORD1;
            float2 uv1 : TEXCOORD2;
            float2 uv2 : TEXCOORD3;
            float4 posWorld : TEXCOORD4;
        };
        VertexOutput vert (VertexInput v) {
            VertexOutput o = (VertexOutput)0;
            o.uv0 = v.texcoord0;
            o.uv1 = v.texcoord1;
            o.uv2 = v.texcoord2;
            o.posWorld = mul(unity_ObjectToWorld, v.vertex);
            o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
            TRANSFER_SHADOW_CASTER(o)
            return o;
        }
        float4 frag(VertexOutput i) : COLOR {
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            float3 node_5393 = float3(1,1,1);
            float4 _ClippingMask_var = tex2D(_ClippingMask,TRANSFORM_TEX(i.uv0, _ClippingMask));
            float node_3145 = (_ClippingMask_var.b*0.5);
            clip(lerp(node_5393,float3(node_3145,node_3145,node_3145),_ClippingSlider) - 0.5);
            SHADOW_CASTER_FRAGMENT(i)
        }
        ENDCG
    }
    Pass {
        Name "Meta"
        Tags {
            "LightMode"="Meta"
        }
        Cull Off
        
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #define UNITY_PASS_META 1
        #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
        #include "UnityCG.cginc"
        #include "Lighting.cginc"
        #include "UnityPBSLighting.cginc"
        #include "UnityStandardBRDF.cginc"
        #include "UnityMetaPass.cginc"
        #pragma fragmentoption ARB_precision_hint_fastest
        #pragma multi_compile_shadowcaster
        #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
        #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
        #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
        #pragma multi_compile_fog
        #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
        #pragma target 3.0
        uniform float4 _TimeEditor;
        uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
        uniform float4 _DiffuseColor;
        uniform sampler2D _EmmissiveMap; uniform float4 _EmmissiveMap_ST;
        uniform float _EmissivePower;
        uniform float4 _StartEmissiveColor;
        uniform float4 _EndEmissiveColor;
        uniform float _EmissiveColorSlider;
        uniform sampler2D _EmissiveNoise; uniform float4 _EmissiveNoise_ST;
        uniform sampler2D _ClippingMask; uniform float4 _ClippingMask_ST;
        uniform float _ClippingSlider;
        struct VertexInput {
            float4 vertex : POSITION;
            float2 texcoord0 : TEXCOORD0;
            float2 texcoord1 : TEXCOORD1;
            float2 texcoord2 : TEXCOORD2;
        };
        struct VertexOutput {
            float4 pos : SV_POSITION;
            float2 uv0 : TEXCOORD0;
            float2 uv1 : TEXCOORD1;
            float2 uv2 : TEXCOORD2;
            float4 posWorld : TEXCOORD3;
        };
        VertexOutput vert (VertexInput v) {
            VertexOutput o = (VertexOutput)0;
            o.uv0 = v.texcoord0;
            o.uv1 = v.texcoord1;
            o.uv2 = v.texcoord2;
            o.posWorld = mul(unity_ObjectToWorld, v.vertex);
            o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
            return o;
        }
        float4 frag(VertexOutput i) : SV_Target {
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            UnityMetaInput o;
            UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
            
            float4 _EmmissiveMap_var = tex2D(_EmmissiveMap,TRANSFORM_TEX(i.uv0, _EmmissiveMap));
            float4 node_6131 = _Time + _TimeEditor;
            float2 node_8564 = (i.uv0+node_6131.g*float2(0.02,0.01));
            float4 _EmissiveNoise_var = tex2D(_EmissiveNoise,TRANSFORM_TEX(node_8564, _EmissiveNoise));
            float3 node_5393 = float3(1,1,1);
            float4 _ClippingMask_var = tex2D(_ClippingMask,TRANSFORM_TEX(i.uv0, _ClippingMask));
            o.Emission = ((_EmmissiveMap_var.rgb*_EmissivePower*lerp(_StartEmissiveColor.rgb,_EndEmissiveColor.rgb,_EmissiveColorSlider)*(_EmissiveNoise_var.rgb*1.0))+(_EndEmissiveColor.rgb*(1.0 - lerp(node_5393,float3(_ClippingMask_var.b,_ClippingMask_var.b,_ClippingMask_var.b),_ClippingSlider))));
            
            float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
            float3 diffColor = (_Diffuse_var.rgb*_DiffuseColor.rgb);
            o.Albedo = diffColor;
            
            return UnityMetaFragment( o );
        }
        ENDCG
    }
}
FallBack "Diffuse"
CustomEditor "ShaderForgeMaterialInspector"
}
