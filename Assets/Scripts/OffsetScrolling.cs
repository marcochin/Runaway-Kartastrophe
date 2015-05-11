using UnityEngine;
using System.Collections;

public class OffsetScrolling : MonoBehaviour
{
	public int materialIndex = 0;
	public Vector2 uvAnimationRate;
	public string textureName = "_MainTex";
	
	Vector2 uvOffset = Vector2.zero;
	
	void LateUpdate()
	{
		uvOffset += (uvAnimationRate * Time.deltaTime);
		if (renderer.enabled)
		{
			renderer.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
		}
	}

	public void setUvAnimationRate(Vector2 newRate){
		uvAnimationRate = newRate;
	}

	public Vector2 getUvAnimationRate(){
		return uvAnimationRate;
	}
}
