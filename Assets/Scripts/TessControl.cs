using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Tessellation control.
/// tessellation in forward rendering with shadowcaster pass will have terrible performance
/// So I decide to disable the tessellation in forward rendering mode and you should also inplement this component in each camera.
/// </summary>
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class TessControl : MonoBehaviour {
	Camera cam;
	void Awake(){
		cam = GetComponent<Camera> ();
	}
	/// <summary>
	/// The keyword ENABLE_TESSELLATION will control the hull domain shader
	/// </summary>
	void OnPreRender(){
		if (cam.actualRenderingPath == RenderingPath.DeferredShading) {
			Shader.EnableKeyword ("ENABLE_TESSELLATION");
		} else {
			Shader.DisableKeyword ("ENABLE_TESSELLATION");
		}
	}
}
