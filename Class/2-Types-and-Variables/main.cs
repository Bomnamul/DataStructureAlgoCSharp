using System;

class MainClass {
  enum Animal { MOUSE = -100, CAT, BIRD, DOG = 10, LION }; //enum 열거형 (MOUSE는 -100부터, CAT은 -99, BIRD는 -98, 아무것도 안쓰면 0부터 시작) enum은 그냥 특별한 int로 알아두면 편함.
  public static void Main (string[] args) {
    // Value types(int, float...): 
    Console.WriteLine("\t\tValue types:"); // \t 탭명령어
    int intA = 100;
    Console.WriteLine(intA == 100);
    Console.WriteLine(sizeof(int) == 4); //int type의 크기가 얼마인가? == 4 byte
    byte byteA = 255; //unsigned
    Console.WriteLine(byteA == 255);
    Console.WriteLine(sizeof(byte) == 1);
    sbyte sbyteA = 127; //signed byte -127~127
    // sbyte sbyteA = 128; error !
    Console.WriteLine(sbyteA == 127);
    Console.WriteLine(sizeof(byte) == 1);
    char charA = 'A';
    Console.WriteLine(sizeof(char) == 2); // UNICODE 2 byte ASCII 1 byte
    Console.WriteLine(charA == 'A' && charA == 65); // ASCII A == 065 a == 097 /t == 009
    Console.WriteLine('\t' == 9);
    float floatA = 0.1f; //0.1 => double 8byte , float 4byte, suffix 'f' 필요 왠만하면 double 씁시다.
    Console.WriteLine(floatA != 0.1); // 0.1이랑 0.1f 구분
    Console.WriteLine(floatA == 0.1f); //float 0.1과 double 0.1은 다르다. (해상도의 차이)
    //엔진에서는 조금이라도 아끼려고 float 사용
    Console.WriteLine(sizeof(float) == 4);
    double doubleA = 0.1;
    Console.WriteLine(doubleA == 0.1);
    Console.WriteLine(0.1f > 0.1); // 0.10000... 더 붙음
    Console.WriteLine(sizeof(double) == 8);
    Console.WriteLine((double)0.1f > 0.1); // casting ok 작은 type형태를 큰 type으로 바꿈, 반대는 error
    var someA = 0.1; // == double someA = 0.1 컴파일 시점에 변환
    Console.WriteLine(someA.GetType().ToString() == "System.Double"); //Double Precision : 배정도
    Console.WriteLine(floatA.GetType().ToString() == "System.Single"); //Single Precision
    Console.WriteLine(intA.GetType().ToString() == "System.Int32"); // 32bit
    // Int32 int32A = 100; //이렇게도 사용가능
    Console.WriteLine(byteA.GetType().ToString() == "System.Byte");
    Console.WriteLine(sbyteA.GetType().ToString() == "System.SByte"); // test할때 사용
    decimal decimalA = 10000000000000000.123m; // double보다 큰 실수 (은행에서 사용하는 듯)
    Console.WriteLine(decimalA == 10000000000000000.123m);
    Console.WriteLine(sizeof(decimal) == 16);
    bool boolA = true;
    Console.WriteLine(boolA == true);
    Console.WriteLine(boolA != false);
    Console.WriteLine(sizeof(bool) == 1); // c언어에선 0 false, 나머지 true but c#은 0,1로 명확히 구분

    // enum Animal { MOUSE = -100, CAT, BIRD, DOG = 10, LION }; 로컬 선언 안되지만 보기 편하라고...
    Animal enumA = Animal.DOG; // 정의 : 큰 부류에서 특이한 것, 가질 수 있는 값이 한정된 integer
    Console.WriteLine(enumA); // DOG
    // Console.WriteLine(enumA == "DOG"); error
    Console.WriteLine(enumA == Animal.DOG);
    Console.WriteLine((int)enumA == 10);
    Console.WriteLine((int)Animal.CAT == -99);
    Console.WriteLine((int)Animal.LION == 11);
    Console.WriteLine(enumA.GetType().ToString() == "MainClass+Animal"); //MainClass+Animal 메인클래스 내에 애니멀 타입이 추가됨
    Console.WriteLine(sizeof(Animal) == 4);
    Console.WriteLine(enumA.GetType().IsValueType == true); //IsV... Value 타입인가?

    // Reference Types (객체 클래스...):
    // object
    // string
    // Class C {...}
    // interface I {...} : 규약 (이러이러한 함수를 가져야 한다, 다중상속 하지않기 위함)
    // int[] and int [,]
    // delegate int D(...)
    object obj1 = 10;     // object type은 모든 type의 root라 10을 boxing
    object obj2 = 10;
    int int3 = (int)obj1; // unboxing
    // 대부분 template(generic)으로 처리?
    Console.WriteLine(int3 == 10);
    Console.WriteLine((obj1 == obj2) == false); // 안에 든것은 같지만 false, 단순 레퍼런스 비교, 가르키는 포인터 주소가 다름
    Console.WriteLine(Object.ReferenceEquals(obj1, obj2) == false);
    Console.WriteLine(Object.Equals(obj1, obj2) == true); // Object에 Static하게 Equals 정의
    Console.WriteLine(obj1.Equals(obj2) == true);         // obj1에는 manual?
    Console.WriteLine(obj1.GetType().IsValueType == true);// Why? line:83

    string str1 = "Game";
    string str2 = "Game";
    string str3 = "Academy";
    Console.WriteLine(str1 == str2); // String.Equality(String, String) Operator 구현되어 있어서 true라 나옴
    // https://docs.microsoft.com/en-us/dotnet/api/system.string.op_equality?view=netframework-4.7.2
    Console.WriteLine(str1.GetType().IsValueType == false);
    object objStr = "Daegu";
    Console.WriteLine(objStr.GetType().IsValueType == false); // Boxing되어있는 안에 들어있는 type 기준으로 나옴
    
    Point pointA = new Point(10, 20);
    Point pointB = new Point(30, 40);
    Console.WriteLine( (pointA == pointB) == false ); // reference끼리의 비교
    Point pointC;
    pointC = pointA; // reference를 복사
    Console.WriteLine( (pointA == pointC) ); // Alias
    Console.WriteLine(pointA.GetType().IsValueType == false);
    Console.WriteLine(Object.Equals(pointA, pointC) == true);  // 컴파일단에서 line:90보고 line:104 무시
    Console.WriteLine(Object.Equals(pointA, pointB) == false); // 내용을 비교해보고 싶으면 구현해야 함 line:104에서 구현
    Point pointD = new Point(10, 20);
    Console.WriteLine(Object.Equals(pointA, pointD) == true);
    Console.WriteLine(pointA.Equals(pointD)); // Same as above

    int[] arrayA = new int[2] {1, 2};
    int[] arrayB = new int[2] {
      1,
      2
    };
    Console.WriteLine((arrayA == arrayB) == false);
    Console.WriteLine(arrayA.GetType().IsValueType == false); // reference 타입인지 알아보기 위함
    Console.WriteLine(Object.Equals(arrayA, arrayB) == false);// Equals연산에 reference만 비교

  } // main

  class Point {
    public int x, y;
    public Point(int _x, int _y) {
      x = _x;
      y = _y;
    }

    public override bool Equals(object obj) { // override : object를 무시하고 따로 정의
      Console.WriteLine("Equals()");
      if (obj.GetType() != this.GetType())
        return false;
      Point other = (Point) obj; // unboxing
      return (this.x == other.x) && (this.y == other.y);
    }
    public override int GetHashCode() { // Hash : 지문?, 질문?
      return x ^ y;
    }
  }
}