// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:False,mssp:True,bkdf:True,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:8179,x:32903,y:32715,varname:node_8179,prsc:2|diff-6463-OUT,spec-145-OUT,normal-6920-RGB,emission-8797-OUT,transm-1054-OUT,lwrap-777-OUT,amdfl-3265-RGB,difocc-1610-B;n:type:ShaderForge.SFN_Tex2d,id:4924,x:32317,y:32379,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_4924,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9702,x:32617,y:32278,varname:node_9702,prsc:2|A-3971-RGB,B-4924-RGB;n:type:ShaderForge.SFN_Color,id:3971,x:32617,y:32096,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,varname:node_3971,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2205882,c2:0.08671398,c3:0,c4:1;n:type:ShaderForge.SFN_Add,id:6463,x:32617,y:32459,varname:node_6463,prsc:2|A-9702-OUT,B-4924-RGB;n:type:ShaderForge.SFN_Tex2d,id:6920,x:32917,y:32459,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_6920,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_ViewVector,id:1607,x:30940,y:32940,varname:node_1607,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:8826,x:30940,y:32789,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:8159,x:31194,y:32789,varname:node_8159,prsc:2,dt:0|A-8826-OUT,B-1607-OUT;n:type:ShaderForge.SFN_OneMinus,id:5430,x:31194,y:32951,varname:node_5430,prsc:2|IN-8159-OUT;n:type:ShaderForge.SFN_Multiply,id:6363,x:31657,y:33180,varname:node_6363,prsc:2|A-5430-OUT,B-6436-OUT,C-5430-OUT,D-1645-RGB,E-907-OUT;n:type:ShaderForge.SFN_Vector1,id:6436,x:31606,y:33058,varname:node_6436,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Color,id:1645,x:31203,y:33217,ptovrint:False,ptlb:Emissive Rim Color,ptin:_EmissiveRimColor,varname:node_1645,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9152129,c3:0.4411765,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:907,x:31203,y:33377,ptovrint:False,ptlb:Emissive Rim Power,ptin:_EmissiveRimPower,varname:node_907,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:7897,x:31512,y:33392,ptovrint:False,ptlb:Emissive Map,ptin:_EmissiveMap,varname:node_7897,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:5269,x:31512,y:33577,ptovrint:False,ptlb:Emissive Map Color,ptin:_EmissiveMapColor,varname:node_5269,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.7241379,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:9150,x:31979,y:33256,varname:node_9150,prsc:2|A-7897-RGB,B-5269-RGB,C-1919-OUT,D-6629-RGB;n:type:ShaderForge.SFN_Add,id:8797,x:31979,y:33073,varname:node_8797,prsc:2|A-6363-OUT,B-9150-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1919,x:31979,y:33404,ptovrint:False,ptlb:Emissive Map Power,ptin:_EmissiveMapPower,varname:node_1919,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:777,x:32540,y:33100,varname:node_777,prsc:2|A-1194-RGB,B-3818-RGB;n:type:ShaderForge.SFN_Tex2d,id:1194,x:32239,y:33141,ptovrint:False,ptlb:Skin Mask,ptin:_SkinMask,varname:node_1194,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Color,id:3818,x:32252,y:33327,ptovrint:False,ptlb:Skin Mask Channel,ptin:_SkinMaskChannel,varname:node_3818,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:6386,x:31573,y:32426,ptovrint:False,ptlb:Specular Power,ptin:_SpecularPower,varname:node_6386,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:145,x:32043,y:32509,varname:node_145,prsc:2|A-7586-RGB,B-6386-OUT;n:type:ShaderForge.SFN_Tex2d,id:7586,x:32043,y:32306,ptovrint:False,ptlb:Specular Mask,ptin:_SpecularMask,varname:node_7586,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8242,x:31107,y:32500,ptovrint:False,ptlb:Shine Through Mask,ptin:_ShineThroughMask,varname:node_8242,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1054,x:31374,y:32601,varname:node_1054,prsc:2|A-8242-RGB,B-3078-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3078,x:31107,y:32688,ptovrint:False,ptlb:Shine Through Power,ptin:_ShineThroughPower,varname:node_3078,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:1610,x:32205,y:32849,ptovrint:False,ptlb:AO,ptin:_AO,varname:node_1610,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6629,x:31512,y:33748,ptovrint:False,ptlb:Emissive Filter,ptin:_EmissiveFilter,varname:node_6629,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7408-UVOUT;n:type:ShaderForge.SFN_Panner,id:7408,x:31252,y:33741,varname:node_7408,prsc:2,spu:0.05,spv:0.05|UVIN-3309-UVOUT;n:type:ShaderForge.SFN_Color,id:3265,x:32420,y:32740,ptovrint:False,ptlb:Ambient,ptin:_Ambient,varname:node_3265,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_TexCoord,id:3309,x:31061,y:33741,varname:node_3309,prsc:2,uv:0;proporder:4924-3971-6920-1610-7586-6386-7897-5269-6629-1919-1645-907-1194-3818-8242-3078-3265;pass:END;sub:END;*/

