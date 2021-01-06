using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public struct LevelPiece
{
    public Color color;
    public GameObject prefab;
}

public class LevelLoader : MonoBehaviour
{
    public string levelmap = "Levels\\1.png";

    public LevelPiece[] pieces;
    
    void Start()
    {
        StartCoroutine(LoadLevel());
    }

    public static string GetFileLocation(string relativePath)
    {
        return "File://" + Path.Combine(Application.streamingAssetsPath, relativePath);
    }

    public IEnumerator LoadLevel()
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(GetFileLocation(levelmap)))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                print(uwr.error);
            }
            else
            {
                var loadedTexture = DownloadHandlerTexture.GetContent(uwr);
                var mapsize = new Vector2(loadedTexture.width, loadedTexture.height);
                var maptex = loadedTexture;
                for (int x = 0; x < mapsize.x; x++)
                {
                    for (int y = 0; y < mapsize.y; y++)
                    {
                        Color col = maptex.GetPixel(x, y);
                        foreach (var piece in pieces)
                        {
                            if (col == piece.color)
                            {
                                Instantiate(piece.prefab, transform.position + Vector3.right * x + Vector3.up * y, Quaternion.identity);
                            }
                        }
                    }
                }
            }
        }
    }
}
