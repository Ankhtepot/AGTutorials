using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;

public class BGMLoader : MonoBehaviour
{
    private string musicFile = "Music\\BGM.mp3";
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MusicPlayer());

    }

    private IEnumerator MusicPlayer()
    {
        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(GetFileLocation(musicFile), AudioType.MPEG))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.ProtocolError)
            {
                print(uwr.error);
            }
            else
            {
                audioSource = gameObject.GetComponent<AudioSource>();
                if (!audioSource)
                {
                    audioSource = gameObject.AddComponent<AudioSource>();
                }
                else if (!audioSource.clip)
                {
                    audioSource.Stop();
                    AudioClip currentClip = audioSource.clip;
                    audioSource.clip = null;
                    currentClip.UnloadAudioData();
                    DestroyImmediate(currentClip, false);
                }

                audioSource.loop = true;
                audioSource.volume = .2f;
                audioSource.clip = DownloadHandlerAudioClip.GetContent(uwr);
                audioSource.Play();

                yield return null;
            }
        }
    }

    private static string GetFileLocation(string relativePath)
    {
        return "file://" + Path.Combine(Application.streamingAssetsPath, relativePath);
    }
}
