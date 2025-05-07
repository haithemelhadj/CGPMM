using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TakePhotos : MonoBehaviour
{
    public void TakePhoto()
    {
        StartCoroutine(TakeAPhoto());
    }
    IEnumerator TakeAPhoto()
    {
        yield return new WaitForEndOfFrame();
        Camera camera = Camera.main;
        int width= Screen.width;
        int height= Screen.height;
        RenderTexture rt = new RenderTexture(width, height, 24);
        camera.targetTexture= rt;

        // The Render Texture in RenderTexture.active is the one
        // that will be read by ReadPixels.
        var currentRT = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;

        // Render the camera's view.
        camera.Render();

        // Make a new texture and read the active Render Texture into it.
        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();

        camera.targetTexture = null;

        // Replace the original active Render Texture.
        RenderTexture.active = currentRT;

        byte[] bytes = image.EncodeToPNG();
        string fileName = DateTime.Now.ToString("yyyyMMdd") + ".png";
        string filepath=Path.Combine(Application.persistentDataPath, fileName);
        Debug.Log(filepath);
        File.WriteAllBytes(filepath, bytes );
        Destroy(rt);
        Destroy(image);
    }
}