Shader "Characters/TamarrionShader" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _DiffuseColor ("Diffuse Color", Color) = (0.2205882,0.08671398,0,1)
        _Normal ("Normal", 2D) = "bump" {}
        _AO ("AO", 2D) = "white" {}
        _SpecularMask ("Specular Mask", 2D) = "white" {}
        _SpecularPower ("Specular Power", Range(0, 1)) = 0
        _EmissiveMap ("Emissive Map", 2D) = "white" {}
        _EmissiveMapColor ("Emissive Map Color", Color) = (1,0.7241379,0,1)
        _EmissiveFilter ("Emissive Filter", 2D) = "white" {}
        _EmissiveMapPower ("Emissive Map Power", Float ) = 0
        _EmissiveRimColor ("Emissive Rim Color", Color) = (1,0.9152129,0.4411765,1)
        _EmissiveRimPower ("Emissive Rim Power", Float ) = 0
        _SkinMask ("Skin Mask", 2D) = "black" {}
        _SkinMaskChannel ("Skin Mask Channel", Color) = (1,0,0,1)
        _ShineThroughMask ("Shine Through Mask", 2D) = "white" {}
        _ShineThroughPower ("Shine Through Power", Float ) = 0
        _Ambient ("Ambient", Color) = (1,1,1,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            uniform float4 _DiffuseColor;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _EmissiveRimColor;
            uniform float _EmissiveRimPower;
            uniform sampler2D _EmissiveMap; uniform float4 _EmissiveMap_ST;
            uniform float4 _EmissiveMapColor;
            uniform float _EmissiveMapPower;
            uniform sampler2D _SkinMask; uniform float4 _SkinMask_ST;
            uniform float4 _SkinMaskChannel;
            uniform float _SpecularPower;
            uniform sampler2D _SpecularMask; uniform float4 _SpecularMask_ST;
            uniform sampler2D _ShineThroughMask; uniform float4 _ShineThroughMask_ST;
            uniform float _ShineThroughPower;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            uniform sampler2D _EmissiveFilter; uniform float4 _EmissiveFilter_ST;
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
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
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
                float4 _SkinMask_var = tex2D(_SkinMask,TRANSFORM_TEX(i.uv0, _SkinMask));
                float3 w = (_SkinMask_var.rgb*_SkinMaskChannel.rgb)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float4 _ShineThroughMask_var = tex2D(_ShineThroughMask,TRANSFORM_TEX(i.uv0, _ShineThroughMask));
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * (_ShineThroughMask_var.rgb*_ShineThroughPower);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += _Ambient.rgb; // Diffuse Ambient Light
                indirectDiffuse += gi.indirect.diffuse;
                float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
                indirectDiffuse *= _AO_var.b; // Diffuse AO
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = ((_DiffuseColor.rgb*_Diffuse_var.rgb)+_Diffuse_var.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_5430 = (1.0 - dot(i.normalDir,viewDirection));
                float4 _EmissiveMap_var = tex2D(_EmissiveMap,TRANSFORM_TEX(i.uv0, _EmissiveMap));
                float4 node_6854 = _Time + _TimeEditor;
                float2 node_7408 = (i.uv0+node_6854.g*float2(0.05,0.05));
                float4 _EmissiveFilter_var = tex2D(_EmissiveFilter,TRANSFORM_TEX(node_7408, _EmissiveFilter));
                float3 emissive = ((node_5430*0.5*node_5430*_EmissiveRimColor.rgb*_EmissiveRimPower)+(_EmissiveMap_var.rgb*_EmissiveMapColor.rgb*_EmissiveMapPower*_EmissiveFilter_var.rgb));
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
            uniform float4 _DiffuseColor;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _EmissiveRimColor;
            uniform float _EmissiveRimPower;
            uniform sampler2D _EmissiveMap; uniform float4 _EmissiveMap_ST;
            uniform float4 _EmissiveMapColor;
            uniform float _EmissiveMapPower;
            uniform sampler2D _SkinMask; uniform float4 _SkinMask_ST;
            uniform float4 _SkinMaskChannel;
            uniform float _SpecularPower;
            uniform sampler2D _SpecularMask; uniform float4 _SpecularMask_ST;
            uniform sampler2D _ShineThroughMask; uniform float4 _ShineThroughMask_ST;
            uniform float _ShineThroughPower;
            uniform sampler2D _EmissiveFilter; uniform float4 _EmissiveFilter_ST;
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
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
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
                float4 _SkinMask_var = tex2D(_SkinMask,TRANSFORM_TEX(i.uv0, _SkinMask));
                float3 w = (_SkinMask_var.rgb*_SkinMaskChannel.rgb)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float4 _ShineThroughMask_var = tex2D(_ShineThroughMask,TRANSFORM_TEX(i.uv0, _ShineThroughMask));
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * (_ShineThroughMask_var.rgb*_ShineThroughPower);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = ((_DiffuseColor.rgb*_Diffuse_var.rgb)+_Diffuse_var.rgb);
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
            uniform float4 _EmissiveRimColor;
            uniform float _EmissiveRimPower;
            uniform sampler2D _EmissiveMap; uniform float4 _EmissiveMap_ST;
            uniform float4 _EmissiveMapColor;
            uniform float _EmissiveMapPower;
            uniform float _SpecularPower;
            uniform sampler2D _SpecularMask; uniform float4 _SpecularMask_ST;
            uniform sampler2D _EmissiveFilter; uniform float4 _EmissiveFilter_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
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
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float node_5430 = (1.0 - dot(i.normalDir,viewDirection));
                float4 _EmissiveMap_var = tex2D(_EmissiveMap,TRANSFORM_TEX(i.uv0, _EmissiveMap));
                float4 node_1961 = _Time + _TimeEditor;
                float2 node_7408 = (i.uv0+node_1961.g*float2(0.05,0.05));
                float4 _EmissiveFilter_var = tex2D(_EmissiveFilter,TRANSFORM_TEX(node_7408, _EmissiveFilter));
                o.Emission = ((node_5430*0.5*node_5430*_EmissiveRimColor.rgb*_EmissiveRimPower)+(_EmissiveMap_var.rgb*_EmissiveMapColor.rgb*_EmissiveMapPower*_EmissiveFilter_var.rgb));
                
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffColor = ((_DiffuseColor.rgb*_Diffuse_var.rgb)+_Diffuse_var.rgb);
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
