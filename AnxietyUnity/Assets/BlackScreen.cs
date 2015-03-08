using UnityEngine;
using System.Collections;

public class BlackScreen : MonoBehaviour {
	public GameObject blackScreen;
	public GameObject countdownText;
	public float countdownTime = 7.0f;

	// Use this for initialization
	void OnEnable(){
		OVRManager.HSWDismissed += FadeOut;
	}

	void OnDisable(){
		OVRManager.HSWDismissed -= FadeOut;
	}

	void FadeOut(){
		StartCoroutine (FadeOutHelper());
	}

	IEnumerator FadeOutHelper(){
		Color color = blackScreen.renderer.material.color;
		while (color.a > 0.0f) {
			color.a -= 0.05f;
			blackScreen.renderer.material.color = color;
			yield return null;
		}

	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		countdownTime -= Time.deltaTime;

		if (countdownTime < 0) {
			FadeOut ();
			countdownTime = 0;
			TextMesh t = (TextMesh)countdownText.GetComponent (typeof(TextMesh));
			t.text = "";
		} else if (countdownTime > 0) {
			TextMesh t = (TextMesh)countdownText.GetComponent (typeof(TextMesh));
			t.text = countdownTime.ToString ("F0");
		}
	}
}
