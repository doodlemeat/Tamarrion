// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3484,x:32719,y:32712,varname:node_3484,prsc:2|emission-2073-OUT,alpha-6177-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6177,x:32392,y:32975,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_6177,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:3228,x:31432,y:32478,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_9218,prsc:2,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False|UVIN-3199-UVOUT;n:type:ShaderForge.SFN_Power,id:4867,x:31671,y:32827,varname:node_4867,prsc:2|VAL-2559-OUT,EXP-2184-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2184,x:31490,y:32905,ptovrint:False,ptlb:Rim Power,ptin:_RimPower,varname:node_1470,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_NormalVector,id:92,x:30953,y:32882,prsc:2,pt:False;n:type:ShaderForge.SFN_ViewVector,id:4346,x:30967,y:32740,varname:node_4346,prsc:2;n:type:ShaderForge.SFN_Dot,id:9411,x:31169,y:32816,varname:node_9411,prsc:2,dt:0|A-4346-OUT,B-92-OUT;n:type:ShaderForge.SFN_OneMinus,id:2559,x:31367,y:32826,varname:node_2559,prsc:2|IN-9411-OUT;n:type:ShaderForge.SFN_Panner,id:3199,x:31252,y:32476,varname:node_3199,prsc:2,spu:0.1,spv:1|UVIN-5154-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5154,x:31070,y:32474,varname:node_5154,prsc:2,uv:0;n:type:ShaderForge.SFN_Color,id:4329,x:31550,y:32640,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,varname:node_430,prsc:2,glob:False,c1:0.9804878,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:3154,x:32145,y:32894,varname:node_3154,prsc:2|A-1296-OUT,B-4867-OUT,C-3626-RGB;n:type:ShaderForge.SFN_Color,id:3626,x:31676,y:32973,ptovrint:False,ptlb:Emisssive Color,ptin:_EmisssiveColor,varname:node_4571,prsc:2,glob:False,c1:0.9803922,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Add,id:1296,x:31818,y:32582,varname:node_1296,prsc:2|A-3228-RGB,B-4329-RGB;n:type:ShaderForge.SFN_Add,id:2073,x:32373,y:32811,varname:node_2073,prsc:2|A-1296-OUT,B-3154-OUT,C-4867-OUT;proporder:6177-3228-2184-4329-3626;pass:END;sub:END;*/

Shader "SpellFX/Smite" {
    Properties {
        _Opacity ("Opacity", Float ) = 0.5
        _Texture ("Texture", 2D) = "white" {}
        _RimPower ("Rim Power", Float ) = 1
        _DiffuseColor ("Diffuse Color", Color) = (0.9804878,1,0,1)
        _EmisssiveColor ("Emisssive Color", Color) = (0.9803922,1,0,1)
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
            uniform float _Opacity;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _RimPower;
            uniform float4 _DiffuseColor;
            uniform float4 _EmisssiveColor;
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
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 node_303 = _Time + _TimeEditor;
                float2 node_3199 = (i.uv0+node_303.g*float2(0.1,1));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_3199, _Texture));
                float3 node_1296 = (_Texture_var.rgb+_DiffuseColor.rgb);
                float node_4867 = pow((1.0 - dot(viewDirection,i.normalDir)),_RimPower);
                float3 emissive = (node_1296+(node_1296*node_4867*_EmisssiveColor.rgb)+node_4867);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,_Opacity);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
