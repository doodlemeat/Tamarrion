// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.01568628,fgcg:0.04705883,fgcb:0.05882353,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:5568,x:32719,y:32712,varname:node_5568,prsc:2|diff-5337-OUT,normal-2757-RGB,emission-8994-OUT,alpha-9268-OUT,voffset-8519-OUT;n:type:ShaderForge.SFN_Vector1,id:9268,x:32429,y:32987,varname:node_9268,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:8565,x:32290,y:32716,ptovrint:False,ptlb:PortalImage,ptin:_PortalImage,varname:node_8565,prsc:2,ntxv:0,isnm:False|UVIN-3392-UVOUT;n:type:ShaderForge.SFN_Rotator,id:3392,x:32116,y:32716,varname:node_3392,prsc:2|UVIN-2301-UVOUT,ANG-7969-OUT,SPD-6069-OUT;n:type:ShaderForge.SFN_Vector1,id:6069,x:31957,y:32892,varname:node_6069,prsc:2,v1:1;n:type:ShaderForge.SFN_TexCoord,id:2301,x:31886,y:32662,varname:node_2301,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector1,id:7969,x:31796,y:32849,varname:node_7969,prsc:2,v1:1.6;n:type:ShaderForge.SFN_Tex2d,id:2757,x:32084,y:32993,ptovrint:False,ptlb:Refraction,ptin:_Refraction,varname:node_2757,prsc:2,ntxv:3,isnm:True|UVIN-9991-UVOUT;n:type:ShaderForge.SFN_Rotator,id:9991,x:31785,y:32978,varname:node_9991,prsc:2|UVIN-8973-UVOUT,SPD-2034-OUT;n:type:ShaderForge.SFN_Tex2d,id:2041,x:32322,y:32533,ptovrint:False,ptlb:Swirl,ptin:_Swirl,varname:node_2041,prsc:2,ntxv:0,isnm:False|UVIN-7225-UVOUT;n:type:ShaderForge.SFN_Multiply,id:5337,x:32520,y:32582,varname:node_5337,prsc:2|A-684-OUT,B-8565-RGB;n:type:ShaderForge.SFN_Add,id:8994,x:32659,y:32518,varname:node_8994,prsc:2|A-684-OUT,B-8565-RGB,C-6338-OUT;n:type:ShaderForge.SFN_TexCoord,id:8973,x:31429,y:32928,varname:node_8973,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:8519,x:32396,y:33078,varname:node_8519,prsc:2|A-2757-RGB,B-1632-OUT;n:type:ShaderForge.SFN_Vector1,id:1632,x:32160,y:33193,varname:node_1632,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Vector1,id:2034,x:31603,y:33092,varname:node_2034,prsc:2,v1:2;n:type:ShaderForge.SFN_Dot,id:7556,x:31950,y:33235,varname:node_7556,prsc:2,dt:0|A-495-OUT,B-601-OUT;n:type:ShaderForge.SFN_ViewVector,id:495,x:31758,y:33186,varname:node_495,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:601,x:31758,y:33328,prsc:2,pt:False;n:type:ShaderForge.SFN_OneMinus,id:9640,x:32160,y:33274,varname:node_9640,prsc:2|IN-7556-OUT;n:type:ShaderForge.SFN_Color,id:9544,x:32413,y:33293,ptovrint:False,ptlb:RimGlow,ptin:_RimGlow,varname:node_9544,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:6338,x:32645,y:33264,varname:node_6338,prsc:2|A-9544-RGB,B-9640-OUT;n:type:ShaderForge.SFN_Multiply,id:684,x:32509,y:32746,varname:node_684,prsc:2|A-2041-RGB,B-9544-RGB;n:type:ShaderForge.SFN_Rotator,id:7225,x:32024,y:32473,varname:node_7225,prsc:2|UVIN-7626-UVOUT,SPD-1312-OUT;n:type:ShaderForge.SFN_Vector1,id:1312,x:31741,y:32582,varname:node_1312,prsc:2,v1:-10;n:type:ShaderForge.SFN_TexCoord,id:7626,x:31719,y:32424,varname:node_7626,prsc:2,uv:0;proporder:8565-2757-2041-9544;pass:END;sub:END;*/

