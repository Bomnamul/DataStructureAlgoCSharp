using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print(SumIterative(10) == 55);
    print(SumRecursive(10) == 55);

    // 0 1 2 3 4 5 6  7  8 ...
    // 0 1 1 2 3 5 8 13 21 ...
    print(FiboIterative(7) == 13);
    print(FiboRecursive(7) == 13);
  }

  public static int SumIterative(int n) {
    int sum = 0;
    for (int i = 1; i <= n; i++)
      sum += i;
    return sum;
  }

  public static int SumRecursive(int n) {
    if (n < 2)
      return n;
    return SumRecursive(n-1) + n;
  }

  public static int FiboIterative(int n) {
    if (n < 2)
      return n;
    int fibo=0, fibo1=0, fibo2=1;
    for (int i = 2; i <= n; i++) {
      fibo = fibo1 + fibo2;
      fibo1 = fibo2;
      fibo2 = fibo;
    } // 1: 전전, 2: 전
    return fibo;
  }

  public static int FiboRecursive(int n) {
    if (n < 2)
      return n;
    return FiboRecursive(n-1) + FiboRecursive(n-2);
  }

  /* n = 10
  SumRecursive(10-1) + 10
  SumRecursive(9-1) + 9 + 10
  SumRecursive(8-1) + 8 + 9 + 10
  SumRecursive(7-1) + 7 + 8 + 9 + 10
  ...
  1 + 2 + ... + 9 + 10
  return
  (함수 호출 계속 이루어지다가 마지막에 Operator 연산자 실행)

  Iterative 보다 연산이 느리지만 문장이 간결해짐 but naive하게 사용X

  숙제 recursion 1. 이용 문자열 길이 구하기
                 2. 최대값 구하기 (ex. int[]의 최대값)
  */
}
