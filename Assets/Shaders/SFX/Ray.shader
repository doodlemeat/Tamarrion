// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:3,bdst:7,culm:2,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:783,x:32719,y:32712,varname:node_783,prsc:2|emission-4760-OUT,alpha-9819-OUT;n:type:ShaderForge.SFN_Tex2d,id:3593,x:31574,y:32670,ptovrint:False,ptlb:Opacity Map,ptin:_OpacityMap,varname:node_3593,prsc:2,tex:f106dabb253a4d043a9c491e8967f766,ntxv:0,isnm:False|UVIN-2963-OUT;n:type:ShaderForge.SFN_Tex2d,id:9635,x:32138,y:33016,ptovrint:False,ptlb:Gradient,ptin:_Gradient,varname:node_9635,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9819,x:32495,y:33003,varname:node_9819,prsc:2|A-3593-B,B-9635-B,C-7880-OUT;n:type:ShaderForge.SFN_Color,id:572,x:31827,y:32298,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_572,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:7880,x:32138,y:33197,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_7880,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_Add,id:2963,x:31505,y:32459,varname:node_2963,prsc:2|A-4617-OUT,B-5737-OUT;n:type:ShaderForge.SFN_Divide,id:4617,x:31505,y:32326,varname:node_4617,prsc:2|A-4506-UVOUT,B-8227-OUT;n:type:ShaderForge.SFN_Append,id:5737,x:31279,y:32470,varname:node_5737,prsc:2|A-3466-OUT,B-3148-OUT;n:type:ShaderForge.SFN_TexCoord,id:4506,x:31505,y:32170,varname:node_4506,prsc:2,uv:0;n:type:ShaderForge.SFN_Append,id:8227,x:31279,y:32254,varname:node_8227,prsc:2|A-6933-OUT,B-5288-OUT;n:type:ShaderForge.SFN_Divide,id:3466,x:31011,y:32350,varname:node_3466,prsc:2|A-8097-OUT,B-6933-OUT;n:type:ShaderForge.SFN_Fmod,id:8097,x:31011,y:32506,varname:node_8097,prsc:2|A-250-OUT,B-6933-OUT;n:type:ShaderForge.SFN_Relay,id:6933,x:30568,y:32271,varname:node_6933,prsc:2|IN-5221-X;n:type:ShaderForge.SFN_OneMinus,id:3148,x:31231,y:32701,varname:node_3148,prsc:2|IN-9492-OUT;n:type:ShaderForge.SFN_Divide,id:9492,x:31060,y:32701,varname:node_9492,prsc:2|A-5314-OUT,B-5288-OUT;n:type:ShaderForge.SFN_Floor,id:5314,x:31060,y:32840,varname:node_5314,prsc:2|IN-8228-OUT;n:type:ShaderForge.SFN_Divide,id:8228,x:30882,y:32840,varname:node_8228,prsc:2|A-250-OUT,B-6933-OUT;n:type:ShaderForge.SFN_Relay,id:5288,x:30455,y:32465,varname:node_5288,prsc:2|IN-5221-Y;n:type:ShaderForge.SFN_Vector4Property,id:5221,x:29818,y:32370,ptovrint:False,ptlb:Sequence,ptin:_Sequence,varname:node_9311,prsc:2,glob:False,v1:4,v2:4,v3:0.2,v4:0;n:type:ShaderForge.SFN_Relay,id:2397,x:29860,y:32757,varname:node_2397,prsc:2|IN-5221-Z;n:type:ShaderForge.SFN_Multiply,id:7684,x:30038,y:33119,varname:node_7684,prsc:2|A-2397-OUT,B-5240-OUT;n:type:ShaderForge.SFN_Frac,id:5633,x:30234,y:32998,varname:node_5633,prsc:2|IN-2001-OUT;n:type:ShaderForge.SFN_Multiply,id:1628,x:30450,y:32901,varname:node_1628,prsc:2|A-5484-OUT,B-5633-OUT;n:type:ShaderForge.SFN_Multiply,id:5484,x:30234,y:32867,varname:node_5484,prsc:2|A-6933-OUT,B-5288-OUT;n:type:ShaderForge.SFN_Round,id:250,x:30639,y:32922,varname:node_250,prsc:2|IN-1628-OUT;n:type:ShaderForge.SFN_Multiply,id:4760,x:31837,y:32562,varname:node_4760,prsc:2|A-1203-OUT,B-3593-RGB,C-572-RGB;n:type:ShaderForge.SFN_ValueProperty,id:1203,x:31827,y:32479,ptovrint:False,ptlb:Emissive Strength,ptin:_EmissiveStrength,varname:node_3699,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_Slider,id:5240,x:29692,y:33084,ptovrint:False,ptlb:SeqSelect,ptin:_SeqSelect,varname:node_8844,prsc:2,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Add,id:2001,x:30038,y:32959,varname:node_2001,prsc:2|A-2397-OUT,B-5240-OUT;proporder:3593-9635-572-7880-1203-5221-5240;pass:END;sub:END;*/

Shader "Custom/Ray" {
    Properties {
        _OpacityMap ("Opacity Map", 2D) = "white" {}
        _Gradient ("Gradient", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Opacity ("Opacity", Float ) = 0.5
        _EmissiveStrength ("Emissive Strength", Float ) = 0
        _Sequence ("Sequence", Vector) = (4,4,0.2,0)
        _SeqSelect ("SeqSelect", Range(0, 1)) = 0.5
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
            uniform sampler2D _OpacityMap; uniform float4 _OpacityMap_ST;
            uniform sampler2D _Gradient; uniform float4 _Gradient_ST;
            uniform float4 _Color;
            uniform float _Opacity;
            uniform float4 _Sequence;
            uniform float _EmissiveStrength;
            uniform float _SeqSelect;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float node_6933 = _Sequence.r;
                float node_5288 = _Sequence.g;
                float node_2397 = _Sequence.b;
                float node_250 = round(((node_6933*node_5288)*frac((node_2397+_SeqSelect))));
                float2 node_2963 = ((i.uv0/float2(node_6933,node_5288))+float2((fmod(node_250,node_6933)/node_6933),(1.0 - (floor((node_250/node_6933))/node_5288))));
                float4 _OpacityMap_var = tex2D(_OpacityMap,TRANSFORM_TEX(node_2963, _OpacityMap));
                float3 emissive = (_EmissiveStrength*_OpacityMap_var.rgb*_Color.rgb);
                float3 finalColor = emissive;
                float4 _Gradient_var = tex2D(_Gradient,TRANSFORM_TEX(i.uv0, _Gradient));
                fixed4 finalRGBA = fixed4(finalColor,(_OpacityMap_var.b*_Gradient_var.b*_Opacity));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
