// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3221,x:33382,y:32522,varname:node_3221,prsc:2|diff-9054-OUT,alpha-2873-OUT,refract-400-OUT,voffset-620-OUT,tess-2393-OUT;n:type:ShaderForge.SFN_Tex2d,id:2360,x:32046,y:32860,varname:node_2360,prsc:2,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False|UVIN-4489-UVOUT,TEX-7604-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7604,x:31860,y:32904,ptovrint:False,ptlb:Water,ptin:_Water,varname:node_7604,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:2693,x:32447,y:32565,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_2693,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:0.5;n:type:ShaderForge.SFN_TexCoord,id:9134,x:31635,y:32550,varname:node_9134,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:4489,x:31873,y:32691,varname:node_4489,prsc:2,spu:0,spv:2|UVIN-9134-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4971,x:32720,y:32829,varname:node_4971,prsc:2|A-2693-A,B-4019-OUT;n:type:ShaderForge.SFN_Append,id:2204,x:32303,y:33008,varname:node_2204,prsc:2|A-2360-R,B-2360-G;n:type:ShaderForge.SFN_Multiply,id:400,x:32522,y:33060,varname:node_400,prsc:2|A-2204-OUT,B-7342-OUT;n:type:ShaderForge.SFN_Vector1,id:7342,x:32324,y:33153,varname:node_7342,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Multiply,id:620,x:33050,y:33032,varname:node_620,prsc:2|A-2360-B,B-1574-OUT;n:type:ShaderForge.SFN_Vector1,id:1574,x:32435,y:33292,varname:node_1574,prsc:2,v1:0.02;n:type:ShaderForge.SFN_Slider,id:2393,x:32736,y:33224,ptovrint:False,ptlb:Tesselation,ptin:_Tesselation,varname:node_2393,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5,max:10;n:type:ShaderForge.SFN_Lerp,id:5154,x:32789,y:32210,varname:node_5154,prsc:2|A-4778-B,B-8518-OUT,T-1596-OUT;n:type:ShaderForge.SFN_DepthBlend,id:1596,x:32789,y:32356,varname:node_1596,prsc:2|DIST-4418-OUT;n:type:ShaderForge.SFN_Slider,id:4418,x:31816,y:32496,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_4418,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Tex2d,id:4778,x:32262,y:32279,ptovrint:False,ptlb:Foam,ptin:_Foam,varname:node_4778,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9062-UVOUT;n:type:ShaderForge.SFN_Lerp,id:4019,x:32292,y:32689,varname:node_4019,prsc:2|A-4778-B,B-2360-B,T-1596-OUT;n:type:ShaderForge.SFN_Panner,id:9062,x:32041,y:32234,varname:node_9062,prsc:2,spu:0,spv:1|UVIN-9134-UVOUT;n:type:ShaderForge.SFN_OneMinus,id:3240,x:32720,y:32699,varname:node_3240,prsc:2|IN-4971-OUT;n:type:ShaderForge.SFN_Multiply,id:6158,x:32736,y:32955,varname:node_6158,prsc:2|A-3240-OUT,B-888-OUT;n:type:ShaderForge.SFN_Vector1,id:888,x:32753,y:33081,varname:node_888,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:6295,x:32946,y:32847,varname:node_6295,prsc:2|A-4971-OUT,B-6158-OUT;n:type:ShaderForge.SFN_Add,id:8518,x:32836,y:32583,varname:node_8518,prsc:2|A-2693-RGB,B-2360-B;n:type:ShaderForge.SFN_Multiply,id:2873,x:33149,y:32847,varname:node_2873,prsc:2|A-6295-OUT,B-4700-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4700,x:33088,y:32759,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_4700,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:5617,x:32919,y:31983,ptovrint:False,ptlb:Foam2,ptin:_Foam2,varname:node_5617,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-9820-UVOUT;n:type:ShaderForge.SFN_Multiply,id:9054,x:33382,y:32379,varname:node_9054,prsc:2|A-5617-RGB,B-5154-OUT;n:type:ShaderForge.SFN_TexCoord,id:9820,x:32458,y:31976,varname:node_9820,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:3294,x:33150,y:32457,varname:node_3294,prsc:2|A-5617-B,B-2873-OUT;n:type:ShaderForge.SFN_Multiply,id:1333,x:33151,y:32564,varname:node_1333,prsc:2|A-5617-B,B-2873-OUT;proporder:7604-2693-2393-4418-4778-4700-5617;pass:END;sub:END;*/

