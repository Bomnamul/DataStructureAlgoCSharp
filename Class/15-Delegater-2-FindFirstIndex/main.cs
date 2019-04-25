using System;

class MainClass {
  public delegate bool Condition(int index, int value); // 저번에 했던 SumIf랑 비슷

  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] scores = {1, 2, 3, 4, 5, 6, 7};
    print(FindFirstIndex(scores, (i, v) => v == 7) == 6);
    print(FindFirstIndex(scores, (i, v) => i > 5 && v == 7) == 6);
    print(FindFirstIndex(scores, (i, v) => v == 0) == -1);
  }

  public static int FindFirstIndex(int[] list, Condition condition) {
    for (int i = 0; i < list.Length; i++) {
      if (condition(i, list[i]))
        return i;
    }
    return -1;
  }
}

/*
숙제4. stack 자료구조 구현?
int type array로 구현
push, pop 동작 확인
testcase 알아서 하셈
*/