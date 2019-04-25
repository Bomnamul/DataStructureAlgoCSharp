using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine; // Action은 System에 정의, 함수 포인터를 담음 (Deligate, Callback), 시스템에서 불러씀
    // void Print(object obj);
    // Overloading : 함수명은 같으나 파라미터나 파라미터의 수가 다름

    print("djyang");
    // print("djyang", 1); 안됨

    // int, short   : signed
    // uint, ushort : unsigned
    byte byteA = 255;   // unsinged byte 바이트 기본형이 unsigned, 1111111
    byteA++;            // 1111 1111 + 1 = 1 (0000 0000) 바이트 구간
    print(byteA == 0);  // overflow !!
    byteA--;
    print(byteA == 255);

    int ix = 128;
    print(Convert.ToString(ix, 2) == "10000000"); //최상위 부분은 날아감
    sbyte sy = (sbyte)ix; // casting
    print(sy == -128);    // "10000000" 변한 것은 없지만 작은 단위로 캐스팅해 -128이 됨 (캐스팅시 주의!)
    print(Convert.ToString(sy, 2) == "1111111110000000"); // ToString에 sbyte가 없어서 short로 캐스팅해버림
    print(Convert.ToString((byte)sy, 2) == "10000000");

    float floatA = 0.9f;
    int intA = (int)floatA;
    print(intA == 0);
    float floatB = 1.1f;
    int intB = (int)floatB;
    print(intB == 1);

    print(12345.ToString() == "12345"); // ToString, GetHash, Equals는 object단에 있음
    print(int.Parse("12345") == 12345); // file에 있는 것을 읽으면 보통 String 타입인데 Parse로 변환 (기억해놓을 것)

    float a = 69.6875f;
    double b = (double)a;
    print(a == b);

    // https://www.h-schmidt.net/FloatConverter/IEEE754.html (float 오차 확인)
    const float x = 4.2f; // const : 상수
    // x = 100f; error ! 변수가 아니라 상수 취급, 컴파일 할 때 x를 4.2로 치환해버림
    double y = (double)x;
    print(y < 4.2);
    string strX = String.Format("{0:G9}", x);
    print(strX == "4.19999981");
    print(String.Format("{0}", y) == "4.19999980926514");
    print(y == 4.2f); // 부동소수점은 잠재적으로 에러(정확도의 문제)가 있음, 범위로 비교함 (~보다 크고 ~보다 작다)

    print(4.19999980926514f == 4.2f);
    print(4.1999998f == 4.2f);

    print((double)x * 10);
    int n = (int)(x * 10);
    print(n == 41); // not 42
    double d = 4.2;
    print((int)(d * 10) == 42); // double도 부동소수점이기 때문에 에러의 여지가 있다
    print(String.Format("{0:G9}", d));

    print(4.2 == 4.2000000000000001);
    print(4.2 != 4.200000000000001);

    // float과 double (부동소수점) 사용시 항상 오류가 있다는 것을 유의해야한다
    // 둘 중엔 가능하면 double 사용 or decimal 사용

    print(DiscountedPrice1(100, 0.1f) == 89);
    print(DiscountedPrice2(100, 0.1) == 90);
    print(DiscountedPrice3(100, 0.1) == 90);

  }

  public static int DiscountedPrice1(int fullPrice, float discount) {
    return (int)(fullPrice * (1-discount));
  }
  public static int DiscountedPrice2(int fullPrice, double discount) {
    return (int)(fullPrice * (1-discount));
  }
  public static decimal DiscountedPrice3(int fullPrice, double discount) {
    return (decimal)(fullPrice * (1-discount));
  }

}
