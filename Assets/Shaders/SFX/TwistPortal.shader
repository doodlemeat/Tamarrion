// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-3191-OUT,alpha-9563-OUT,refract-7534-OUT;n:type:ShaderForge.SFN_Tex2d,id:7476,x:31318,y:32797,ptovrint:False,ptlb:Circle,ptin:_Circle,varname:node_7476,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b1d7fee26e54cc3498f6267f072a45b9,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1934,x:31896,y:32699,varname:node_1934,prsc:2|A-6457-OUT,B-7476-B,C-7988-OUT;n:type:ShaderForge.SFN_OneMinus,id:3972,x:31668,y:32650,varname:node_3972,prsc:2|IN-7476-B;n:type:ShaderForge.SFN_Power,id:6457,x:31668,y:32503,varname:node_6457,prsc:2|VAL-3972-OUT,EXP-3748-OUT;n:type:ShaderForge.SFN_Vector1,id:3748,x:31668,y:32429,varname:node_3748,prsc:2,v1:3;n:type:ShaderForge.SFN_Vector1,id:7988,x:31896,y:32650,varname:node_7988,prsc:2,v1:10;n:type:ShaderForge.SFN_Tex2d,id:5965,x:31421,y:33195,ptovrint:False,ptlb:Twist Refraction,ptin:_TwistRefraction,varname:node_5965,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:68d855c3be4997846b692110efa8c307,ntxv:3,isnm:True|UVIN-8831-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:7534,x:32460,y:33167,varname:node_7534,prsc:2,cc1:1,cc2:0,cc3:-1,cc4:-1|IN-8574-OUT;n:type:ShaderForge.SFN_Multiply,id:5428,x:31903,y:33196,varname:node_5428,prsc:2|A-7476-RGB,B-5965-RGB;n:type:ShaderForge.SFN_Rotator,id:8831,x:30968,y:33040,varname:node_8831,prsc:2|UVIN-1845-UVOUT,SPD-9162-OUT;n:type:ShaderForge.SFN_TexCoord,id:1845,x:30749,y:32990,varname:node_1845,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector1,id:9162,x:30749,y:33135,varname:node_9162,prsc:2,v1:4;n:type:ShaderForge.SFN_Multiply,id:8574,x:32263,y:33167,varname:node_8574,prsc:2|A-3933-OUT,B-5428-OUT;n:type:ShaderForge.SFN_Vector1,id:3933,x:32263,y:33105,varname:node_3933,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Tex2d,id:4911,x:31421,y:33002,ptovrint:False,ptlb:Twist Emissive,ptin:_TwistEmissive,varname:node_4911,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a80492972cba68b4d9cb1c32543bf597,ntxv:3,isnm:False|UVIN-8831-UVOUT;n:type:ShaderForge.SFN_Add,id:1716,x:32107,y:32769,varname:node_1716,prsc:2|A-1934-OUT,B-707-OUT;n:type:ShaderForge.SFN_Multiply,id:9939,x:31976,y:33038,varname:node_9939,prsc:2|A-707-OUT,B-7476-B;n:type:ShaderForge.SFN_Add,id:9563,x:32295,y:32898,varname:node_9563,prsc:2|A-1934-OUT,B-9939-OUT;n:type:ShaderForge.SFN_Multiply,id:3191,x:32349,y:32666,varname:node_3191,prsc:2|A-8182-RGB,B-1716-OUT;n:type:ShaderForge.SFN_Color,id:8182,x:32107,y:32546,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_8182,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:7498,x:31742,y:33010,varname:node_7498,prsc:2,v1:0.65;n:type:ShaderForge.SFN_Multiply,id:707,x:31742,y:32874,varname:node_707,prsc:2|A-4911-B,B-7498-OUT;proporder:7476-5965-4911-8182;pass:END;sub:END;*/

Shader "SFX/TestPortal" {
    Properties {
        _Circle ("Circle", 2D) = "white" {}
        _TwistRefraction ("Twist Refraction", 2D) = "bump" {}
        _TwistEmissive ("Twist Emissive", 2D) = "bump" {}
        _Color ("Color", Color) = (1,1,1,1)
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _Circle; uniform float4 _Circle_ST;
            uniform sampler2D _TwistRefraction; uniform float4 _TwistRefraction_ST;
            uniform sampler2D _TwistEmissive; uniform float4 _TwistEmissive_ST;
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
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
                float4 _Circle_var = tex2D(_Circle,TRANSFORM_TEX(i.uv0, _Circle));
                float4 node_1582 = _Time + _TimeEditor;
                float node_8831_ang = node_1582.g;
                float node_8831_spd = 4.0;
                float node_8831_cos = cos(node_8831_spd*node_8831_ang);
                float node_8831_sin = sin(node_8831_spd*node_8831_ang);
                float2 node_8831_piv = float2(0.5,0.5);
                float2 node_8831 = (mul(i.uv0-node_8831_piv,float2x2( node_8831_cos, -node_8831_sin, node_8831_sin, node_8831_cos))+node_8831_piv);
                float3 _TwistRefraction_var = UnpackNormal(tex2D(_TwistRefraction,TRANSFORM_TEX(node_8831, _TwistRefraction)));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (0.1*(_Circle_var.rgb*_TwistRefraction_var.rgb)).gr;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float node_1934 = (pow((1.0 - _Circle_var.b),3.0)*_Circle_var.b*10.0);
                float4 _TwistEmissive_var = tex2D(_TwistEmissive,TRANSFORM_TEX(node_8831, _TwistEmissive));
                float node_707 = (_TwistEmissive_var.b*0.65);
                float3 emissive = (_Color.rgb*(node_1934+node_707));
                float3 finalColor = emissive;
                return fixed4(lerp(sceneColor.rgb, finalColor,(node_1934+(node_707*_Circle_var.b))),1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
