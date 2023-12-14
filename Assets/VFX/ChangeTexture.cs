using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ChangeTexture : MonoBehaviour
{
    public VisualEffect visualEffect; // �C���X�y�N�^����ݒ�
    public Texture[] textures; // �؂�ւ������e�N�X�`���̃��X�g���C���X�y�N�^����ݒ�
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
