// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:783,x:32719,y:32712,varname:node_783,prsc:2|diff-6940-OUT,spec-653-OUT,normal-9133-RGB,emission-2346-OUT,transm-7635-OUT,amdfl-1387-RGB,difocc-7717-B,clip-4815-OUT,tess-817-OUT;n:type:ShaderForge.SFN_Color,id:1079,x:32464,y:32247,ptovrint:False,ptlb:Diffuse Color,ptin:_DiffuseColor,varname:node_1079,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:927,x:32464,y:32415,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4983,x:31284,y:32935,ptovrint:False,ptlb:Clipping Mask 1,ptin:_ClippingMask1,varname:node_4983,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:645,x:32026,y:33209,varname:node_645,prsc:2|A-1352-OUT,B-1692-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1352,x:32026,y:33136,ptovrint:False,ptlb:Clipping Power,ptin:_ClippingPower,varname:node_1352,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Lerp,id:1692,x:31781,y:33105,varname:node_1692,prsc:2|A-4983-B,B-6521-B,T-2160-OUT;n:type:ShaderForge.SFN_Slider,id:2160,x:31205,y:33139,ptovrint:False,ptlb:Phase 2,ptin:_Phase2,varname:node_2160,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:6521,x:31284,y:33246,ptovrint:False,ptlb:Clipping Mask 3,ptin:_ClippingMask3,varname:node_6521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6940,x:32793,y:32377,varname:node_6940,prsc:2|A-1079-RGB,B-927-RGB;n:type:ShaderForge.SFN_Tex2d,id:9133,x:31962,y:32239,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_9133,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:7717,x:31857,y:32922,ptovrint:False,ptlb:AO,ptin:_AO,varname:node_7717,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7635,x:31103,y:32846,varname:node_7635,prsc:2|A-2140-RGB,B-2227-OUT,C-1891-RGB;n:type:ShaderForge.SFN_Tex2d,id:2140,x:30793,y:32672,ptovrint:False,ptlb:Transmission Mask,ptin:_TransmissionMask,varname:node_2140,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:2227,x:30793,y:32868,ptovrint:False,ptlb:Transmission Power,ptin:_TransmissionPower,varname:node_2227,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:5453,x:30925,y:32562,ptovrint:False,ptlb:Emissive Mask,ptin:_EmissiveMask,varname:node_5453,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9270,x:31308,y:32580,varname:node_9270,prsc:2|A-5453-RGB,B-7043-OUT,C-655-RGB;n:type:ShaderForge.SFN_ValueProperty,id:7043,x:31331,y:32761,ptovrint:False,ptlb:Emissive Power,ptin:_EmissivePower,varname:node_7043,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Lerp,id:4815,x:32385,y:33286,varname:node_4815,prsc:2|A-645-OUT,B-2650-OUT,T-9042-OUT;n:type:ShaderForge.SFN_Slider,id:9042,x:32472,y:33486,ptovrint:False,ptlb:Dissolve,ptin:_Dissolve,varname:node_612,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:2650,x:32313,y:33577,varname:node_2650,prsc:2|A-3669-B,B-9656-OUT;n:type:ShaderForge.SFN_Tex2d,id:3669,x:31953,y:33603,ptovrint:False,ptlb:Dissolve Cloud,ptin:_DissolveCloud,varname:node_6116,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector1,id:9656,x:32324,y:33794,varname:node_9656,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Color,id:655,x:31071,y:32649,ptovrint:False,ptlb:Emission Color,ptin:_EmissionColor,varname:node_655,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7784,x:31420,y:31941,ptovrint:False,ptlb:Specular Mask,ptin:_SpecularMask,varname:_SpecularMask_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:680,x:31420,y:32129,ptovrint:False,ptlb:Specular Power,ptin:_SpecularPower,varname:_SpecularPower_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:2728,x:31654,y:32026,varname:node_2728,prsc:2|A-7784-RGB,B-680-OUT;n:type:ShaderForge.SFN_Add,id:653,x:32000,y:31893,varname:node_653,prsc:2|A-774-OUT,B-5420-OUT,C-2728-OUT;n:type:ShaderForge.SFN_Tex2d,id:5561,x:30919,y:31265,ptovrint:False,ptlb:Shine Mask 1,ptin:_ShineMask1,varname:node_3178,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1246,x:30302,y:31825,ptovrint:False,ptlb:Shine Mask 2,ptin:_ShineMask2,varname:_ShineMask2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:3797,x:30528,y:31141,ptovrint:False,ptlb:Color1_1,ptin:_Color1_1,varname:node_8444,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.03448248,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:1656,x:30531,y:30870,ptovrint:False,ptlb:Color1_2,ptin:_Color1_2,varname:_Color2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:2660,x:30930,y:31070,varname:node_2660,prsc:2|A-1059-OUT,B-1656-RGB;n:type:ShaderForge.SFN_Add,id:6314,x:31288,y:31043,varname:node_6314,prsc:2|A-2660-OUT,B-4082-OUT;n:type:ShaderForge.SFN_ViewVector,id:1059,x:30930,y:30859,varname:node_1059,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:4972,x:31216,y:30841,varname:node_4972,prsc:2|IN-1059-OUT;n:type:ShaderForge.SFN_Multiply,id:4082,x:30736,y:31122,varname:node_4082,prsc:2|A-4972-OUT,B-3797-RGB;n:type:ShaderForge.SFN_Multiply,id:348,x:30137,y:31704,varname:node_348,prsc:2|A-8687-OUT,B-9602-RGB;n:type:ShaderForge.SFN_Multiply,id:8608,x:30331,y:31652,varname:node_8608,prsc:2|A-1969-OUT,B-1894-RGB;n:type:ShaderForge.SFN_ViewVector,id:1969,x:30331,y:31441,varname:node_1969,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:8687,x:30617,y:31423,varname:node_8687,prsc:2|IN-1969-OUT;n:type:ShaderForge.SFN_Add,id:4319,x:30674,y:31659,varname:node_4319,prsc:2|A-8608-OUT,B-348-OUT;n:type:ShaderForge.SFN_Color,id:1894,x:29909,y:31575,ptovrint:False,ptlb:Color2_1,ptin:_Color2_1,varname:node_8785,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2000003,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:9602,x:29887,y:31770,ptovrint:False,ptlb:Color2_2,ptin:_Color2_2,varname:node_4479,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.03448272,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:7620,x:30708,y:31858,ptovrint:False,ptlb:Shine 2 Power,ptin:_Shine2Power,varname:node_7620,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:2635,x:31288,y:31213,ptovrint:False,ptlb:Shine 1 Power,ptin:_Shine1Power,varname:node_2635,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:774,x:31518,y:31170,varname:node_774,prsc:2|A-6314-OUT,B-2635-OUT,C-5561-RGB;n:type:ShaderForge.SFN_Multiply,id:5420,x:30907,y:31606,varname:node_5420,prsc:2|A-4319-OUT,B-7620-OUT,C-1246-RGB;n:type:ShaderForge.SFN_Color,id:1891,x:30793,y:32950,ptovrint:False,ptlb:Transmission Color,ptin:_TransmissionColor,varname:node_1891,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Add,id:2346,x:31876,y:32693,varname:node_2346,prsc:2|A-1303-OUT,B-9270-OUT,C-2021-OUT;n:type:ShaderForge.SFN_Multiply,id:2021,x:31308,y:32452,varname:node_2021,prsc:2|A-6266-RGB,B-117-OUT,C-461-RGB;n:type:ShaderForge.SFN_ValueProperty,id:117,x:31308,y:32396,ptovrint:False,ptlb:Emissive 2 Power,ptin:_Emissive2Power,varname:node_117,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Color,id:461,x:31067,y:32352,ptovrint:False,ptlb:Emissive 2 Color,ptin:_Emissive2Color,varname:node_461,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:6266,x:31107,y:32168,ptovrint:False,ptlb:Emissive 2 Mask,ptin:_Emissive2Mask,varname:node_6266,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5664,x:31826,y:32489,ptovrint:False,ptlb:Runes Emissive,ptin:_RunesEmissive,varname:node_5664,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1473,x:32023,y:32540,varname:node_1473,prsc:2|A-5664-RGB,B-2194-OUT,C-590-RGB;n:type:ShaderForge.SFN_Tex2d,id:249,x:31686,y:32354,ptovrint:False,ptlb:Runes Noise,ptin:_RunesNoise,varname:node_249,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4018-UVOUT;n:type:ShaderForge.SFN_Panner,id:4018,x:31594,y:32531,varname:node_4018,prsc:2,spu:0.05,spv:0.05|UVIN-8747-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:2194,x:32023,y:32720,ptovrint:False,ptlb:Rune Emissive Power,ptin:_RuneEmissivePower,varname:node_2194,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:1303,x:32341,y:32551,varname:node_1303,prsc:2|A-1473-OUT,B-249-RGB;n:type:ShaderForge.SFN_Color,id:590,x:32025,y:32380,ptovrint:False,ptlb:Rune Emissive Color,ptin:_RuneEmissiveColor,varname:node_590,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:817,x:32710,y:33226,ptovrint:False,ptlb:Tesselation,ptin:_Tesselation,varname:node_817,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:5;n:type:ShaderForge.SFN_Color,id:1387,x:32288,y:32864,ptovrint:False,ptlb:Ambient,ptin:_Ambient,varname:node_1387,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_TexCoord,id:8747,x:31445,y:32531,varname:node_8747,prsc:2,uv:0;proporder:927-1079-9133-7717-5453-7043-655-1352-4983-6521-2160-2140-1891-2227-9042-3669-7784-680-5561-3797-1656-2635-1246-1894-9602-7620-117-461-6266-5664-249-2194-590-817-1387;pass:END;sub:END;*/

