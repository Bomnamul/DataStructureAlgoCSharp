using System;

class MainClass {
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World"); // WriteLine한 줄 + 줄바꿈
    Console.WriteLine ();

    Console.WriteLine ("Hello" + " " + "World"); //파라미터 1개
    string s = "Hello" + " " + "World";
    Console.WriteLine (s);

    Console.WriteLine("{0:D} | {0:F}", -123, -123.45f); //0번째 파라미터를 Decimal로 | Float으로
    Console.WriteLine(
      "Decimal {0:D}\n" +
      "Scientific {1:E}\n" + // -1.2345 * 10 **2 부동소수점
      "Fixed Point {1:F}\n" +
      "General {0}\n" + // == {0:G} => 알아서 표현
      "General {1}\n" +
      "Hex {0:X}", //Hex Decimal
      -123, -123.45f);

      string bin = Convert.ToString(5,2); //Convert ToString에서 5라는 수치를 2진수로 바꿈
      Console.WriteLine(bin == "101");
      string hex = Convert.ToString(15, 16);
      Console.WriteLine(hex == "f"); //Test Case
      //Test Driven Development (테스트는 꼭 해볼 것 Test Case가 있어야 확인하기 편함)

  }
}