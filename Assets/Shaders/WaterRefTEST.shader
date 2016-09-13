// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:7206,x:32719,y:32712,varname:node_7206,prsc:2|diff-2675-RGB,normal-2188-RGB,emission-4017-OUT;n:type:ShaderForge.SFN_Tex2d,id:2675,x:32721,y:32528,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_2675,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:65f91997f7060f747a07bc75a804e6c8,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3242,x:32053,y:32651,varname:node_3242,prsc:2|A-3378-RGB,B-8366-RGB,C-3165-RGB;n:type:ShaderForge.SFN_Multiply,id:3413,x:32053,y:32781,varname:node_3413,prsc:2|A-3242-OUT,B-3730-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3730,x:32053,y:32921,ptovrint:False,ptlb:Emissive Power,ptin:_EmissivePower,varname:node_3730,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Panner,id:1480,x:31602,y:32712,varname:node_1480,prsc:2,spu:0.01,spv:0.02|UVIN-1176-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1176,x:31124,y:32860,varname:node_1176,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:8366,x:31767,y:32712,varname:node_8366,prsc:2,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False|UVIN-1480-UVOUT,TEX-7070-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7070,x:31435,y:32888,ptovrint:False,ptlb:WaterRef,ptin:_WaterRef,varname:node_7070,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Panner,id:5758,x:31602,y:32854,varname:node_5758,prsc:2,spu:-0.05,spv:-0.03|UVIN-1176-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3165,x:31767,y:32854,varname:node_3165,prsc:2,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False|UVIN-5758-UVOUT,TEX-7070-TEX;n:type:ShaderForge.SFN_Tex2d,id:3846,x:31602,y:33053,ptovrint:False,ptlb:Water Noise,ptin:_WaterNoise,varname:node_3846,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-2558-UVOUT;n:type:ShaderForge.SFN_Multiply,id:8509,x:32307,y:32910,varname:node_8509,prsc:2|A-3413-OUT,B-5037-OUT;n:type:ShaderForge.SFN_Multiply,id:5037,x:31866,y:33092,varname:node_5037,prsc:2|A-3846-RGB,B-6648-OUT;n:type:ShaderForge.SFN_Vector1,id:6648,x:31866,y:33220,varname:node_6648,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Panner,id:2558,x:31435,y:33053,varname:node_2558,prsc:2,spu:-0.05,spv:0.05|UVIN-1176-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:2188,x:32321,y:32510,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_2188,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a7641aa365ccae0418ec118a2fd4db99,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:296,x:32307,y:33068,ptovrint:False,ptlb:Height,ptin:_Height,varname:node_296,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6df4b6a414f2c3744bd58c9707ec8c8a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:4017,x:32510,y:32910,varname:node_4017,prsc:2|A-3343-OUT,B-8509-OUT,T-296-RGB;n:type:ShaderForge.SFN_Vector1,id:3343,x:32318,y:32851,varname:node_3343,prsc:2,v1:0;n:type:ShaderForge.SFN_Color,id:3378,x:31767,y:32561,ptovrint:False,ptlb:RefColor,ptin:_RefColor,varname:node_3378,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.6274509,c3:1,c4:1;proporder:2675-2188-3730-7070-3378-3846-296;pass:END;sub:END;*/

Shader "Custom/WaterRefTEST" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Normal ("Normal", 2D) = "bump" {}
        _EmissivePower ("Emissive Power", Float ) = 0.2
        _WaterRef ("WaterRef", 2D) = "white" {}
        _RefColor ("RefColor", Color) = (0,0.6274509,1,1)
        _WaterNoise ("Water Noise", 2D) = "white" {}
        _Height ("Height", 2D) = "white" {}
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
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _EmissivePower;
            uniform sampler2D _WaterRef; uniform float4 _WaterRef_ST;
            uniform sampler2D _WaterNoise; uniform float4 _WaterNoise_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _Height; uniform float4 _Height_ST;
            uniform float4 _RefColor;
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
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
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
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = _Diffuse_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_3343 = 0.0;
                float4 node_7076 = _Time + _TimeEditor;
                float2 node_1480 = (i.uv0+node_7076.g*float2(0.01,0.02));
                float4 node_8366 = tex2D(_WaterRef,TRANSFORM_TEX(node_1480, _WaterRef));
                float2 node_5758 = (i.uv0+node_7076.g*float2(-0.05,-0.03));
                float4 node_3165 = tex2D(_WaterRef,TRANSFORM_TEX(node_5758, _WaterRef));
                float2 node_2558 = (i.uv0+node_7076.g*float2(-0.05,0.05));
                float4 _WaterNoise_var = tex2D(_WaterNoise,TRANSFORM_TEX(node_2558, _WaterNoise));
                float4 _Height_var = tex2D(_Height,TRANSFORM_TEX(i.uv0, _Height));
                float3 emissive = lerp(float3(node_3343,node_3343,node_3343),(((_RefColor.rgb*node_8366.rgb*node_3165.rgb)*_EmissivePower)*(_WaterNoise_var.rgb*1.5)),_Height_var.rgb);
/// Final Color:
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
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _EmissivePower;
            uniform sampler2D _WaterRef; uniform float4 _WaterRef_ST;
            uniform sampler2D _WaterNoise; uniform float4 _WaterNoise_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _Height; uniform float4 _Height_ST;
            uniform float4 _RefColor;
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
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
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
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = _Diffuse_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
