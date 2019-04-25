using System;

delegate int CallBack(int a, int b);

class MainClass {
  static int Sum(int i, int j) {
    Console.WriteLine("Sum");
    return i + j;
  }

  static int Multiply(int i, int j) {
    Console.WriteLine("Multiply");
    return i * j;
  }

  static int Power(int i, int j) {
    Console.WriteLine("Power");
    return (int)Math.Pow((double)i, (double)j); // i ** j
  }

  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

  CallBack cb;
  cb = Sum;
  // print(cb(1, 2) == 3);
  cb += Multiply;
  // print(cb(3, 2) == 6);
  cb += Power;
  // print(cb(3, 2) == 9); // 가장 마지막걸로 나옴

  cb -= Multiply;
  print(cb(3, 2) == 9);
  }
  // ex. 게임에서 이벤트 뿌릴때 사용?
}