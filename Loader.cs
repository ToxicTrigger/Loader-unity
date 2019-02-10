using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//author : ToxicTrigger
//해당 컴포넌트는 붙어있는 프리팹의 정보들을 간단히 설정하기 위해 존재합니다. 
[ExecuteInEditMode, RequireComponent(typeof(ScriptLoader), typeof(MeshRenderer), typeof(MeshFilter))]
public class Loader : MonoBehaviour
{
    public bool ResetComponent;
    public string ScriptFile;
    public string MeshFile;

    void Awake()
    {
        var script_loader = gameObject.GetComponent<ScriptLoader>();
        if(script_loader != null) 
        {
            script_loader.reset = this.ResetComponent;
            script_loader.ScriptName = this.ScriptFile;
        }
        else
        {
            Debug.LogWarning("Can't Find " + this.ScriptFile + " File ");
        }

        var mesh_filter = gameObject.GetComponent<MeshFilter>();
        var mesh_rend = gameObject.GetComponent<MeshRenderer>();
        var mesh = Resources.Load<MeshFilter>(MeshFile);
        var rend = Resources.Load<MeshRenderer>(MeshFile);

        // 메시 정보가 없을 경우의 예외처리
        if( mesh_filter != null && mesh != null && rend != null)
        {
            mesh_filter.mesh = mesh.sharedMesh;
            mesh_rend.materials = rend.sharedMaterials;
        }
        else
        {
            Debug.LogWarning("Can't Find " + MeshFile);
        }
    }
}
