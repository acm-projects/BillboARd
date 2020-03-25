using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour
{
    string galleryName = "BillboARd";
    int screenHeightCropped;
    string imageName;

    public void TakeScreenshot()
    {

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            TakeScreenshotAndSaveWindowsTest();
        }

        StartCoroutine(TakeScreenshotAndSave());

    }


    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        screenHeightCropped = (int)(Screen.height * 0.9f);
        Texture2D ss = new Texture2D(Screen.width, screenHeightCropped, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, (Screen.height - screenHeightCropped), Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        imageName = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        NativeGallery.SaveImageToGallery(ss, galleryName, imageName);

        // To avoid memory leaks
        Destroy(ss);
    }

    private void TakeScreenshotAndSaveWindowsTest()
    {
        ScreenCapture.CaptureScreenshot("C:\\BillboARdScreenshots\\screenshot.png");
    }

}
