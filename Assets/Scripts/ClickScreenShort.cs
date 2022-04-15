using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.XR.ARFoundation;

public class ClickScreenShort : MonoBehaviour
{
	public GameObject Canvas;


	public void TakeSS()
	{

		Canvas.SetActive(false);
		StartCoroutine(TakeScreenshotAndShare());
	}

	private IEnumerator TakeScreenshotAndShare()
	{
		yield return new WaitForEndOfFrame();


		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		// To avoid memory leaks
		Destroy(ss);






		new NativeShare().AddFile(filePath).Share();

		Canvas.SetActive(true);
		//Share on WhatsApp only, if installed (Android only)
		// if (NativeShare.TargetExists("com.whatsapp"))
		//  new NativeShare().AddFile(filePath).AddTarget("com.whatsapp").Share();
	}
}