Shader "Custom/Portal" {
    Properties {
        _PortalImage ("PortalImage", 2D) = "white" {}
        _Refraction ("Refraction", 2D) = "bump" {}
        _Swirl ("Swirl", 2D) = "white" {}
        _RimGlow ("RimGlow", Color) = (1,1,1,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
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
            #pragma glsl
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _PortalImage; uniform float4 _PortalImage_ST;
            uniform sampler2D _Refraction; uniform float4 _Refraction_ST;
            uniform sampler2D _Swirl; uniform float4 _Swirl_ST;
            uniform float4 _RimGlow;
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
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_4316 = _Time + _TimeEditor;
                float node_9991_ang = node_4316.g;
                float node_9991_spd = 2.0;
                float node_9991_cos = cos(node_9991_spd*node_9991_ang);
                float node_9991_sin = sin(node_9991_spd*node_9991_ang);
                float2 node_9991_piv = float2(0.5,0.5);
                float2 node_9991 = (mul(o.uv0-node_9991_piv,float2x2( node_9991_cos, -node_9991_sin, node_9991_sin, node_9991_cos))+node_9991_piv);
                float3 _Refraction_var = UnpackNormal(tex2Dlod(_Refraction,float4(TRANSFORM_TEX(node_9991, _Refraction),0.0,0)));
                v.vertex.xyz += (_Refraction_var.rgb*0.25);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_4316 = _Time + _TimeEditor;
                float node_9991_ang = node_4316.g;
                float node_9991_spd = 2.0;
                float node_9991_cos = cos(node_9991_spd*node_9991_ang);
                float node_9991_sin = sin(node_9991_spd*node_9991_ang);
                float2 node_9991_piv = float2(0.5,0.5);
                float2 node_9991 = (mul(i.uv0-node_9991_piv,float2x2( node_9991_cos, -node_9991_sin, node_9991_sin, node_9991_cos))+node_9991_piv);
                float3 _Refraction_var = UnpackNormal(tex2D(_Refraction,TRANSFORM_TEX(node_9991, _Refraction)));
                float3 normalLocal = _Refraction_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
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
                float node_7225_ang = node_4316.g;
                float node_7225_spd = (-10.0);
                float node_7225_cos = cos(node_7225_spd*node_7225_ang);
                float node_7225_sin = sin(node_7225_spd*node_7225_ang);
                float2 node_7225_piv = float2(0.5,0.5);
                float2 node_7225 = (mul(i.uv0-node_7225_piv,float2x2( node_7225_cos, -node_7225_sin, node_7225_sin, node_7225_cos))+node_7225_piv);
                float4 _Swirl_var = tex2D(_Swirl,TRANSFORM_TEX(node_7225, _Swirl));
                float3 node_684 = (_Swirl_var.rgb*_RimGlow.rgb);
                float node_3392_ang = 1.6;
                float node_3392_spd = 1.0;
                float node_3392_cos = cos(node_3392_spd*node_3392_ang);
                float node_3392_sin = sin(node_3392_spd*node_3392_ang);
                float2 node_3392_piv = float2(0.5,0.5);
                float2 node_3392 = (mul(i.uv0-node_3392_piv,float2x2( node_3392_cos, -node_3392_sin, node_3392_sin, node_3392_cos))+node_3392_piv);
                float4 _PortalImage_var = tex2D(_PortalImage,TRANSFORM_TEX(node_3392, _PortalImage));
                float3 diffuseColor = (node_684*_PortalImage_var.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = (node_684+_PortalImage_var.rgb+(_RimGlow.rgb*(1.0 - dot(viewDirection,i.normalDir))));
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1.0);
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
            #pragma glsl
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _PortalImage; uniform float4 _PortalImage_ST;
            uniform sampler2D _Refraction; uniform float4 _Refraction_ST;
            uniform sampler2D _Swirl; uniform float4 _Swirl_ST;
            uniform float4 _RimGlow;
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
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_64 = _Time + _TimeEditor;
                float node_9991_ang = node_64.g;
                float node_9991_spd = 2.0;
                float node_9991_cos = cos(node_9991_spd*node_9991_ang);
                float node_9991_sin = sin(node_9991_spd*node_9991_ang);
                float2 node_9991_piv = float2(0.5,0.5);
                float2 node_9991 = (mul(o.uv0-node_9991_piv,float2x2( node_9991_cos, -node_9991_sin, node_9991_sin, node_9991_cos))+node_9991_piv);
                float3 _Refraction_var = UnpackNormal(tex2Dlod(_Refraction,float4(TRANSFORM_TEX(node_9991, _Refraction),0.0,0)));
                v.vertex.xyz += (_Refraction_var.rgb*0.25);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_64 = _Time + _TimeEditor;
                float node_9991_ang = node_64.g;
                float node_9991_spd = 2.0;
                float node_9991_cos = cos(node_9991_spd*node_9991_ang);
                float node_9991_sin = sin(node_9991_spd*node_9991_ang);
                float2 node_9991_piv = float2(0.5,0.5);
                float2 node_9991 = (mul(i.uv0-node_9991_piv,float2x2( node_9991_cos, -node_9991_sin, node_9991_sin, node_9991_cos))+node_9991_piv);
                float3 _Refraction_var = UnpackNormal(tex2D(_Refraction,TRANSFORM_TEX(node_9991, _Refraction)));
                float3 normalLocal = _Refraction_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float node_7225_ang = node_64.g;
                float node_7225_spd = (-10.0);
                float node_7225_cos = cos(node_7225_spd*node_7225_ang);
                float node_7225_sin = sin(node_7225_spd*node_7225_ang);
                float2 node_7225_piv = float2(0.5,0.5);
                float2 node_7225 = (mul(i.uv0-node_7225_piv,float2x2( node_7225_cos, -node_7225_sin, node_7225_sin, node_7225_cos))+node_7225_piv);
                float4 _Swirl_var = tex2D(_Swirl,TRANSFORM_TEX(node_7225, _Swirl));
                float3 node_684 = (_Swirl_var.rgb*_RimGlow.rgb);
                float node_3392_ang = 1.6;
                float node_3392_spd = 1.0;
                float node_3392_cos = cos(node_3392_spd*node_3392_ang);
                float node_3392_sin = sin(node_3392_spd*node_3392_ang);
                float2 node_3392_piv = float2(0.5,0.5);
                float2 node_3392 = (mul(i.uv0-node_3392_piv,float2x2( node_3392_cos, -node_3392_sin, node_3392_sin, node_3392_cos))+node_3392_piv);
                float4 _PortalImage_var = tex2D(_PortalImage,TRANSFORM_TEX(node_3392, _PortalImage));
                float3 diffuseColor = (node_684*_PortalImage_var.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                return fixed4(finalColor * 1.0,0);
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
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform sampler2D _Refraction; uniform float4 _Refraction_ST;
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
                float4 node_4624 = _Time + _TimeEditor;
                float node_9991_ang = node_4624.g;
                float node_9991_spd = 2.0;
                float node_9991_cos = cos(node_9991_spd*node_9991_ang);
                float node_9991_sin = sin(node_9991_spd*node_9991_ang);
                float2 node_9991_piv = float2(0.5,0.5);
                float2 node_9991 = (mul(o.uv0-node_9991_piv,float2x2( node_9991_cos, -node_9991_sin, node_9991_sin, node_9991_cos))+node_9991_piv);
                float3 _Refraction_var = UnpackNormal(tex2Dlod(_Refraction,float4(TRANSFORM_TEX(node_9991, _Refraction),0.0,0)));
                v.vertex.xyz += (_Refraction_var.rgb*0.25);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
