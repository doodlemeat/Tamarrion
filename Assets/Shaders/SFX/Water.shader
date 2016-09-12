// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32710,y:32756,varname:node_4013,prsc:2|diff-5856-OUT,spec-4739-OUT,alpha-1835-OUT,refract-7665-OUT,voffset-4509-OUT,tess-4395-OUT;n:type:ShaderForge.SFN_Tex2d,id:2890,x:31273,y:33001,varname:node_2890,prsc:2,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:3,isnm:True|UVIN-5976-UVOUT,TEX-6937-TEX;n:type:ShaderForge.SFN_Append,id:3831,x:31490,y:33022,varname:node_3831,prsc:2|A-2890-R,B-2890-G;n:type:ShaderForge.SFN_Panner,id:5976,x:31083,y:33001,varname:node_5976,prsc:2,spu:0.01,spv:-0.025|UVIN-6621-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6621,x:30890,y:33001,varname:node_6621,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:2896,x:31750,y:32919,varname:node_2896,prsc:2|A-8825-OUT,B-3831-OUT;n:type:ShaderForge.SFN_Append,id:8825,x:31490,y:32823,varname:node_8825,prsc:2|A-4057-R,B-4057-G;n:type:ShaderForge.SFN_Tex2d,id:4057,x:31273,y:32796,varname:node_4057,prsc:2,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:3,isnm:True|UVIN-4348-UVOUT,TEX-6937-TEX;n:type:ShaderForge.SFN_Panner,id:4348,x:31083,y:32796,varname:node_4348,prsc:2,spu:-0.02,spv:0.01|UVIN-1609-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1609,x:30890,y:32796,varname:node_1609,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2dAsset,id:6937,x:30422,y:32915,ptovrint:False,ptlb:RainRef,ptin:_RainRef,varname:node_6937,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:463f3e17448c6f147a7b7811acdfb56f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector1,id:7787,x:31997,y:33184,varname:node_7787,prsc:2,v1:0.01;n:type:ShaderForge.SFN_Multiply,id:7665,x:31997,y:33047,varname:node_7665,prsc:2|A-2896-OUT,B-7787-OUT;n:type:ShaderForge.SFN_Color,id:8664,x:32305,y:32473,ptovrint:False,ptlb:Water Color,ptin:_WaterColor,varname:node_8664,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.6029412,c3:0.6029412,c4:0.1;n:type:ShaderForge.SFN_Slider,id:4395,x:32497,y:33254,ptovrint:False,ptlb:Tesselation,ptin:_Tesselation,varname:node_4395,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5,max:10;n:type:ShaderForge.SFN_Add,id:7254,x:31926,y:32674,varname:node_7254,prsc:2|A-4057-B,B-2890-B;n:type:ShaderForge.SFN_Multiply,id:6720,x:32107,y:32674,varname:node_6720,prsc:2|A-8664-A,B-7254-OUT;n:type:ShaderForge.SFN_Multiply,id:4509,x:32303,y:33102,varname:node_4509,prsc:2|A-7665-OUT,B-8497-OUT;n:type:ShaderForge.SFN_Vector1,id:8497,x:32303,y:33231,varname:node_8497,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:1835,x:32305,y:32674,varname:node_1835,prsc:2|A-8664-A,B-6720-OUT;n:type:ShaderForge.SFN_Multiply,id:4739,x:32305,y:32792,varname:node_4739,prsc:2|A-7254-OUT,B-9557-OUT;n:type:ShaderForge.SFN_Vector1,id:9557,x:32305,y:32920,varname:node_9557,prsc:2,v1:2;n:type:ShaderForge.SFN_Lerp,id:5856,x:32731,y:32352,varname:node_5856,prsc:2|A-4923-OUT,B-8664-RGB,T-7403-OUT;n:type:ShaderForge.SFN_Tex2d,id:8073,x:32305,y:32288,ptovrint:False,ptlb:Foam,ptin:_Foam,varname:node_8073,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-3295-UVOUT;n:type:ShaderForge.SFN_DepthBlend,id:7403,x:32731,y:32487,varname:node_7403,prsc:2|DIST-2210-OUT;n:type:ShaderForge.SFN_Slider,id:2210,x:32653,y:32664,ptovrint:False,ptlb:Edge Foam,ptin:_EdgeFoam,varname:node_2210,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Panner,id:3295,x:32143,y:32288,varname:node_3295,prsc:2,spu:0.01,spv:0.01|UVIN-1151-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1151,x:31959,y:32288,varname:node_1151,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:4923,x:32731,y:32213,varname:node_4923,prsc:2|A-6094-RGB,B-8073-RGB;n:type:ShaderForge.SFN_Color,id:6094,x:32305,y:32122,ptovrint:False,ptlb:Foam Color,ptin:_FoamColor,varname:node_6094,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;proporder:6937-8664-4395-8073-2210-6094;pass:END;sub:END;*/

