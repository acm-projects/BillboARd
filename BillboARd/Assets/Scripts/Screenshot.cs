using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour
{
    string galleryName = "BillboARd";
    int screenHeightCropped;
    string imageName;
    bool screenshotFinished;

    // Connect to the UI message which will appear when screenshot is taken
    public Image m_ScreenshotMessage;

    private void Start()
    {
        // Set the message to transparent when the app starts
        m_ScreenshotMessage.color = new Color(1, 1, 1, 0);
    }

    public void TakeScreenshot()
    {

        // Test on windows editor only
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            TakeScreenshotAndSaveWindowsTest();
        }

        // Actually runs on the mobile device
        StartCoroutine(TakeScreenshotAndSave());

        // Displays a message to tell user a screenshot was taken
        StartCoroutine(DisplayScreenshotMessage());
    }


    private IEnumerator TakeScreenshotAndSave()
    {
        screenshotFinished = false;
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
        screenshotFinished = true;
    }

    private IEnumerator DisplayScreenshotMessage()
    {
        while(screenshotFinished == false)
        {
            yield return null;
        }

        // Set message to opaque
        m_ScreenshotMessage.color = new Color(1, 1, 1, 1);

        // fade from opaque to transparent
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            m_ScreenshotMessage.color = new Color(1, 1, 1, i);
            yield return null;
        }
        
    }


    private void TakeScreenshotAndSaveWindowsTest()
    {
        screenshotFinished = false;
        ScreenCapture.CaptureScreenshot("C:\\Users\\6henr\\OneDrive - The University of Texas at Dallas\\2020 Spring Semester\\ACM BillboARd\\screenshot.png");
        screenshotFinished = true;
    }

}
