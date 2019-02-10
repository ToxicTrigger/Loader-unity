using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//author : ToxicTrigger
//인자로 들어온 이름의 스크립트를 찾아 로드합니다.
[ExecuteInEditMode]
public class ScriptLoader : MonoBehaviour
{
    [Tooltip("스크립트를 찾아 로드합니다.")]
    public string ScriptName;
    public bool reset;
    void Start() 
    {
        this.hideFlags = HideFlags.HideInInspector;

        if(ScriptName.equals(""))
        {
            Debug.LogWarning(gameObject.name + " Can't Found " + ScriptName);
        }
        else
        {
            var type = Type.GetType(this.ScriptName);
            // 해당 게임 오브젝트에 원하는 컴포넌트가 있다면 삭제합니다.
            if (reset && gameObject.GetComponent(type) != null)
            {
                DestroyImmediate(gameObject.GetComponent(Type.GetType(this.ScriptName)));
            }
            Component component = null;
            if(gameObject.GetComponent(type) == null)
            {
                component = gameObject.AddComponent(Type.GetType(this.ScriptName));
            }
            
            if (component == null)
            {
                Debug.LogWarning(gameObject.name + " Can't Found " + ScriptName);
            }
            else
            {
                Debug.Log("Loaded " + ScriptName);
            }
        }
    }
    
}
