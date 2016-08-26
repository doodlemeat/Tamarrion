// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:783,x:32719,y:32712,varname:node_783,prsc:2|diff-6940-OUT,spec-2728-OUT,normal-9133-RGB,emission-2346-OUT,transm-7635-OUT,amdfl-1387-RGB,difocc-7717-B,clip-927-A;n:type:ShaderForge.SFN_Color,id:1079,x:32384,y:32247,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,varname:node_1079,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:927,x:32384,y:32412,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6940,x:32713,y:32377,varname:node_6940,prsc:2|A-1079-RGB,B-927-RGB;n:type:ShaderForge.SFN_Tex2d,id:9133,x:31883,y:32620,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_9133,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:7717,x:32302,y:33235,ptovrint:False,ptlb:AO,ptin:_AO,varname:node_7717,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7635,x:31397,y:33239,varname:node_7635,prsc:2|A-2140-RGB,B-2227-OUT,C-1891-RGB;n:type:ShaderForge.SFN_Tex2d,id:2140,x:31094,y:33069,ptovrint:False,ptlb:Transmission Mask,ptin:_TransmissionMask,varname:node_2140,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:2227,x:31094,y:33265,ptovrint:False,ptlb:Transmission Power,ptin:_TransmissionPower,varname:node_2227,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:7784,x:31377,y:32099,ptovrint:False,ptlb:Specular Mask,ptin:_SpecularMask,varname:_SpecularMask_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:680,x:31377,y:32287,ptovrint:False,ptlb:Specular Power,ptin:_SpecularPower,varname:_SpecularPower_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:2728,x:31611,y:32184,varname:node_2728,prsc:2|A-7784-RGB,B-680-OUT;n:type:ShaderForge.SFN_Color,id:1891,x:31094,y:33347,ptovrint:False,ptlb:Transmission Color,ptin:_TransmissionColor,varname:node_1891,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Add,id:2346,x:31502,y:32791,varname:node_2346,prsc:2|A-1303-OUT,B-2021-OUT;n:type:ShaderForge.SFN_Multiply,id:2021,x:30924,y:32864,varname:node_2021,prsc:2|A-6266-RGB,B-117-OUT,C-461-RGB;n:type:ShaderForge.SFN_ValueProperty,id:117,x:30560,y:32882,ptovrint:False,ptlb:EmissiveStatic Power,ptin:_EmissiveStaticPower,varname:node_117,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Color,id:461,x:30560,y:32963,ptovrint:False,ptlb:EmissiveStatic Color,ptin:_EmissiveStaticColor,varname:node_461,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:6266,x:30560,y:32699,ptovrint:False,ptlb:EmissiveStatic Mask,ptin:_EmissiveStaticMask,varname:node_6266,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5664,x:30926,y:32451,ptovrint:False,ptlb:EmissivePan Mask,ptin:_EmissivePanMask,varname:node_5664,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1473,x:31168,y:32571,varname:node_1473,prsc:2|A-5664-RGB,B-2194-OUT,C-590-RGB;n:type:ShaderForge.SFN_Tex2d,id:249,x:30816,y:32269,ptovrint:False,ptlb:EmissivePan Texture,ptin:_EmissivePanTexture,varname:node_249,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4018-UVOUT;n:type:ShaderForge.SFN_Panner,id:4018,x:30633,y:32269,varname:node_4018,prsc:2,spu:0.05,spv:0.05|UVIN-8747-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:2194,x:30926,y:32630,ptovrint:False,ptlb:EmissivePan Power,ptin:_EmissivePanPower,varname:node_2194,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:1303,x:31439,y:32400,varname:node_1303,prsc:2|A-249-RGB,B-1473-OUT;n:type:ShaderForge.SFN_Color,id:590,x:30926,y:32712,ptovrint:False,ptlb:EmissivePan Color,ptin:_EmissivePanColor,varname:node_590,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:1387,x:31927,y:33269,ptovrint:False,ptlb:Ambient,ptin:_Ambient,varname:node_1387,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_TexCoord,id:8747,x:30460,y:32269,varname:node_8747,prsc:2,uv:0;proporder:927-1079-9133-7717-7784-680-6266-461-117-249-5664-590-2194-2140-1891-2227-1387;pass:END;sub:END;*/

