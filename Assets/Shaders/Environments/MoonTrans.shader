// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:783,x:32876,y:32647,varname:node_783,prsc:2|normal-8637-OUT,emission-1915-OUT,olcol-1129-RGB;n:type:ShaderForge.SFN_Color,id:8621,x:31634,y:32746,ptovrint:False,ptlb:Emissive Color,ptin:_EmissiveColor,varname:node_8028,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:9325,x:31961,y:32704,varname:node_9325,prsc:2|A-8621-RGB,B-4784-RGB;n:type:ShaderForge.SFN_Tex2d,id:4784,x:31423,y:32661,ptovrint:False,ptlb:Emissive Map,ptin:_EmissiveMap,varname:node_2586,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8941,x:32316,y:32846,varname:node_8941,prsc:2|A-9325-OUT,B-8932-OUT,C-5771-RGB;n:type:ShaderForge.SFN_ValueProperty,id:8932,x:31985,y:32942,ptovrint:False,ptlb:Emissive Power,ptin:_EmissivePower,varname:node_4803,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Tex2d,id:3307,x:32268,y:32584,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_1369,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Vector1,id:5717,x:32228,y:33317,varname:node_5717,prsc:2,v1:1;n:type:ShaderForge.SFN_Dot,id:2677,x:31750,y:33391,varname:node_2677,prsc:2,dt:0|A-8882-OUT,B-4768-OUT;n:type:ShaderForge.SFN_NormalVector,id:4768,x:31408,y:33455,prsc:2,pt:True;n:type:ShaderForge.SFN_Multiply,id:6869,x:32228,y:33185,varname:node_6869,prsc:2|A-2677-OUT,B-5717-OUT;n:type:ShaderForge.SFN_LightVector,id:8882,x:31408,y:33309,varname:node_8882,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8637,x:32516,y:32654,varname:node_8637,prsc:2|A-3307-RGB,B-8017-OUT;n:type:ShaderForge.SFN_Vector3,id:8017,x:32268,y:32741,varname:node_8017,prsc:2,v1:0.5,v2:0.5,v3:2;n:type:ShaderForge.SFN_NormalVector,id:8875,x:31296,y:33078,prsc:2,pt:False;n:type:ShaderForge.SFN_ViewVector,id:7914,x:31296,y:32944,varname:node_7914,prsc:2;n:type:ShaderForge.SFN_Dot,id:4224,x:31548,y:33022,varname:node_4224,prsc:2,dt:0|A-7914-OUT,B-8875-OUT;n:type:ShaderForge.SFN_OneMinus,id:1076,x:31720,y:33073,varname:node_1076,prsc:2|IN-4224-OUT;n:type:ShaderForge.SFN_Add,id:8398,x:32564,y:32846,varname:node_8398,prsc:2|A-8941-OUT,B-4192-OUT,C-4174-OUT;n:type:ShaderForge.SFN_Power,id:1094,x:31889,y:33071,varname:node_1094,prsc:2|VAL-1076-OUT,EXP-4342-OUT;n:type:ShaderForge.SFN_Vector1,id:4342,x:31711,y:33202,varname:node_4342,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Power,id:8954,x:31734,y:32942,varname:node_8954,prsc:2|VAL-4224-OUT,EXP-8408-OUT;n:type:ShaderForge.SFN_Vector1,id:8408,x:31498,y:32915,varname:node_8408,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:4192,x:32058,y:33052,varname:node_4192,prsc:2|A-1129-RGB,B-1094-OUT,C-8954-OUT;n:type:ShaderForge.SFN_Color,id:1129,x:31795,y:32794,ptovrint:False,ptlb:Rim Color,ptin:_RimColor,varname:node_9941,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4174,x:32316,y:33041,varname:node_4174,prsc:2|A-8941-OUT,B-6869-OUT;n:type:ShaderForge.SFN_Multiply,id:8016,x:32880,y:32442,varname:node_8016,prsc:2|A-7671-OUT,B-8398-OUT;n:type:ShaderForge.SFN_Vector1,id:7671,x:32867,y:32358,varname:node_7671,prsc:2,v1:0.7;n:type:ShaderForge.SFN_Color,id:5771,x:32516,y:32513,ptovrint:False,ptlb:Normal Color,ptin:_NormalColor,varname:node_5771,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4902,x:32516,y:32325,ptovrint:False,ptlb:Spot Map,ptin:_SpotMap,varname:node_4902,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8002,x:32719,y:32325,varname:node_8002,prsc:2|A-2370-OUT,B-4902-RGB;n:type:ShaderForge.SFN_Vector1,id:2370,x:32516,y:32233,varname:node_2370,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:6262,x:33111,y:32402,varname:node_6262,prsc:2|A-8002-OUT,B-8016-OUT;n:type:ShaderForge.SFN_Add,id:1915,x:33126,y:32224,varname:node_1915,prsc:2|A-8002-OUT,B-8016-OUT;proporder:3307-8621-4784-8932-1129-5771-4902;pass:END;sub:END;*/

Shader "Custom/MoonTrans" {
    Properties {
        _Normal ("Normal", 2D) = "bump" {}
        _EmissiveColor ("Emissive Color", Color) = (1,1,1,1)
        _EmissiveMap ("Emissive Map", 2D) = "white" {}
        _EmissivePower ("Emissive Power", Float ) = 1
        _RimColor ("Rim Color", Color) = (1,1,1,1)
        _NormalColor ("Normal Color", Color) = (0.5,0.5,0.5,1)
        _SpotMap ("Spot Map", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
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
            uniform float4 _EmissiveColor;
            uniform sampler2D _EmissiveMap; uniform float4 _EmissiveMap_ST;
            uniform float _EmissivePower;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _RimColor;
            uniform float4 _NormalColor;
            uniform sampler2D _SpotMap; uniform float4 _SpotMap_ST;
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
                float3 normalLocal = (_Normal_var.rgb*float3(0.5,0.5,2));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float4 _SpotMap_var = tex2D(_SpotMap,TRANSFORM_TEX(i.uv0, _SpotMap));
                float3 node_8002 = (0.2*_SpotMap_var.rgb);
                float4 _EmissiveMap_var = tex2D(_EmissiveMap,TRANSFORM_TEX(i.uv0, _EmissiveMap));
                float3 node_8941 = ((_EmissiveColor.rgb*_EmissiveMap_var.rgb)*_EmissivePower*_NormalColor.rgb);
                float node_4224 = dot(viewDirection,i.normalDir);
                float3 node_8016 = (0.7*(node_8941+(_RimColor.rgb*pow((1.0 - node_4224),1.5)*pow(node_4224,0.1))+(node_8941*(dot(lightDirection,normalDirection)*1.0))));
                float3 emissive = (node_8002+node_8016);
                float3 finalColor = emissive;
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
            uniform float4 _EmissiveColor;
            uniform sampler2D _EmissiveMap; uniform float4 _EmissiveMap_ST;
            uniform float _EmissivePower;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _RimColor;
            uniform float4 _NormalColor;
            uniform sampler2D _SpotMap; uniform float4 _SpotMap_ST;
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
                float3 normalLocal = (_Normal_var.rgb*float3(0.5,0.5,2));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float3 finalColor = 0;
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
