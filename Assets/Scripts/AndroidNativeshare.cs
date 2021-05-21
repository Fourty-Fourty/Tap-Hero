using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AndroidNativeshare : MonoBehaviour
{
public	GameObject sharebutton;

	void  Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
                  SceneManager.LoadScene(1);
	}
	public void TakescreenShoot()
	{ 
			StartCoroutine(TakeSSAndShare());
		sharebutton.SetActive(false);
	}

	private IEnumerator TakeSSAndShare()
	{

		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		// To avoid memory leaks
		Destroy(ss);

		new NativeShare().AddFile(filePath).SetSubject("Download Covid 20").SetText("market://details?id="+Application.productName).Share();

		// Share on WhatsApp only, if installed (Android only)
		//if( NativeShare.TargetExists( "com.whatsapp" ) )
		//	new NativeShare().AddFile( filePath ).SetText( "Hello world!" ).SetTarget( "com.whatsapp" ).Share();
	}

    private void OnApplicationFocus(bool focus)
    {
        if(focus)
        {
			sharebutton.SetActive(true);
		}
    }
}