Shader "Custom/Water" {
    Properties {
        _RainRef ("RainRef", 2D) = "white" {}
        _WaterColor ("Water Color", Color) = (0,0.6029412,0.6029412,0.1)
        _Tesselation ("Tesselation", Range(0, 10)) = 5
        _Foam ("Foam", 2D) = "black" {}
        _EdgeFoam ("Edge Foam", Range(0, 1)) = 0.5
        _FoamColor ("Foam Color", Color) = (1,1,1,1)
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
            uniform sampler2D _RainRef; uniform float4 _RainRef_ST;
            uniform float4 _WaterColor;
            uniform float _Tesselation;
            uniform sampler2D _Foam; uniform float4 _Foam_ST;
            uniform float _EdgeFoam;
            uniform float4 _FoamColor;
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
                float4 node_7929 = _Time + _TimeEditor;
                float2 node_4348 = (o.uv0+node_7929.g*float2(-0.02,0.01));
                float4 node_4057 = tex2Dlod(_RainRef,float4(TRANSFORM_TEX(node_4348, _RainRef),0.0,0));
                float2 node_5976 = (o.uv0+node_7929.g*float2(0.01,-0.025));
                float4 node_2890 = tex2Dlod(_RainRef,float4(TRANSFORM_TEX(node_5976, _RainRef),0.0,0));
                float2 node_7665 = ((float2(node_4057.r,node_4057.g)+float2(node_2890.r,node_2890.g))*0.01);
                v.vertex.xyz += float3((node_7665*0.5),0.0);
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
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 node_7929 = _Time + _TimeEditor;
                float2 node_4348 = (i.uv0+node_7929.g*float2(-0.02,0.01));
                float4 node_4057 = tex2D(_RainRef,TRANSFORM_TEX(node_4348, _RainRef));
                float2 node_5976 = (i.uv0+node_7929.g*float2(0.01,-0.025));
                float4 node_2890 = tex2D(_RainRef,TRANSFORM_TEX(node_5976, _RainRef));
                float2 node_7665 = ((float2(node_4057.r,node_4057.g)+float2(node_2890.r,node_2890.g))*0.01);
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + node_7665;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_7254 = (node_4057.b+node_2890.b);
                float node_4739 = (node_7254*2.0);
                float3 specularColor = float3(node_4739,node_4739,node_4739);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float2 node_3295 = (i.uv0+node_7929.g*float2(0.01,0.01));
                float4 _Foam_var = tex2D(_Foam,TRANSFORM_TEX(node_3295, _Foam));
                float3 diffuseColor = lerp((_FoamColor.rgb*_Foam_var.rgb),_WaterColor.rgb,saturate((sceneZ-partZ)/_EdgeFoam));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,(_WaterColor.a+(_WaterColor.a*node_7254))),1);
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
            uniform sampler2D _RainRef; uniform float4 _RainRef_ST;
            uniform float4 _WaterColor;
            uniform float _Tesselation;
            uniform sampler2D _Foam; uniform float4 _Foam_ST;
            uniform float _EdgeFoam;
            uniform float4 _FoamColor;
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
                float4 node_5999 = _Time + _TimeEditor;
                float2 node_4348 = (o.uv0+node_5999.g*float2(-0.02,0.01));
                float4 node_4057 = tex2Dlod(_RainRef,float4(TRANSFORM_TEX(node_4348, _RainRef),0.0,0));
                float2 node_5976 = (o.uv0+node_5999.g*float2(0.01,-0.025));
                float4 node_2890 = tex2Dlod(_RainRef,float4(TRANSFORM_TEX(node_5976, _RainRef),0.0,0));
                float2 node_7665 = ((float2(node_4057.r,node_4057.g)+float2(node_2890.r,node_2890.g))*0.01);
                v.vertex.xyz += float3((node_7665*0.5),0.0);
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
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 node_5999 = _Time + _TimeEditor;
                float2 node_4348 = (i.uv0+node_5999.g*float2(-0.02,0.01));
                float4 node_4057 = tex2D(_RainRef,TRANSFORM_TEX(node_4348, _RainRef));
                float2 node_5976 = (i.uv0+node_5999.g*float2(0.01,-0.025));
                float4 node_2890 = tex2D(_RainRef,TRANSFORM_TEX(node_5976, _RainRef));
                float2 node_7665 = ((float2(node_4057.r,node_4057.g)+float2(node_2890.r,node_2890.g))*0.01);
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + node_7665;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_7254 = (node_4057.b+node_2890.b);
                float node_4739 = (node_7254*2.0);
                float3 specularColor = float3(node_4739,node_4739,node_4739);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float2 node_3295 = (i.uv0+node_5999.g*float2(0.01,0.01));
                float4 _Foam_var = tex2D(_Foam,TRANSFORM_TEX(node_3295, _Foam));
                float3 diffuseColor = lerp((_FoamColor.rgb*_Foam_var.rgb),_WaterColor.rgb,saturate((sceneZ-partZ)/_EdgeFoam));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * (_WaterColor.a+(_WaterColor.a*node_7254)),0);
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
            uniform sampler2D _RainRef; uniform float4 _RainRef_ST;
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
                float4 node_7130 = _Time + _TimeEditor;
                float2 node_4348 = (o.uv0+node_7130.g*float2(-0.02,0.01));
                float4 node_4057 = tex2Dlod(_RainRef,float4(TRANSFORM_TEX(node_4348, _RainRef),0.0,0));
                float2 node_5976 = (o.uv0+node_7130.g*float2(0.01,-0.025));
                float4 node_2890 = tex2Dlod(_RainRef,float4(TRANSFORM_TEX(node_5976, _RainRef),0.0,0));
                float2 node_7665 = ((float2(node_4057.r,node_4057.g)+float2(node_2890.r,node_2890.g))*0.01);
                v.vertex.xyz += float3((node_7665*0.5),0.0);
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
