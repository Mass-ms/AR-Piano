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
        // 上位12ビットのみを操作するため、下位4ビットをクリア
        value &= 0xFFF0;

        // 上位12ビットを操作するために必要なビット数を正規化
        shiftAmount = shiftAmount % 12;

        // 上位12ビットを左にシフトし、オーバーフローされたビットを取得
        ushort leftBits = (ushort)((value << shiftAmount) & 0xFFF0);
        ushort overflow = (ushort)((value >> (12 - shiftAmount)) & 0xFFF0);

        // シフトされたビットとオーバーフローされたビットを結合し、下位4ビットは0000である
        return (ushort)(leftBits | overflow);
    }

    public static ushort RightRotate12Bits(ushort value, int shiftAmount)
    {
        // 上位12ビットのみを操作するため、下位4ビットをクリア
        value &= 0xFFF0;

        // 上位12ビットを操作するために必要なビット数を正規化
        shiftAmount = shiftAmount % 12;

        // 上位12ビットを右にシフトし、オーバーフローされたビットを取得
        ushort rightBits = (ushort)((value >> shiftAmount) & 0xFFF0);
        ushort overflow = (ushort)((value << (12 - shiftAmount)) & 0xFFF0);

        // シフトされたビットとオーバーフローされたビットを結合し、下位4ビットは0000である
        return (ushort)(rightBits | overflow);
    }
}
