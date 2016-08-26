// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:0,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4825,x:32719,y:32712,varname:node_4825,prsc:2|diff-3073-OUT,spec-5216-OUT,normal-8512-RGB,emission-8197-OUT,transm-9535-OUT,difocc-5714-B,clip-9265-B;n:type:ShaderForge.SFN_Tex2d,id:3373,x:32871,y:32365,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_3373,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8512,x:32284,y:32387,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_8512,prsc:2,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:5714,x:31574,y:32783,ptovrint:False,ptlb:AO,ptin:_AO,varname:node_5714,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9722,x:31388,y:32410,ptovrint:False,ptlb:Shine Through Mask,ptin:_ShineThroughMask,varname:node_9722,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9535,x:31684,y:32605,varname:node_9535,prsc:2|A-9722-RGB,B-5705-OUT,C-576-RGB;n:type:ShaderForge.SFN_ValueProperty,id:5705,x:31388,y:32587,ptovrint:False,ptlb:Shine Through Power,ptin:_ShineThroughPower,varname:node_5705,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_Color,id:576,x:31388,y:32662,ptovrint:False,ptlb:Shine Through Color,ptin:_ShineThroughColor,varname:node_576,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:3073,x:32871,y:32541,varname:node_3073,prsc:2|A-3373-RGB,B-3343-RGB;n:type:ShaderForge.SFN_Color,id:3343,x:32718,y:32541,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,varname:node_3343,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:8197,x:31923,y:32428,varname:node_8197,prsc:2|A-5791-RGB,B-1845-OUT,C-5147-RGB;n:type:ShaderForge.SFN_Tex2d,id:5791,x:31689,y:32355,ptovrint:False,ptlb:Emmissive Map,ptin:_EmmissiveMap,varname:node_5791,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:1845,x:31689,y:32530,ptovrint:False,ptlb:Emissive Power,ptin:_EmissivePower,varname:node_1845,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:118,x:32054,y:32013,ptovrint:False,ptlb:Specular Mask,ptin:_SpecularMask,varname:node_118,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5216,x:32374,y:32142,varname:node_5216,prsc:2|A-118-RGB,B-5357-OUT;n:type:ShaderForge.SFN_Slider,id:5357,x:31923,y:32260,ptovrint:False,ptlb:Specular Power,ptin:_SpecularPower,varname:node_5357,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:9265,x:32162,y:32967,ptovrint:False,ptlb:Opacity Clip,ptin:_OpacityClip,varname:node_9265,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:5147,x:31689,y:32194,ptovrint:False,ptlb:Emissive Color,ptin:_EmissiveColor,varname:node_5147,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;proporder:3373-3343-8512-118-5357-5714-5791-5147-1845-9265-9722-576-5705;pass:END;sub:END;*/

Shader "Maans/Nviro" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _DiffuseColor ("Diffuse Color", Color) = (1,1,1,1)
        _Normal ("Normal", 2D) = "bump" {}
        _SpecularMask ("Specular Mask", 2D) = "white" {}
        _SpecularPower ("Specular Power", Range(0, 1)) = 0
        _AO ("AO", 2D) = "white" {}
        _EmmissiveMap ("Emmissive Map", 2D) = "white" {}
        _EmissiveColor ("Emissive Color", Color) = (1,1,1,1)
        _EmissivePower ("Emissive Power", Float ) = 0
        _OpacityClip ("Opacity Clip", 2D) = "white" {}
        _ShineThroughMask ("Shine Through Mask", 2D) = "white" {}
        _ShineThroughColor ("Shine Through Color", Color) = (1,1,1,1)
        _ShineThroughPower ("Shine Through Power", Float ) = 0
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            uniform sampler2D _ShineThroughMask; uniform float4 _ShineThroughMask_ST;
            uniform float _ShineThroughPower;
            uniform float4 _ShineThroughColor;
            uniform float4 _DiffuseColor;
            uniform sampler2D _EmmissiveMap; uniform float4 _EmmissiveMap_ST;
            uniform float _EmissivePower;
            uniform sampler2D _SpecularMask; uniform float4 _SpecularMask_ST;
            uniform float _SpecularPower;
            uniform sampler2D _OpacityClip; uniform float4 _OpacityClip_ST;
            uniform float4 _EmissiveColor;
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
            float4 _OpacityClip_var = tex2D(_OpacityClip,TRANSFORM_TEX(i.uv0, _OpacityClip));
            clip(_OpacityClip_var.b - 0.5);
            float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
            float3 lightColor = _LightColor0.rgb;
            float3 halfDirection = normalize(viewDirection+lightDirection);
// Lighting:
            float attenuation = LIGHT_ATTENUATION(i);
            float3 attenColor = attenuation * _LightColor0.xyz;
///// Gloss:
            float gloss = 0.5;
            float specPow = exp2( gloss * 10.0+1.0);
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
            UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
            lightDirection = gi.light.dir;
            lightColor = gi.light.color;
// Specular:
            float NdotL = max(0, dot( normalDirection, lightDirection ));
            float4 _SpecularMask_var = tex2D(_SpecularMask,TRANSFORM_TEX(i.uv0, _SpecularMask));
            float3 specularColor = (_SpecularMask_var.rgb*_SpecularPower);
            float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
            float3 specular = directSpecular;
