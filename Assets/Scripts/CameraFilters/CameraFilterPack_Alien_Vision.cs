///////////////////////////////////////////
//  CameraFilterPack v1.9 - by VETASOFT 2015 ///
///////////////////////////////////////////
using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
[AddComponentMenu ("Camera Filter Pack/Alien/Vision")]
public class CameraFilterPack_Alien_Vision : MonoBehaviour {
#region Variables
public Shader SCShader;
private float TimeX = 1.0f;
private Vector4 ScreenResolution;
private Material SCMaterial;
[Range(0f, 0.5f)]
public float Therma_Variation = 0.5f;
[Range(0f, 1.0f)]
public float Speed = 0.5f;
[Range(0f, 4f)]
private float Burn = 0f;
[Range(0f, 16f)]
private float SceneCut = 1f;
public static float ChangeValue;
public static float ChangeValue2;
public static float ChangeValue3;
public static float ChangeValue4;
#endregion
#region Properties
Material material
{
get
{
if(SCMaterial == null)
{
SCMaterial = new Material(SCShader);
SCMaterial.hideFlags = HideFlags.HideAndDontSave;
}
return SCMaterial;
}
}
#endregion
void Start ()
{
ChangeValue = Therma_Variation;
		ChangeValue2 = Speed;
ChangeValue3 = Burn;
ChangeValue4 = SceneCut;
SCShader = Shader.Find("CameraFilterPack/Alien_Vision");
if(!SystemInfo.supportsImageEffects)
{
enabled = false;
return;
}
}

void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture)
{
if(SCShader != null)
{
TimeX+=Time.deltaTime;
if (TimeX>100)  TimeX=0;
material.SetFloat("_TimeX", TimeX);
material.SetFloat("_Value", Therma_Variation);
			material.SetFloat("_Value2", Speed);
material.SetFloat("_Value3", Burn);
material.SetFloat("_Value4", SceneCut);
material.SetVector("_ScreenResolution",new Vector4(sourceTexture.width,sourceTexture.height,0.0f,0.0f));
Graphics.Blit(sourceTexture, destTexture, material);
}
else
{
Graphics.Blit(sourceTexture, destTexture);
}
}

void OnValidate()
{
		ChangeValue=Therma_Variation;
		ChangeValue2=Speed;
		ChangeValue3=Burn;
		ChangeValue4=SceneCut;
}

void Update ()
{
if (Application.isPlaying)
{
Therma_Variation = ChangeValue;
Speed = ChangeValue2;
Burn = ChangeValue3;
SceneCut = ChangeValue4;
}
#if UNITY_EDITOR
if (Application.isPlaying!=true)
{
SCShader = Shader.Find("CameraFilterPack/Alien_Vision");
}
#endif
}


void OnDisable ()
{
if(SCMaterial)
{
DestroyImmediate(SCMaterial);
}
}
}
