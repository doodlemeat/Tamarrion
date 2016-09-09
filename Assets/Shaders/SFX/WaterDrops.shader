// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32710,y:32756,varname:node_4013,prsc:2|diff-9432-OUT,normal-7428-OUT,alpha-3209-OUT,refract-7137-OUT;n:type:ShaderForge.SFN_Tex2d,id:2890,x:31273,y:33001,varname:node_2890,prsc:2,tex:dd699b69b08d55b4b91e967cf97a7db8,ntxv:3,isnm:True|UVIN-5976-UVOUT,TEX-6937-TEX;n:type:ShaderForge.SFN_Append,id:3831,x:31490,y:33022,varname:node_3831,prsc:2|A-2890-R,B-2890-G;n:type:ShaderForge.SFN_Panner,id:5976,x:31083,y:33001,varname:node_5976,prsc:2,spu:0,spv:-0.2|UVIN-1610-OUT;n:type:ShaderForge.SFN_Tex2d,id:7696,x:31537,y:33177,ptovrint:False,ptlb:WindowRef,ptin:_WindowRef,varname:node_7696,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:33d3d546dcc7c4e4bb3c947dd89185c8,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Append,id:3325,x:31754,y:33194,varname:node_3325,prsc:2|A-7696-R,B-7696-G;n:type:ShaderForge.SFN_Add,id:7137,x:32476,y:33057,varname:node_7137,prsc:2|A-9321-OUT,B-592-OUT;n:type:ShaderForge.SFN_Tex2d,id:3481,x:31979,y:32991,ptovrint:False,ptlb:WindowMask,ptin:_WindowMask,varname:node_3481,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:802312f03eda27b408d3ad3d0d696cf3,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9321,x:32266,y:32888,varname:node_9321,prsc:2|A-7665-OUT,B-3481-B;n:type:ShaderForge.SFN_Add,id:2896,x:31674,y:32844,varname:node_2896,prsc:2|A-8825-OUT,B-3831-OUT;n:type:ShaderForge.SFN_Append,id:8825,x:31490,y:32823,varname:node_8825,prsc:2|A-4057-R,B-4057-G;n:type:ShaderForge.SFN_Tex2d,id:4057,x:31273,y:32796,varname:node_4057,prsc:2,tex:dd699b69b08d55b4b91e967cf97a7db8,ntxv:3,isnm:True|UVIN-4348-UVOUT,TEX-6937-TEX;n:type:ShaderForge.SFN_Panner,id:4348,x:31083,y:32796,varname:node_4348,prsc:2,spu:0,spv:-0.1|UVIN-1609-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1609,x:30850,y:32796,varname:node_1609,prsc:2,uv:0;n:type:ShaderForge.SFN_OneMinus,id:9106,x:32254,y:33020,varname:node_9106,prsc:2|IN-3481-B;n:type:ShaderForge.SFN_Multiply,id:592,x:32254,y:33147,varname:node_592,prsc:2|A-3481-B,B-1136-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:6937,x:30582,y:32923,ptovrint:False,ptlb:RainRef,ptin:_RainRef,varname:node_6937,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:dd699b69b08d55b4b91e967cf97a7db8,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Color,id:8426,x:32038,y:32638,ptovrint:False,ptlb:ColorGlass,ptin:_ColorGlass,varname:node_8426,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3452639,c2:0.3872226,c3:0.4558824,c4:1;n:type:ShaderForge.SFN_Multiply,id:7958,x:32339,y:32730,varname:node_7958,prsc:2|A-8426-RGB,B-3481-RGB;n:type:ShaderForge.SFN_Color,id:2133,x:32038,y:32466,ptovrint:False,ptlb:ColorFrame,ptin:_ColorFrame,varname:node_2133,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:1240,x:32339,y:32590,varname:node_1240,prsc:2|A-2133-RGB,B-9106-OUT;n:type:ShaderForge.SFN_Add,id:9432,x:32540,y:32653,varname:node_9432,prsc:2|A-1240-OUT,B-7958-OUT;n:type:ShaderForge.SFN_Add,id:4365,x:31323,y:32408,varname:node_4365,prsc:2|A-4057-RGB,B-2890-RGB;n:type:ShaderForge.SFN_Multiply,id:7412,x:31719,y:32534,varname:node_7412,prsc:2|A-3406-OUT,B-3481-RGB;n:type:ShaderForge.SFN_Add,id:7428,x:31901,y:32664,varname:node_7428,prsc:2|A-7412-OUT,B-7696-RGB;n:type:ShaderForge.SFN_Vector1,id:7787,x:31674,y:33010,varname:node_7787,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Multiply,id:7665,x:31919,y:32844,varname:node_7665,prsc:2|A-2896-OUT,B-7787-OUT;n:type:ShaderForge.SFN_Multiply,id:1136,x:31979,y:33171,varname:node_1136,prsc:2|A-7787-OUT,B-3325-OUT;n:type:ShaderForge.SFN_Vector4Property,id:3007,x:30676,y:33123,ptovrint:False,ptlb:SizeCords,ptin:_SizeCords,varname:node_3007,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5,v2:0.5,v3:1,v4:0.5;n:type:ShaderForge.SFN_Append,id:810,x:30876,y:33144,varname:node_810,prsc:2|A-3007-X,B-3007-Y;n:type:ShaderForge.SFN_Multiply,id:1610,x:30876,y:33001,varname:node_1610,prsc:2|A-1609-UVOUT,B-810-OUT;n:type:ShaderForge.SFN_Vector1,id:3691,x:32452,y:33397,varname:node_3691,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Multiply,id:3406,x:31719,y:32387,varname:node_3406,prsc:2|A-7957-OUT,B-4365-OUT;n:type:ShaderForge.SFN_Vector1,id:7957,x:31323,y:32333,varname:node_7957,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Power,id:3209,x:32509,y:33236,varname:node_3209,prsc:2|VAL-9106-OUT,EXP-3691-OUT;proporder:7696-3481-6937-8426-2133-3007;pass:END;sub:END;*/