Shader "Characters/NPC_2Side_NihtMod_Old" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _DiffuseColor ("Diffuse Color", Color) = (1,1,1,1)
        _Normal ("Normal", 2D) = "bump" {}
        _AO ("AO", 2D) = "white" {}
        _EmissiveMask ("Emissive Mask", 2D) = "black" {}
        _EmissivePower ("Emissive Power", Float ) = 0
        _EmissionColor ("Emission Color", Color) = (1,1,1,1)
        _ClippingPower ("Clipping Power", Float ) = 1
        _ClippingMask1 ("Clipping Mask 1", 2D) = "white" {}
        _ClippingMask3 ("Clipping Mask 3", 2D) = "white" {}
        _Phase2 ("Phase 2", Range(0, 1)) = 0
        _TransmissionMask ("Transmission Mask", 2D) = "white" {}
        _TransmissionColor ("Transmission Color", Color) = (1,1,1,1)
        _TransmissionPower ("Transmission Power", Float ) = 0
        _Dissolve ("Dissolve", Range(0, 1)) = 0
        _DissolveCloud ("Dissolve Cloud", 2D) = "white" {}
        _SpecularMask ("Specular Mask", 2D) = "white" {}
        _SpecularPower ("Specular Power", Float ) = 0
        _ShineMask1 ("Shine Mask 1", 2D) = "white" {}
        _Color1_1 ("Color1_1", Color) = (0.03448248,0,1,1)
        _Color1_2 ("Color1_2", Color) = (1,0,0,1)
        _Shine1Power ("Shine 1 Power", Float ) = 0
        _ShineMask2 ("Shine Mask 2", 2D) = "white" {}
        _Color2_1 ("Color2_1", Color) = (0.2000003,0,1,1)
        _Color2_2 ("Color2_2", Color) = (0.03448272,1,0,1)
        _Shine2Power ("Shine 2 Power", Float ) = 0
        _Emissive2Power ("Emissive 2 Power", Float ) = 0
        _Emissive2Color ("Emissive 2 Color", Color) = (1,1,1,1)
        _Emissive2Mask ("Emissive 2 Mask", 2D) = "white" {}
        _RunesEmissive ("Runes Emissive", 2D) = "white" {}
        _RunesNoise ("Runes Noise", 2D) = "white" {}
        _RuneEmissivePower ("Rune Emissive Power", Float ) = 0
        _RuneEmissiveColor ("Rune Emissive Color", Color) = (1,1,1,1)
        _Tesselation ("Tesselation", Range(1, 5)) = 1
        _Ambient ("Ambient", Color) = (1,1,1,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            uniform float4 _TimeEditor;
            uniform float4 _DiffuseColor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _ClippingMask1; uniform float4 _ClippingMask1_ST;
            uniform float _ClippingPower;
            uniform float _Phase2;
            uniform sampler2D _ClippingMask3; uniform float4 _ClippingMask3_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            uniform sampler2D _TransmissionMask; uniform float4 _TransmissionMask_ST;
            uniform float _TransmissionPower;
            uniform sampler2D _EmissiveMask; uniform float4 _EmissiveMask_ST;
            uniform float _EmissivePower;
            uniform float _Dissolve;
            uniform sampler2D _DissolveCloud; uniform float4 _DissolveCloud_ST;
            uniform float4 _EmissionColor;
            uniform sampler2D _SpecularMask; uniform float4 _SpecularMask_ST;
            uniform float _SpecularPower;
            uniform sampler2D _ShineMask1; uniform float4 _ShineMask1_ST;
            uniform sampler2D _ShineMask2; uniform float4 _ShineMask2_ST;
            uniform float4 _Color1_1;
            uniform float4 _Color1_2;
            uniform float4 _Color2_1;
            uniform float4 _Color2_2;
            uniform float _Shine2Power;
            uniform float _Shine1Power;
            uniform float4 _TransmissionColor;
            uniform float _Emissive2Power;
            uniform float4 _Emissive2Color;
            uniform sampler2D _Emissive2Mask; uniform float4 _Emissive2Mask_ST;
            uniform sampler2D _RunesEmissive; uniform float4 _RunesEmissive_ST;
            uniform sampler2D _RunesNoise; uniform float4 _RunesNoise_ST;
            uniform float _RuneEmissivePower;
            uniform float4 _RuneEmissiveColor;
            uniform float _Tesselation;
            uniform float4 _Ambient;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                    float2 texcoord1 : TEXCOORD1;
                    float2 texcoord2 : TEXCOORD2;
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
                    o.texcoord1 = v.texcoord1;
                    o.texcoord2 = v.texcoord2;
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
                    v.texcoord1 = vi[0].texcoord1*bary.x + vi[1].texcoord1*bary.y + vi[2].texcoord1*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _ClippingMask1_var = tex2D(_ClippingMask1,TRANSFORM_TEX(i.uv0, _ClippingMask1));
                float4 _ClippingMask3_var = tex2D(_ClippingMask3,TRANSFORM_TEX(i.uv0, _ClippingMask3));
                float4 _DissolveCloud_var = tex2D(_DissolveCloud,TRANSFORM_TEX(i.uv0, _DissolveCloud));
                clip(lerp((_ClippingPower*lerp(_ClippingMask1_var.b,_ClippingMask3_var.b,_Phase2)),(_DissolveCloud_var.b*0.5),_Dissolve) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _ShineMask1_var = tex2D(_ShineMask1,TRANSFORM_TEX(i.uv0, _ShineMask1));
                float4 _ShineMask2_var = tex2D(_ShineMask2,TRANSFORM_TEX(i.uv0, _ShineMask2));
                float4 _SpecularMask_var = tex2D(_SpecularMask,TRANSFORM_TEX(i.uv0, _SpecularMask));
                float3 specularColor = ((((viewDirection*_Color1_2.rgb)+((1.0 - viewDirection)*_Color1_1.rgb))*_Shine1Power*_ShineMask1_var.rgb)+(((viewDirection*_Color2_1.rgb)+((1.0 - viewDirection)*_Color2_2.rgb))*_Shine2Power*_ShineMask2_var.rgb)+(_SpecularMask_var.rgb*_SpecularPower));
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 forwardLight = max(0.0, NdotL );
                float4 _TransmissionMask_var = tex2D(_TransmissionMask,TRANSFORM_TEX(i.uv0, _TransmissionMask));
                float3 backLight = max(0.0, -NdotL ) * (_TransmissionMask_var.rgb*_TransmissionPower*_TransmissionColor.rgb);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += _Ambient.rgb; // Diffuse Ambient Light
                indirectDiffuse += gi.indirect.diffuse;
                float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
                indirectDiffuse *= _AO_var.b; // Diffuse AO
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = (_DiffuseColor.rgb*_Diffuse_var.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _RunesEmissive_var = tex2D(_RunesEmissive,TRANSFORM_TEX(i.uv0, _RunesEmissive));
                float4 node_5775 = _Time + _TimeEditor;
                float2 node_4018 = (i.uv0+node_5775.g*float2(0.05,0.05));
                float4 _RunesNoise_var = tex2D(_RunesNoise,TRANSFORM_TEX(node_4018, _RunesNoise));
                float4 _EmissiveMask_var = tex2D(_EmissiveMask,TRANSFORM_TEX(i.uv0, _EmissiveMask));
                float4 _Emissive2Mask_var = tex2D(_Emissive2Mask,TRANSFORM_TEX(i.uv0, _Emissive2Mask));
                float3 emissive = (((_RunesEmissive_var.rgb*_RuneEmissivePower*_RuneEmissiveColor.rgb)*_RunesNoise_var.rgb)+(_EmissiveMask_var.rgb*_EmissivePower*_EmissionColor.rgb)+(_Emissive2Mask_var.rgb*_Emissive2Power*_Emissive2Color.rgb));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            Cull Off
            
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            uniform float4 _TimeEditor;
            uniform float4 _DiffuseColor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _ClippingMask1; uniform float4 _ClippingMask1_ST;
            uniform float _ClippingPower;
            uniform float _Phase2;
            uniform sampler2D _ClippingMask3; uniform float4 _ClippingMask3_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _TransmissionMask; uniform float4 _TransmissionMask_ST;
            uniform float _TransmissionPower;
            uniform sampler2D _EmissiveMask; uniform float4 _EmissiveMask_ST;
            uniform float _EmissivePower;
            uniform float _Dissolve;
            uniform sampler2D _DissolveCloud; uniform float4 _DissolveCloud_ST;
            uniform float4 _EmissionColor;
            uniform sampler2D _SpecularMask; uniform float4 _SpecularMask_ST;
            uniform float _SpecularPower;
            uniform sampler2D _ShineMask1; uniform float4 _ShineMask1_ST;
            uniform sampler2D _ShineMask2; uniform float4 _ShineMask2_ST;
            uniform float4 _Color1_1;
            uniform float4 _Color1_2;
            uniform float4 _Color2_1;
            uniform float4 _Color2_2;
            uniform float _Shine2Power;
            uniform float _Shine1Power;
            uniform float4 _TransmissionColor;
            uniform float _Emissive2Power;
            uniform float4 _Emissive2Color;
            uniform sampler2D _Emissive2Mask; uniform float4 _Emissive2Mask_ST;
            uniform sampler2D _RunesEmissive; uniform float4 _RunesEmissive_ST;
            uniform sampler2D _RunesNoise; uniform float4 _RunesNoise_ST;
            uniform float _RuneEmissivePower;
            uniform float4 _RuneEmissiveColor;
            uniform float _Tesselation;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                    float2 texcoord1 : TEXCOORD1;
                    float2 texcoord2 : TEXCOORD2;
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
                    o.texcoord1 = v.texcoord1;
                    o.texcoord2 = v.texcoord2;
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
                    v.texcoord1 = vi[0].texcoord1*bary.x + vi[1].texcoord1*bary.y + vi[2].texcoord1*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _ClippingMask1_var = tex2D(_ClippingMask1,TRANSFORM_TEX(i.uv0, _ClippingMask1));
                float4 _ClippingMask3_var = tex2D(_ClippingMask3,TRANSFORM_TEX(i.uv0, _ClippingMask3));
                float4 _DissolveCloud_var = tex2D(_DissolveCloud,TRANSFORM_TEX(i.uv0, _DissolveCloud));
                clip(lerp((_ClippingPower*lerp(_ClippingMask1_var.b,_ClippingMask3_var.b,_Phase2)),(_DissolveCloud_var.b*0.5),_Dissolve) - 0.5);
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
                float4 _ShineMask1_var = tex2D(_ShineMask1,TRANSFORM_TEX(i.uv0, _ShineMask1));
                float4 _ShineMask2_var = tex2D(_ShineMask2,TRANSFORM_TEX(i.uv0, _ShineMask2));
                float4 _SpecularMask_var = tex2D(_SpecularMask,TRANSFORM_TEX(i.uv0, _SpecularMask));
                float3 specularColor = ((((viewDirection*_Color1_2.rgb)+((1.0 - viewDirection)*_Color1_1.rgb))*_Shine1Power*_ShineMask1_var.rgb)+(((viewDirection*_Color2_1.rgb)+((1.0 - viewDirection)*_Color2_2.rgb))*_Shine2Power*_ShineMask2_var.rgb)+(_SpecularMask_var.rgb*_SpecularPower));
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 forwardLight = max(0.0, NdotL );
                float4 _TransmissionMask_var = tex2D(_TransmissionMask,TRANSFORM_TEX(i.uv0, _TransmissionMask));
                float3 backLight = max(0.0, -NdotL ) * (_TransmissionMask_var.rgb*_TransmissionPower*_TransmissionColor.rgb);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = (_DiffuseColor.rgb*_Diffuse_var.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            uniform sampler2D _ClippingMask1; uniform float4 _ClippingMask1_ST;
            uniform float _ClippingPower;
            uniform float _Phase2;
            uniform sampler2D _ClippingMask3; uniform float4 _ClippingMask3_ST;
            uniform float _Dissolve;
            uniform sampler2D _DissolveCloud; uniform float4 _DissolveCloud_ST;
            uniform float _Tesselation;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
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
                    float2 texcoord1 : TEXCOORD1;
                    float2 texcoord2 : TEXCOORD2;
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
                    o.texcoord1 = v.texcoord1;
                    o.texcoord2 = v.texcoord2;
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
                    v.texcoord1 = vi[0].texcoord1*bary.x + vi[1].texcoord1*bary.y + vi[2].texcoord1*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _ClippingMask1_var = tex2D(_ClippingMask1,TRANSFORM_TEX(i.uv0, _ClippingMask1));
                float4 _ClippingMask3_var = tex2D(_ClippingMask3,TRANSFORM_TEX(i.uv0, _ClippingMask3));
                float4 _DissolveCloud_var = tex2D(_DissolveCloud,TRANSFORM_TEX(i.uv0, _DissolveCloud));
                clip(lerp((_ClippingPower*lerp(_ClippingMask1_var.b,_ClippingMask3_var.b,_Phase2)),(_DissolveCloud_var.b*0.5),_Dissolve) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            uniform float4 _TimeEditor;
            uniform float4 _DiffuseColor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _EmissiveMask; uniform float4 _EmissiveMask_ST;
            uniform float _EmissivePower;
            uniform float4 _EmissionColor;
            uniform sampler2D _SpecularMask; uniform float4 _SpecularMask_ST;
            uniform float _SpecularPower;
            uniform sampler2D _ShineMask1; uniform float4 _ShineMask1_ST;
            uniform sampler2D _ShineMask2; uniform float4 _ShineMask2_ST;
            uniform float4 _Color1_1;
            uniform float4 _Color1_2;
            uniform float4 _Color2_1;
            uniform float4 _Color2_2;
            uniform float _Shine2Power;
            uniform float _Shine1Power;
            uniform float _Emissive2Power;
            uniform float4 _Emissive2Color;
            uniform sampler2D _Emissive2Mask; uniform float4 _Emissive2Mask_ST;
            uniform sampler2D _RunesEmissive; uniform float4 _RunesEmissive_ST;
            uniform sampler2D _RunesNoise; uniform float4 _RunesNoise_ST;
            uniform float _RuneEmissivePower;
            uniform float4 _RuneEmissiveColor;
            uniform float _Tesselation;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                    float2 texcoord1 : TEXCOORD1;
                    float2 texcoord2 : TEXCOORD2;
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
                    o.texcoord1 = v.texcoord1;
                    o.texcoord2 = v.texcoord2;
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
                    v.texcoord1 = vi[0].texcoord1*bary.x + vi[1].texcoord1*bary.y + vi[2].texcoord1*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _RunesEmissive_var = tex2D(_RunesEmissive,TRANSFORM_TEX(i.uv0, _RunesEmissive));
                float4 node_2476 = _Time + _TimeEditor;
                float2 node_4018 = (i.uv0+node_2476.g*float2(0.05,0.05));
                float4 _RunesNoise_var = tex2D(_RunesNoise,TRANSFORM_TEX(node_4018, _RunesNoise));
                float4 _EmissiveMask_var = tex2D(_EmissiveMask,TRANSFORM_TEX(i.uv0, _EmissiveMask));
                float4 _Emissive2Mask_var = tex2D(_Emissive2Mask,TRANSFORM_TEX(i.uv0, _Emissive2Mask));
                o.Emission = (((_RunesEmissive_var.rgb*_RuneEmissivePower*_RuneEmissiveColor.rgb)*_RunesNoise_var.rgb)+(_EmissiveMask_var.rgb*_EmissivePower*_EmissionColor.rgb)+(_Emissive2Mask_var.rgb*_Emissive2Power*_Emissive2Color.rgb));
                
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffColor = (_DiffuseColor.rgb*_Diffuse_var.rgb);
                float4 _ShineMask1_var = tex2D(_ShineMask1,TRANSFORM_TEX(i.uv0, _ShineMask1));
                float4 _ShineMask2_var = tex2D(_ShineMask2,TRANSFORM_TEX(i.uv0, _ShineMask2));
                float4 _SpecularMask_var = tex2D(_SpecularMask,TRANSFORM_TEX(i.uv0, _SpecularMask));
                float3 specColor = ((((viewDirection*_Color1_2.rgb)+((1.0 - viewDirection)*_Color1_1.rgb))*_Shine1Power*_ShineMask1_var.rgb)+(((viewDirection*_Color2_1.rgb)+((1.0 - viewDirection)*_Color2_2.rgb))*_Shine2Power*_ShineMask2_var.rgb)+(_SpecularMask_var.rgb*_SpecularPower));
                o.Albedo = diffColor + specColor * 0.125; // No gloss connected. Assume it's 0.5
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
