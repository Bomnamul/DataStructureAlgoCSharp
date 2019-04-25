using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] scores = {1, 1, 1, 2, 3, 3, 3, 3, 4, 4, 5, 5, 5, 5, 5, 5, 5};
    print(FrequencyOf(scores, 1) == 3); // FrequencyOf Test Code
    print(FrequencyOf(scores, 2) == 1);
    print(FrequencyOf(scores, 3) == 4);
    print(FrequencyOf(scores, 4) == 2);
    print(FrequencyOf(scores, 5) == 7);
    print(ValueOfMaxFreq(scores) == 5); // ValueOfMaxFreq Test Code

    int[] arrayA = {1, 3, 5, 7, 9};
    int[] arrayB = {2, 4, 6, 8};
    Console.WriteLine(Stringify(MergeArrays(arrayA, arrayB)) == "1 2 3 4 5 6 7 8 9");

    int[] arrayC = {1, 2, 5, 7, 9};
    int[] arrayD = {2, 4, 6, 8, 10, 11, 12};
    Console.WriteLine(Stringify(MergeArrays(arrayC, arrayD)) == "1 2 2 4 5 6 7 8 9 10 11 12");

    Console.WriteLine(Stringify(MergeArrays(new int[] {}, new int[] {})) == "");
    Console.WriteLine(Stringify(MergeArrays(new int[] {}, new int[] {1, 5, 10})) == "1 5 10");

    Console.WriteLine(Stringify(MergeArrays(new int[] {1, 1, 1}, new int[] {2, 2, 2, 2})) == "1 1 1 2 2 2 2");
  }

  public static int FrequencyOf(int[] list, int a) {
    int count = 0;
    for (int i = 0; i < list.Length; i++) {
      if (a == list[i]) {
        count++;
      }
    }
    return count;
  }

  public static int ValueOfMaxFreq(int[] list) {
    int maxCount = 0;
    int max = 0;
    for (int i = 0; i < list.Length; i++) {
      if (maxCount < FrequencyOf(list, list[i])) {
        maxCount = FrequencyOf(list, list[i]);
        max = list[i];
      }
    }
    return max;
  }

  public static int[] MergeArrays(int[] listA, int[] listB) {
    int[] result = new int[listA.Length + listB.Length];
    int p = 0;
    int q = 0;
    for (int i = 0; i < result.Length; i++) {
      if (p == listA.Length || q == listB.Length) {
        if (p == listA.Length) {
          result[i] = listB[q];
          q++;
        } else {
        result[i] = listA[p];
        p++;
        }
      } else if (listA[p] > listB[q]) {
          result[i] = listB[q];
          q++;
      } else {
          result[i] = listA[p];
          p++;
      }
    }
    return result;
  }

  public static string Stringify(int[] list) {
    return String.Join(" ", list);
  }
}

/*
배열에서 정수가 나온 횟수 FrequencyOf(scores , 1) 함수
1은 몇회
2는 몇회
...

Freq에서 가장 많은 횟수 Max함수


MergeArrays 두 배열을 하나로 합치기
MergeArrays(arrayA, arrayB).Stringify()
1. 소팅된 두 배열 (이후에도 소팅 안하고, 2개의 포인트로 비교하며 저장, 한 쪽이 남으면 모조리 복사)
빈 어레이면 empty 리턴
빈 어레이와 아닌 어레이 합치기
하나 담고 나머지 하나 담기
결과 어레이는 두개를 합친 크기
*/
