// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:8242,x:33331,y:32690,varname:node_8242,prsc:2|emission-2586-OUT,alpha-4452-OUT,clip-6507-B,refract-2830-OUT;n:type:ShaderForge.SFN_Tex2d,id:4703,x:32048,y:32804,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_4703,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False|UVIN-6072-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7426,x:32305,y:32943,varname:node_7426,prsc:2|A-4703-B,B-6507-B;n:type:ShaderForge.SFN_Tex2d,id:6507,x:32048,y:32990,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_6507,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bf75b4c83e52d654cacde7d2751b6629,ntxv:0,isnm:False|UVIN-3720-UVOUT;n:type:ShaderForge.SFN_Append,id:2786,x:32305,y:32757,varname:node_2786,prsc:2|A-4703-R,B-4703-G;n:type:ShaderForge.SFN_Append,id:9922,x:32305,y:33099,varname:node_9922,prsc:2|A-6507-R,B-6507-G;n:type:ShaderForge.SFN_Multiply,id:3631,x:32487,y:33016,varname:node_3631,prsc:2|A-2786-OUT,B-9922-OUT;n:type:ShaderForge.SFN_Panner,id:6072,x:31883,y:32804,varname:node_6072,prsc:2,spu:0,spv:-1|UVIN-3720-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:3720,x:31632,y:32930,varname:node_3720,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector1,id:9728,x:32512,y:33162,varname:node_9728,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Multiply,id:4824,x:32680,y:33073,varname:node_4824,prsc:2|A-3631-OUT,B-9728-OUT;n:type:ShaderForge.SFN_Multiply,id:6787,x:32700,y:32769,varname:node_6787,prsc:2|A-7599-OUT,B-4703-RGB;n:type:ShaderForge.SFN_DepthBlend,id:7599,x:32894,y:32639,varname:node_7599,prsc:2|DIST-2372-OUT;n:type:ShaderForge.SFN_Slider,id:2372,x:32626,y:32560,ptovrint:False,ptlb:Softness,ptin:_Softness,varname:node_2372,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:3;n:type:ShaderForge.SFN_Multiply,id:4452,x:32700,y:32902,varname:node_4452,prsc:2|A-7599-OUT,B-7426-OUT,C-7654-A;n:type:ShaderForge.SFN_Multiply,id:2830,x:32965,y:33023,varname:node_2830,prsc:2|A-7599-OUT,B-4824-OUT;n:type:ShaderForge.SFN_Multiply,id:2586,x:33153,y:32612,varname:node_2586,prsc:2|A-7654-RGB,B-6787-OUT;n:type:ShaderForge.SFN_Color,id:7654,x:33153,y:32437,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7654,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;proporder:4703-6507-2372-7654;pass:END;sub:END;*/

Shader "Custom/WaterParticle" {
    Properties {
        _Noise ("Noise", 2D) = "white" {}
        _Opacity ("Opacity", 2D) = "white" {}
        _Softness ("Softness", Range(0, 3)) = 1
        _Color ("Color", Color) = (1,1,1,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _Opacity; uniform float4 _Opacity_ST;
            uniform float _Softness;
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
                float4 projPos : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float node_7599 = saturate((sceneZ-partZ)/_Softness);
                float4 node_7095 = _Time + _TimeEditor;
                float2 node_6072 = (i.uv0+node_7095.g*float2(0,-1));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_6072, _Noise));
                float4 _Opacity_var = tex2D(_Opacity,TRANSFORM_TEX(i.uv0, _Opacity));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (node_7599*((float2(_Noise_var.r,_Noise_var.g)*float2(_Opacity_var.r,_Opacity_var.g))*0.05));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                clip(_Opacity_var.b - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = (_Color.rgb*(node_7599*_Noise_var.rgb));
                float3 finalColor = emissive;
                return fixed4(lerp(sceneColor.rgb, finalColor,(node_7599*(_Noise_var.b*_Opacity_var.b)*_Color.a)),1);
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Opacity; uniform float4 _Opacity_ST;
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
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _Opacity_var = tex2D(_Opacity,TRANSFORM_TEX(i.uv0, _Opacity));
                clip(_Opacity_var.b - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
