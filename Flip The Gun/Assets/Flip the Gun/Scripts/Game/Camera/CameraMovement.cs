/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

public class CameraMovement : MonoBehaviour {

	[Tooltip("How fast camera moves to target")]
	public float smoothSpeed = 0.125f;

	//Default screen width.
	private float horizontalResolution = 550;
	//Gun will be attached to this target.
	private Transform target;
	//Camera position to target.
	private Vector3 offSet;

	void Start()
	{

		//Finding gun object.
        target = GameObject.FindWithTag("GunUI").transform;
		//Setting up camera offset.
		offSet = new Vector3(0,1,-1);
		//Getting screen aspect ratio.
        float currentAspect = (float) Screen.width / (float) Screen.height;
		//Changing size according to screen aspect ratio.
    	Camera.main.orthographicSize = horizontalResolution / currentAspect / 200;

	}

	void LateUpdate () 
	{

		//Setting new destination position.
		Vector3 destinationPos = target.position + offSet;
		//Smoothly changing camera position to destination position.
		Vector3 smoothPos = Vector3.Lerp(transform.position, destinationPos, smoothSpeed);
		//If gun falls down camera stops moving.
		if(transform.position.y < destinationPos.y)
			transform.position = new Vector3(transform.position.x, smoothPos.y, -1);
	}
}
