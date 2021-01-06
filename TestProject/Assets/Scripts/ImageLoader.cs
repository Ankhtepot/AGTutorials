using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public string customTextureFilename = "Image2.png";
    
    private UnityWebRequest uwr;
    
    public static string GetFileLocation(string relativePath)
    {
        return "file://" + Path.Combine(Application.streamingAssetsPath, relativePath);
    }
    
    public void ChangeImage() 
    {
        StartCoroutine(ChangeImageCo());
    }

    private IEnumerator ChangeImageCo()
    {
        using(uwr = UnityWebRequestTexture.GetTexture(GetFileLocation((customTextureFilename))))
        {
            yield return uwr.SendWebRequest();
            if (uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log((uwr.error));
            }
            else
            {
                gameObject.GetComponent<RawImage>().texture = DownloadHandlerTexture.GetContent(uwr);
            }
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
