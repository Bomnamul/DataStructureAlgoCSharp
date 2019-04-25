using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    // 2진수 관련
    print(SByte.MinValue == -128);
    print(SByte.MaxValue == 127); // SByte's Range: -128 ~ 127 (256)

    print(Convert.ToSByte("01111111", 2) == 127);
    print(Convert.ToSByte("01111110", 2) == 126);
    //                ...
    print(Convert.ToSByte("01000000", 2) == 64);
    print(Convert.ToSByte("00100000", 2) == 32);
    print(Convert.ToSByte("00000110", 2) == 6);
    print(Convert.ToSByte("00000010", 2) == 2);
    print(Convert.ToSByte("00000001", 2) == 1);
    print(Convert.ToSByte("00000000", 2) == 0);
    print(Convert.ToSByte("11111111", 2) == -1);
    print(Convert.ToSByte("11111110", 2) == -2);
    print(Convert.ToSByte("11111101", 2) == -3);
    print(Convert.ToSByte("11111100", 2) == -4);
    //                ...
    print(Convert.ToSByte("11100000", 2) == -32);
    print(Convert.ToSByte("11000000", 2) == -64);
    print(Convert.ToSByte("10000001", 2) == -127);
    print(Convert.ToSByte("10000000", 2) == -128);

    // 음수는 2의 보수로 표현 (1의 보수 + 1 == 2의 보수)
    // 음수: 2의 보수법
    // 0000 0001     -> 1111 1110 + 1    -> 1111 1111
    // 1에 대한 2진수    1에 대한 1의 보수    1에 대한 2의 보수 (-1)
    print(              ~1        + 1    == -1);

    print(128 << 1 == 256);   // 1000 0000 << 1 == 1 0000 0000
    print(3 << 1 == 6);       // 0000 0011 << 1 == 0000 0110
    print(64 >> 1 == 32);     // 0100 0000 >> 1 == 0010 0000
    print(-128 >> 1 == -64);  // (1111 1111 1111 1111 1111 1111) 1000 0000 >> 1 == 1100 0000
    print(-128 >> 2 == -32);  // 1000 0000 >> 2 == 1110 0000
    print(-3 >> 1 == -2);     // 1111 1101 >> 1 == 1111 1110 딱 안떨어지는 경우는 가까운 수 (하지만 이런 식으론 잘 안씀)

    uint a = 0; // unsigned라 보수값은 최대값
    print(~a == uint.MaxValue && ~a == 4294967295);
    print(Convert.ToString(~a, 2) == "11111111111111111111111111111111");

    int ia = 0; // signed라 보수값은 -1
    print(~ia == -1);
    print(Convert.ToString(~ia, 2) == "11111111111111111111111111111111");

    byte e = 0xF0 | 0x0F; // 1111 0000 | 0000 1111 == 1111 1111(0xFF), 0x로 시작하면 16진수임을 알려줌
    print(e == 255);
    print((sbyte)e == -1);
  }
}
