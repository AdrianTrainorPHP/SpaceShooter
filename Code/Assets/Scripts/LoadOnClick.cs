using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;

	public void LoadScene (string scene)
	{
		loadingImage.SetActive (true);
		Application.LoadLevel (scene);
	}
}
