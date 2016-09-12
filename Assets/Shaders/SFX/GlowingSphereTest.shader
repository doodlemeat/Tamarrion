// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32710,y:32756,varname:node_4013,prsc:2|emission-2587-OUT,alpha-5856-OUT;n:type:ShaderForge.SFN_Lerp,id:5856,x:32205,y:32594,varname:node_5856,prsc:2|A-8073-B,B-8839-OUT,T-7403-OUT;n:type:ShaderForge.SFN_Tex2d,id:8073,x:31947,y:32486,ptovrint:False,ptlb:Foam,ptin:_Foam,varname:node_8073,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-3295-UVOUT;n:type:ShaderForge.SFN_DepthBlend,id:7403,x:32205,y:32745,varname:node_7403,prsc:2|DIST-2210-OUT;n:type:ShaderForge.SFN_Slider,id:2210,x:32126,y:32903,ptovrint:False,ptlb:Edge Foam,ptin:_EdgeFoam,varname:node_2210,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Panner,id:3295,x:32143,y:32288,varname:node_3295,prsc:2,spu:0.05,spv:0.05|UVIN-1151-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1151,x:31959,y:32288,varname:node_1151,prsc:2,uv:0;n:type:ShaderForge.SFN_Color,id:6094,x:32739,y:32457,ptovrint:False,ptlb:Foam Color,ptin:_FoamColor,varname:node_6094,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:8839,x:31947,y:32646,varname:node_8839,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:2587,x:32739,y:32613,varname:node_2587,prsc:2|A-6094-RGB,B-9600-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9600,x:32530,y:32634,ptovrint:False,ptlb:Emissive Power,ptin:_EmissivePower,varname:node_9600,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:8073-2210-6094-9600;pass:END;sub:END;*/

Shader "Custom/GlowingSphere" {
    Properties {
        _Foam ("Foam", 2D) = "black" {}
        _EdgeFoam ("Edge Foam", Range(0, 1)) = 0.5
        _FoamColor ("Foam Color", Color) = (1,1,1,1)
        _EmissivePower ("Emissive Power", Float ) = 1
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
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _Foam; uniform float4 _Foam_ST;
            uniform float _EdgeFoam;
            uniform float4 _FoamColor;
            uniform float _EmissivePower;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 projPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float3 emissive = (_FoamColor.rgb*_EmissivePower);
                float3 finalColor = emissive;
                float4 node_7041 = _Time + _TimeEditor;
                float2 node_3295 = (i.uv0+node_7041.g*float2(0.05,0.05));
                float4 _Foam_var = tex2D(_Foam,TRANSFORM_TEX(node_3295, _Foam));
                fixed4 finalRGBA = fixed4(finalColor,lerp(_Foam_var.b,0.0,saturate((sceneZ-partZ)/_EdgeFoam)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
