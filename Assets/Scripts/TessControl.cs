using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Tessellation control.
/// tessellation in forward rendering with shadowcaster pass will have terriblly affect on the performance
/// So I decide to disable the tessellation in forward rendering mode.
/// </summary>
[ExecuteInEditMode]
public class TessControl : MonoBehaviour {

	public void TessellationSwitch(Camera cam){
		if (cam.actualRenderingPath == RenderingPath.DeferredShading) {
			Shader.EnableKeyword ("ENABLE_TESSELLATION");
		} else {
			Shader.DisableKeyword ("ENABLE_TESSELLATION");
		}
	}
	//You should only use tessellation in deferred shading rendering path.
	//Because of the shadowcaster pass's huge performance cost in forward rendering, we disabled tessellation in shadowcaster pass, thus, the tessellation shaders may have errors while using forward rendering path.
	void Awake(){
		Camera.onPreRender += TessellationSwitch;
	}

	void OnDestroy(){
		Camera.onPreRender -= TessellationSwitch;
	}
}