Shader "Custom/WaterDrops" {
    Properties {
        _WindowRef ("WindowRef", 2D) = "bump" {}
        _WindowMask ("WindowMask", 2D) = "white" {}
        _RainRef ("RainRef", 2D) = "bump" {}
        _ColorGlass ("ColorGlass", Color) = (0.3452639,0.3872226,0.4558824,1)
        _ColorFrame ("ColorFrame", Color) = (0.5,0.5,0.5,1)
        _SizeCords ("SizeCords", Vector) = (0.5,0.5,1,0.5)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
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
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _WindowRef; uniform float4 _WindowRef_ST;
            uniform sampler2D _WindowMask; uniform float4 _WindowMask_ST;
            uniform sampler2D _RainRef; uniform float4 _RainRef_ST;
            uniform float4 _ColorGlass;
            uniform float4 _ColorFrame;
            uniform float4 _SizeCords;
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
                float4 screenPos : TEXCOORD5;
                UNITY_FOG_COORDS(6)
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
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_8833 = _Time + _TimeEditor;
                float2 node_4348 = (i.uv0+node_8833.g*float2(0,-0.1));
                float3 node_4057 = UnpackNormal(tex2D(_RainRef,TRANSFORM_TEX(node_4348, _RainRef)));
                float2 node_5976 = ((i.uv0*float2(_SizeCords.r,_SizeCords.g))+node_8833.g*float2(0,-0.2));
                float3 node_2890 = UnpackNormal(tex2D(_RainRef,TRANSFORM_TEX(node_5976, _RainRef)));
                float4 _WindowMask_var = tex2D(_WindowMask,TRANSFORM_TEX(i.uv0, _WindowMask));
                float3 _WindowRef_var = UnpackNormal(tex2D(_WindowRef,TRANSFORM_TEX(i.uv0, _WindowRef)));
                float3 normalLocal = (((0.3*(node_4057.rgb+node_2890.rgb))*_WindowMask_var.rgb)+_WindowRef_var.rgb);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float node_7787 = 0.05;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + ((((float2(node_4057.r,node_4057.g)+float2(node_2890.r,node_2890.g))*node_7787)*_WindowMask_var.b)+(_WindowMask_var.b*(node_7787*float2(_WindowRef_var.r,_WindowRef_var.g))));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_9106 = (1.0 - _WindowMask_var.b);
                float3 diffuseColor = ((_ColorFrame.rgb*node_9106)+(_ColorGlass.rgb*_WindowMask_var.rgb));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float node_3691 = 0.3;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,pow(node_9106,node_3691)),1);
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _WindowRef; uniform float4 _WindowRef_ST;
            uniform sampler2D _WindowMask; uniform float4 _WindowMask_ST;
            uniform sampler2D _RainRef; uniform float4 _RainRef_ST;
            uniform float4 _ColorGlass;
            uniform float4 _ColorFrame;
            uniform float4 _SizeCords;
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
                float4 screenPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
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
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_4128 = _Time + _TimeEditor;
                float2 node_4348 = (i.uv0+node_4128.g*float2(0,-0.1));
                float3 node_4057 = UnpackNormal(tex2D(_RainRef,TRANSFORM_TEX(node_4348, _RainRef)));
                float2 node_5976 = ((i.uv0*float2(_SizeCords.r,_SizeCords.g))+node_4128.g*float2(0,-0.2));
                float3 node_2890 = UnpackNormal(tex2D(_RainRef,TRANSFORM_TEX(node_5976, _RainRef)));
                float4 _WindowMask_var = tex2D(_WindowMask,TRANSFORM_TEX(i.uv0, _WindowMask));
                float3 _WindowRef_var = UnpackNormal(tex2D(_WindowRef,TRANSFORM_TEX(i.uv0, _WindowRef)));
                float3 normalLocal = (((0.3*(node_4057.rgb+node_2890.rgb))*_WindowMask_var.rgb)+_WindowRef_var.rgb);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float node_7787 = 0.05;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + ((((float2(node_4057.r,node_4057.g)+float2(node_2890.r,node_2890.g))*node_7787)*_WindowMask_var.b)+(_WindowMask_var.b*(node_7787*float2(_WindowRef_var.r,_WindowRef_var.g))));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float node_9106 = (1.0 - _WindowMask_var.b);
                float3 diffuseColor = ((_ColorFrame.rgb*node_9106)+(_ColorGlass.rgb*_WindowMask_var.rgb));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float node_3691 = 0.3;
                fixed4 finalRGBA = fixed4(finalColor * pow(node_9106,node_3691),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
