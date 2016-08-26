// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:783,x:32719,y:32712,varname:node_783,prsc:2|emission-3907-OUT,alpha-9541-OUT;n:type:ShaderForge.SFN_ViewVector,id:8731,x:31994,y:32862,varname:node_8731,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2985,x:31994,y:32983,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:6002,x:32187,y:32906,varname:node_6002,prsc:2,dt:0|A-8731-OUT,B-2985-OUT;n:type:ShaderForge.SFN_Vector1,id:2758,x:32452,y:32901,varname:node_2758,prsc:2,v1:5;n:type:ShaderForge.SFN_Color,id:3056,x:32416,y:32340,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3056,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:6038,x:31961,y:32620,ptovrint:False,ptlb:Water,ptin:_Water,varname:node_6038,prsc:2,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False|UVIN-3020-OUT;n:type:ShaderForge.SFN_Multiply,id:3354,x:32452,y:32511,varname:node_3354,prsc:2|A-3056-RGB,B-113-OUT;n:type:ShaderForge.SFN_ScreenPos,id:1559,x:31574,y:32565,varname:node_1559,prsc:2,sctp:0;n:type:ShaderForge.SFN_Add,id:3020,x:31784,y:32620,varname:node_3020,prsc:2|A-1559-UVOUT,B-9828-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:4161,x:31399,y:32708,varname:node_4161,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:9828,x:31574,y:32708,varname:node_9828,prsc:2,spu:0.3,spv:0.3|UVIN-4161-UVOUT;n:type:ShaderForge.SFN_Power,id:7983,x:32452,y:32779,varname:node_7983,prsc:2|VAL-6002-OUT,EXP-2758-OUT;n:type:ShaderForge.SFN_Add,id:1665,x:32452,y:32648,varname:node_1665,prsc:2|A-3354-OUT,B-2589-OUT,C-5324-RGB;n:type:ShaderForge.SFN_Power,id:113,x:32226,y:32531,varname:node_113,prsc:2|VAL-6038-RGB,EXP-4595-OUT;n:type:ShaderForge.SFN_Vector1,id:4595,x:32226,y:32663,varname:node_4595,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:1069,x:32452,y:32957,varname:node_1069,prsc:2|A-6002-OUT,B-6002-OUT,C-9585-OUT,D-6728-OUT;n:type:ShaderForge.SFN_Time,id:8252,x:31414,y:33177,varname:node_8252,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:8176,x:31414,y:33110,ptovrint:False,ptlb:Pulse Speed,ptin:_PulseSpeed,varname:_RimSpeed_copy,prsc:2,glob:False,v1:4;n:type:ShaderForge.SFN_Multiply,id:8563,x:31620,y:33140,varname:node_8563,prsc:2|A-8176-OUT,B-8252-T;n:type:ShaderForge.SFN_Sin,id:6699,x:31808,y:33140,varname:node_6699,prsc:2|IN-8563-OUT;n:type:ShaderForge.SFN_RemapRange,id:5658,x:31994,y:33140,varname:node_5658,prsc:2,frmn:-5,frmx:1,tomn:2,tomx:1|IN-6699-OUT;n:type:ShaderForge.SFN_Vector1,id:6728,x:32452,y:33087,varname:node_6728,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:5324,x:31961,y:32439,ptovrint:False,ptlb:Star,ptin:_Star,varname:node_5324,prsc:2,tex:781501c5543f863409c6909f47dced97,ntxv:2,isnm:False|UVIN-4549-OUT;n:type:ShaderForge.SFN_Add,id:4549,x:31784,y:32439,varname:node_4549,prsc:2|A-2518-UVOUT,B-1559-UVOUT;n:type:ShaderForge.SFN_Panner,id:2518,x:31574,y:32416,varname:node_2518,prsc:2,spu:-0.4,spv:-0.4;n:type:ShaderForge.SFN_OneMinus,id:9048,x:32244,y:33204,varname:node_9048,prsc:2|IN-6002-OUT;n:type:ShaderForge.SFN_Add,id:9541,x:32702,y:33169,varname:node_9541,prsc:2|A-2589-OUT,B-9048-OUT,C-1069-OUT,D-7099-OUT;n:type:ShaderForge.SFN_Multiply,id:9585,x:32222,y:33074,varname:node_9585,prsc:2|A-5658-OUT,B-4947-OUT;n:type:ShaderForge.SFN_Vector1,id:4947,x:31976,y:32795,varname:node_4947,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:2589,x:32265,y:32746,varname:node_2589,prsc:2|A-7983-OUT,B-4947-OUT;n:type:ShaderForge.SFN_Color,id:8417,x:32416,y:32179,ptovrint:False,ptlb:Centre Color,ptin:_CentreColor,varname:node_8417,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Add,id:4926,x:32738,y:32517,varname:node_4926,prsc:2|A-8575-OUT,B-8417-RGB,C-1665-OUT;n:type:ShaderForge.SFN_Multiply,id:8575,x:32738,y:32296,varname:node_8575,prsc:2|A-3056-RGB,B-9553-OUT;n:type:ShaderForge.SFN_Vector1,id:9553,x:32724,y:32236,varname:node_9553,prsc:2,v1:0.75;n:type:ShaderForge.SFN_Multiply,id:3907,x:32947,y:32555,varname:node_3907,prsc:2|A-4926-OUT,B-1665-OUT,C-8962-OUT;n:type:ShaderForge.SFN_Vector1,id:8962,x:32947,y:32477,varname:node_8962,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:7099,x:32611,y:33324,varname:node_7099,prsc:2,v1:-0.15;proporder:3056-6038-8176-5324-8417;pass:END;sub:END;*/

Shader "Custom/MagicOrb" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Water ("Water", 2D) = "white" {}
        _PulseSpeed ("Pulse Speed", Float ) = 4
        _Star ("Star", 2D) = "black" {}
        _CentreColor ("Centre Color", Color) = (1,1,1,1)
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
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _Water; uniform float4 _Water_ST;
            uniform float _PulseSpeed;
            uniform sampler2D _Star; uniform float4 _Star_ST;
            uniform float4 _CentreColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 screenPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 node_786 = _Time + _TimeEditor;
                float2 node_3020 = (i.screenPos.rg+(i.uv0+node_786.g*float2(0.3,0.3)));
                float4 _Water_var = tex2D(_Water,TRANSFORM_TEX(node_3020, _Water));
                float node_6002 = dot(viewDirection,i.normalDir);
                float node_4947 = 0.5;
                float node_2589 = (pow(node_6002,5.0)*node_4947);
                float2 node_4549 = ((i.uv0+node_786.g*float2(-0.4,-0.4))+i.screenPos.rg);
                float4 _Star_var = tex2D(_Star,TRANSFORM_TEX(node_4549, _Star));
                float3 node_1665 = ((_Color.rgb*pow(_Water_var.rgb,0.5))+node_2589+_Star_var.rgb);
                float3 emissive = (((_Color.rgb*0.75)+_CentreColor.rgb+node_1665)*node_1665*0.5);
                float3 finalColor = emissive;
                float4 node_8252 = _Time + _TimeEditor;
                fixed4 finalRGBA = fixed4(finalColor,(node_2589+(1.0 - node_6002)+(node_6002*node_6002*((sin((_PulseSpeed*node_8252.g))*-0.1666667+1.166667)*node_4947)*0.5)+(-0.15)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