Shader "Custom/Waterfall" {
    Properties {
        _Water ("Water", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,0.5)
        _Tesselation ("Tesselation", Range(0, 10)) = 5
        _Depth ("Depth", Range(0, 2)) = 0
        _Foam ("Foam", 2D) = "white" {}
        _Opacity ("Opacity", Float ) = 0.5
        _Foam2 ("Foam2", 2D) = "white" {}
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _Water; uniform float4 _Water_ST;
            uniform float4 _Color;
            uniform float _Tesselation;
            uniform float _Depth;
            uniform sampler2D _Foam; uniform float4 _Foam_ST;
            uniform float _Opacity;
            uniform sampler2D _Foam2; uniform float4 _Foam2_ST;
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
                float4 screenPos : TEXCOORD3;
                float4 projPos : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_4212 = _Time + _TimeEditor;
                float2 node_4489 = (o.uv0+node_4212.g*float2(0,2));
                float4 node_2360 = tex2Dlod(_Water,float4(TRANSFORM_TEX(node_4489, _Water),0.0,0));
                float node_620 = (node_2360.b*0.02);
                v.vertex.xyz += float3(node_620,node_620,node_620);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                o.screenPos = o.pos;
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    return _Tesselation;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 node_4212 = _Time + _TimeEditor;
                float2 node_4489 = (i.uv0+node_4212.g*float2(0,2));
                float4 node_2360 = tex2D(_Water,TRANSFORM_TEX(node_4489, _Water));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (float2(node_2360.r,node_2360.g)*0.05);
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
                float4 _Foam2_var = tex2D(_Foam2,TRANSFORM_TEX(i.uv0, _Foam2));
                float2 node_9062 = (i.uv0+node_4212.g*float2(0,1));
                float4 _Foam_var = tex2D(_Foam,TRANSFORM_TEX(node_9062, _Foam));
                float node_1596 = saturate((sceneZ-partZ)/_Depth);
                float3 diffuseColor = (_Foam2_var.rgb*lerp(float3(_Foam_var.b,_Foam_var.b,_Foam_var.b),(_Color.rgb+node_2360.b),node_1596));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float node_4971 = (_Color.a*lerp(_Foam_var.b,node_2360.b,node_1596));
                float node_2873 = ((node_4971+((1.0 - node_4971)*0.5))*_Opacity);
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,node_2873),1);
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _Water; uniform float4 _Water_ST;
            uniform float4 _Color;
            uniform float _Tesselation;
            uniform float _Depth;
            uniform sampler2D _Foam; uniform float4 _Foam_ST;
            uniform float _Opacity;
            uniform sampler2D _Foam2; uniform float4 _Foam2_ST;
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
                float4 screenPos : TEXCOORD3;
                float4 projPos : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_2822 = _Time + _TimeEditor;
                float2 node_4489 = (o.uv0+node_2822.g*float2(0,2));
                float4 node_2360 = tex2Dlod(_Water,float4(TRANSFORM_TEX(node_4489, _Water),0.0,0));
                float node_620 = (node_2360.b*0.02);
                v.vertex.xyz += float3(node_620,node_620,node_620);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    return _Tesselation;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 node_2822 = _Time + _TimeEditor;
                float2 node_4489 = (i.uv0+node_2822.g*float2(0,2));
                float4 node_2360 = tex2D(_Water,TRANSFORM_TEX(node_4489, _Water));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (float2(node_2360.r,node_2360.g)*0.05);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Foam2_var = tex2D(_Foam2,TRANSFORM_TEX(i.uv0, _Foam2));
                float2 node_9062 = (i.uv0+node_2822.g*float2(0,1));
                float4 _Foam_var = tex2D(_Foam,TRANSFORM_TEX(node_9062, _Foam));
                float node_1596 = saturate((sceneZ-partZ)/_Depth);
                float3 diffuseColor = (_Foam2_var.rgb*lerp(float3(_Foam_var.b,_Foam_var.b,_Foam_var.b),(_Color.rgb+node_2360.b),node_1596));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float node_4971 = (_Color.a*lerp(_Foam_var.b,node_2360.b,node_1596));
                float node_2873 = ((node_4971+((1.0 - node_4971)*0.5))*_Opacity);
                fixed4 finalRGBA = fixed4(finalColor * node_2873,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform sampler2D _Water; uniform float4 _Water_ST;
            uniform float _Tesselation;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_5514 = _Time + _TimeEditor;
                float2 node_4489 = (o.uv0+node_5514.g*float2(0,2));
                float4 node_2360 = tex2Dlod(_Water,float4(TRANSFORM_TEX(node_4489, _Water),0.0,0));
                float node_620 = (node_2360.b*0.02);
                v.vertex.xyz += float3(node_620,node_620,node_620);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    return _Tesselation;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
