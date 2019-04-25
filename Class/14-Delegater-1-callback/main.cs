using System;

delegate int CallBack(int a, int b);

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    // 1.
    CallBack cb = new CallBack(Sum); // 함수 포인터를 담는 변수
    // 2.
    CallBack cb2;
    cb2 = Sum;
    print(cb(1, 2) == 3);
    print(cb2(1, 2) == 3);

    cb = delegate(int i, int j) {return i + j;}; // 익명 함수
    print(cb(1, 2) == 3);

    cb = (int i, int j) => {return i + j;};      // 람다식
    print(cb(1, 2) == 3);

    cb = (i, j) => i + j; // 타입 생략, 하나의 문장이라 중괄호 뺌, return문도 생략
    print(cb(1, 2) == 3);
  }

  public static int Sum(int a, int b) { // CallBack과 같은 형태
    return a + b;
  }
}