/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEditor;
using System.Reflection;

public class FTG_AssemblyReferences : MonoBehaviour {

	public static bool IsClassActive(string className)
	{	
		System.Type oneSignal = FindClass(className);

		return oneSignal != null;
	}

	public static System.Type FindClass(string className, string nameSpace = null, string assemblyName = null)
	{
		Assembly[] assemblies = System.AppDomain.CurrentDomain.GetAssemblies ();

		foreach (Assembly asm in assemblies) {
			if (!string.IsNullOrEmpty (assemblyName) && !asm.GetName ().Name.Equals (assemblyName)) {
				continue;
			}

			System.Type[] types = asm.GetTypes ();
			foreach (System.Type t in types) {
				if (t.IsClass && t.Name.Equals (className) && (string.IsNullOrEmpty (nameSpace) || nameSpace.Equals (t.Namespace))) {
					return t;
				}
			}
		}
		return null;
	}

}
