using System;
using System.Collections;
using System.Collections.Generic;


public class Transposer
{
    public static ushort Transpose(ushort value, int shiftAmount)
    {
        if (shiftAmount < 0)
        {
            return LeftRotate12Bits(value, -shiftAmount);
        }
        else
        {
            return RightRotate12Bits(value, shiftAmount);
        }
    }

    public static ushort LeftRotate12Bits(ushort value, int shiftAmount)
    {
        // ���12�r�b�g�݂̂𑀍삷�邽�߁A����4�r�b�g���N���A
        value &= 0xFFF0;

        // ���12�r�b�g�𑀍삷�邽�߂ɕK�v�ȃr�b�g���𐳋K��
        shiftAmount = shiftAmount % 12;

        // ���12�r�b�g�����ɃV�t�g���A�I�[�o�[�t���[���ꂽ�r�b�g���擾
        ushort leftBits = (ushort)((value << shiftAmount) & 0xFFF0);
        ushort overflow = (ushort)((value >> (12 - shiftAmount)) & 0xFFF0);

        // �V�t�g���ꂽ�r�b�g�ƃI�[�o�[�t���[���ꂽ�r�b�g���������A����4�r�b�g��0000�ł���
        return (ushort)(leftBits | overflow);
    }

    public static ushort RightRotate12Bits(ushort value, int shiftAmount)
    {
        // ���12�r�b�g�݂̂𑀍삷�邽�߁A����4�r�b�g���N���A
        value &= 0xFFF0;

        // ���12�r�b�g�𑀍삷�邽�߂ɕK�v�ȃr�b�g���𐳋K��
        shiftAmount = shiftAmount % 12;

        // ���12�r�b�g���E�ɃV�t�g���A�I�[�o�[�t���[���ꂽ�r�b�g���擾
        ushort rightBits = (ushort)((value >> shiftAmount) & 0xFFF0);
        ushort overflow = (ushort)((value << (12 - shiftAmount)) & 0xFFF0);

        // �V�t�g���ꂽ�r�b�g�ƃI�[�o�[�t���[���ꂽ�r�b�g���������A����4�r�b�g��0000�ł���
        return (ushort)(rightBits | overflow);
    }
}