Shader "Characters/NPC_2Side" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _DiffuseColor ("Diffuse Color", Color) = (1,1,1,1)
        _Normal ("Normal", 2D) = "bump" {}
        _AO ("AO", 2D) = "white" {}
        _SpecularMask ("Specular Mask", 2D) = "white" {}
        _SpecularPower ("Specular Power", Float ) = 0
        _EmissiveStaticMask ("EmissiveStatic Mask", 2D) = "white" {}
        _EmissiveStaticColor ("EmissiveStatic Color", Color) = (1,1,1,1)
        _EmissiveStaticPower ("EmissiveStatic Power", Float ) = 0
        _EmissivePanTexture ("EmissivePan Texture", 2D) = "white" {}
        _EmissivePanMask ("EmissivePan Mask", 2D) = "white" {}
        _EmissivePanColor ("EmissivePan Color", Color) = (1,1,1,1)
        _EmissivePanPower ("EmissivePan Power", Float ) = 0
        _TransmissionMask ("Transmission Mask", 2D) = "white" {}
        _TransmissionColor ("Transmission Color", Color) = (1,1,1,1)
        _TransmissionPower ("Transmission Power", Float ) = 0
        _Ambient ("Ambient", Color) = (1,1,1,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
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
            uniform float4 _DiffuseColor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            uniform sampler2D _TransmissionMask; uniform float4 _TransmissionMask_ST;
            uniform float _TransmissionPower;
            uniform sampler2D _SpecularMask; uniform float4 _SpecularMask_ST;
            uniform float _SpecularPower;
            uniform float4 _TransmissionColor;
            uniform float _EmissiveStaticPower;
            uniform float4 _EmissiveStaticColor;
            uniform sampler2D _EmissiveStaticMask; uniform float4 _EmissiveStaticMask_ST;
            uniform sampler2D _EmissivePanMask; uniform float4 _EmissivePanMask_ST;
            uniform sampler2D _EmissivePanTexture; uniform float4 _EmissivePanTexture_ST;
            uniform float _EmissivePanPower;
            uniform float4 _EmissivePanColor;
            uniform float4 _Ambient;
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
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                clip(_Diffuse_var.a - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
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
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _SpecularMask_var = tex2D(_SpecularMask,TRANSFORM_TEX(i.uv0, _SpecularMask));
                float3 specularColor = (_SpecularMask_var.rgb*_SpecularPower);
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 forwardLight = max(0.0, NdotL );
                float4 _TransmissionMask_var = tex2D(_TransmissionMask,TRANSFORM_TEX(i.uv0, _TransmissionMask));
                float3 backLight = max(0.0, -NdotL ) * (_TransmissionMask_var.rgb*_TransmissionPower*_TransmissionColor.rgb);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += _Ambient.rgb; // Diffuse Ambient Light
                indirectDiffuse += gi.indirect.diffuse;
                float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
                indirectDiffuse *= _AO_var.b; // Diffuse AO
                float3 diffuseColor = (_DiffuseColor.rgb*_Diffuse_var.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_5967 = _Time + _TimeEditor;
                float2 node_4018 = (i.uv0+node_5967.g*float2(0.05,0.05));
                float4 _EmissivePanTexture_var = tex2D(_EmissivePanTexture,TRANSFORM_TEX(node_4018, _EmissivePanTexture));
                float4 _EmissivePanMask_var = tex2D(_EmissivePanMask,TRANSFORM_TEX(i.uv0, _EmissivePanMask));
                float4 _EmissiveStaticMask_var = tex2D(_EmissiveStaticMask,TRANSFORM_TEX(i.uv0, _EmissiveStaticMask));
                float3 emissive = ((_EmissivePanTexture_var.rgb*(_EmissivePanMask_var.rgb*_EmissivePanPower*_EmissivePanColor.rgb))+(_EmissiveStaticMask_var.rgb*_EmissiveStaticPower*_EmissiveStaticColor.rgb));
/// Final Color:
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
            Cull Off
            
            
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
            uniform float4 _DiffuseColor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _TransmissionMask; uniform float4 _TransmissionMask_ST;
            uniform float _TransmissionPower;
            uniform sampler2D _SpecularMask; uniform float4 _SpecularMask_ST;
            uniform float _SpecularPower;
            uniform float4 _TransmissionColor;
            uniform float _EmissiveStaticPower;
            uniform float4 _EmissiveStaticColor;
            uniform sampler2D _EmissiveStaticMask; uniform float4 _EmissiveStaticMask_ST;
            uniform sampler2D _EmissivePanMask; uniform float4 _EmissivePanMask_ST;
            uniform sampler2D _EmissivePanTexture; uniform float4 _EmissivePanTexture_ST;
            uniform float _EmissivePanPower;
            uniform float4 _EmissivePanColor;
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
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                clip(_Diffuse_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _SpecularMask_var = tex2D(_SpecularMask,TRANSFORM_TEX(i.uv0, _SpecularMask));
                float3 specularColor = (_SpecularMask_var.rgb*_SpecularPower);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 forwardLight = max(0.0, NdotL );
                float4 _TransmissionMask_var = tex2D(_TransmissionMask,TRANSFORM_TEX(i.uv0, _TransmissionMask));
                float3 backLight = max(0.0, -NdotL ) * (_TransmissionMask_var.rgb*_TransmissionPower*_TransmissionColor.rgb);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 diffuseColor = (_DiffuseColor.rgb*_Diffuse_var.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
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
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                clip(_Diffuse_var.a - 0.5);
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
            uniform float4 _DiffuseColor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _SpecularMask; uniform float4 _SpecularMask_ST;
            uniform float _SpecularPower;
            uniform float _EmissiveStaticPower;
            uniform float4 _EmissiveStaticColor;
            uniform sampler2D _EmissiveStaticMask; uniform float4 _EmissiveStaticMask_ST;
            uniform sampler2D _EmissivePanMask; uniform float4 _EmissivePanMask_ST;
            uniform sampler2D _EmissivePanTexture; uniform float4 _EmissivePanTexture_ST;
            uniform float _EmissivePanPower;
            uniform float4 _EmissivePanColor;
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
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_1454 = _Time + _TimeEditor;
                float2 node_4018 = (i.uv0+node_1454.g*float2(0.05,0.05));
                float4 _EmissivePanTexture_var = tex2D(_EmissivePanTexture,TRANSFORM_TEX(node_4018, _EmissivePanTexture));
                float4 _EmissivePanMask_var = tex2D(_EmissivePanMask,TRANSFORM_TEX(i.uv0, _EmissivePanMask));
                float4 _EmissiveStaticMask_var = tex2D(_EmissiveStaticMask,TRANSFORM_TEX(i.uv0, _EmissiveStaticMask));
                o.Emission = ((_EmissivePanTexture_var.rgb*(_EmissivePanMask_var.rgb*_EmissivePanPower*_EmissivePanColor.rgb))+(_EmissiveStaticMask_var.rgb*_EmissiveStaticPower*_EmissiveStaticColor.rgb));
                
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffColor = (_DiffuseColor.rgb*_Diffuse_var.rgb);
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