/// Diffuse:
            NdotL = dot( normalDirection, lightDirection );
            float3 forwardLight = max(0.0, NdotL );
            float4 _ShineThroughMask_var = tex2D(_ShineThroughMask,TRANSFORM_TEX(i.uv0, _ShineThroughMask));
            float3 backLight = max(0.0, -NdotL ) * (_ShineThroughMask_var.rgb*_ShineThroughPower*_ShineThroughColor.rgb);
            NdotL = max(0.0,dot( normalDirection, lightDirection ));
            float3 directDiffuse = (forwardLight+backLight) * attenColor;
            float3 indirectDiffuse = float3(0,0,0);
            indirectDiffuse += gi.indirect.diffuse;
            float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
            indirectDiffuse *= _AO_var.b; // Diffuse AO
            float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
            float3 diffuseColor = (_Diffuse_var.rgb*_DiffuseColor.rgb);
            float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
// Emissive:
            float4 _EmmissiveMap_var = tex2D(_EmmissiveMap,TRANSFORM_TEX(i.uv0, _EmmissiveMap));
            float3 emissive = (_EmmissiveMap_var.rgb*_EmissivePower*_EmissiveColor.rgb);
// Final Color:
            float3 finalColor = diffuse + specular + emissive;
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
        uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
        uniform sampler2D _Normal; uniform float4 _Normal_ST;
        uniform sampler2D _ShineThroughMask; uniform float4 _ShineThroughMask_ST;
        uniform float _ShineThroughPower;
        uniform float4 _ShineThroughColor;
        uniform float4 _DiffuseColor;
        uniform sampler2D _EmmissiveMap; uniform float4 _EmmissiveMap_ST;
        uniform float _EmissivePower;
        uniform sampler2D _SpecularMask; uniform float4 _SpecularMask_ST;
        uniform float _SpecularPower;
        uniform sampler2D _OpacityClip; uniform float4 _OpacityClip_ST;
        uniform float4 _EmissiveColor;
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
            float4 _OpacityClip_var = tex2D(_OpacityClip,TRANSFORM_TEX(i.uv0, _OpacityClip));
            clip(_OpacityClip_var.b - 0.5);
            float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
            float3 lightColor = _LightColor0.rgb;
            float3 halfDirection = normalize(viewDirection+lightDirection);
// Lighting:
            float attenuation = LIGHT_ATTENUATION(i);
            float3 attenColor = attenuation * _LightColor0.xyz;
///// Gloss:
            float gloss = 0.5;
            float specPow = exp2( gloss * 10.0+1.0);
// Specular:
            float NdotL = max(0, dot( normalDirection, lightDirection ));
            float4 _SpecularMask_var = tex2D(_SpecularMask,TRANSFORM_TEX(i.uv0, _SpecularMask));
            float3 specularColor = (_SpecularMask_var.rgb*_SpecularPower);
            float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
            float3 specular = directSpecular;
/// Diffuse:
            NdotL = dot( normalDirection, lightDirection );
            float3 forwardLight = max(0.0, NdotL );
            float4 _ShineThroughMask_var = tex2D(_ShineThroughMask,TRANSFORM_TEX(i.uv0, _ShineThroughMask));
            float3 backLight = max(0.0, -NdotL ) * (_ShineThroughMask_var.rgb*_ShineThroughPower*_ShineThroughColor.rgb);
            NdotL = max(0.0,dot( normalDirection, lightDirection ));
            float3 directDiffuse = (forwardLight+backLight) * attenColor;
            float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
            float3 diffuseColor = (_Diffuse_var.rgb*_DiffuseColor.rgb);
            float3 diffuse = directDiffuse * diffuseColor;
// Final Color:
            float3 finalColor = diffuse + specular;
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
        uniform sampler2D _OpacityClip; uniform float4 _OpacityClip_ST;
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
            float4 _OpacityClip_var = tex2D(_OpacityClip,TRANSFORM_TEX(i.uv0, _OpacityClip));
            clip(_OpacityClip_var.b - 0.5);
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
        uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
        uniform float4 _DiffuseColor;
        uniform sampler2D _EmmissiveMap; uniform float4 _EmmissiveMap_ST;
        uniform float _EmissivePower;
        uniform sampler2D _SpecularMask; uniform float4 _SpecularMask_ST;
        uniform float _SpecularPower;
        uniform float4 _EmissiveColor;
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
            o.Emission = (_EmmissiveMap_var.rgb*_EmissivePower*_EmissiveColor.rgb);
            
            float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
            float3 diffColor = (_Diffuse_var.rgb*_DiffuseColor.rgb);
            float4 _SpecularMask_var = tex2D(_SpecularMask,TRANSFORM_TEX(i.uv0, _SpecularMask));
            float3 specColor = (_SpecularMask_var.rgb*_SpecularPower);
            o.Albedo = diffColor + specColor * 0.125; // No gloss connected. Assume it's 0.5
            
            return UnityMetaFragment( o );
        }
        ENDCG
    }
}
FallBack "Diffuse"
CustomEditor "ShaderForgeMaterialInspector"
}
