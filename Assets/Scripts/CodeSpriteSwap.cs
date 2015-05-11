using UnityEngine;
using System.Collections;

public class CodeSpriteSwap : MonoBehaviour {

	private Sprite normSprite;
	public Sprite correctSprite;
	private SpriteRenderer sr;

	// Use this for initialization
	void Awake () {
		sr = GetComponent<SpriteRenderer> ();
		normSprite = sr.sprite;
	}

	public void setToNormSprite(){
		sr.sprite = normSprite;
	}

	public void setToGreenSprite(){
		sr.sprite = correctSprite;
	}

	void OnDisable(){
		sr.sprite = normSprite;
	}
}
