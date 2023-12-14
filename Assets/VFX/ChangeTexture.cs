using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ChangeTexture : MonoBehaviour
{
    public VisualEffect visualEffect; // インスペクタから設定
    public Texture[] textures; // 切り替えたいテクスチャのリストをインスペクタから設定
    public int currentTextureIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        visualEffect.SetTexture("Emoticon", textures[currentTextureIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        visualEffect.SetTexture("Emoticon", textures[currentTextureIndex]);
    }
}
