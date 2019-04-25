using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] array = {5, 10, 7, 21, 15, 34, 2, 1, 29, 36, 12, 15, 0};
    print(MergeSort(array, 0, array.Length - 1).Stringify() == "0 1 2 5 7 10 12 15 15 21 29 34 36");
  }

  public static int[] MergeSort(int[] list, int start, int end) {
    if (start < end) {
      int mid = (start + end) / 2;
      MergeSort(list, start, mid);    // Left
      MergeSort(list, mid + 1, end);  // Right
      Merge(list, start, mid, end);   // Merge
    }
    return list;
  }

  public static void Merge(int[] list, int start, int mid, int end) {
    int[] sorted = new int[list.Length];
    int pos = 0;
    int i = start;
    int j = mid + 1;
    while (i <= mid && j <= end) {    // 좌, 우 비교 후 sorted배열에 삽입
      if (list[i] < list[j]) {
        sorted[pos] = list[i];
        pos++;
        i++;
      } else {
        sorted[pos] = list[j];
        pos++;
        j++;
      }
    }
    while (i <= mid) {                 // 좌측이 남을 경우
      sorted[pos] = list[i];
      pos++;
      i++;
    }
    while (j <= end) {                 // 우측이 남을 경우
      sorted[pos] = list[j];
      pos++;
      j++;
    }
    i = start;                         // list의 시작 위치
    pos = 0;                           // sorted배열의 시작 위치
    while (i <= end) {                 // 정렬된 값을 list의 위치에 집어넣음
      list[i] = sorted[pos];
      i++;
      pos++;
    }
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}

/*
2019.04.08
숙제

1.
Merge Sort
divide and conquer
recursive
분할 정복 결합
https://gmlwjd9405.github.io/2018/05/08/algorithm-merge-sort.html

2. (19. H/W line 169)
linked list
yield return
foreachable

3.
http://theory.stanford.edu/~amitp/GameProgramming/AStarComparison.html
floodfill처럼
naive 하게 (bruteforce)
cost기억 (비용은 1)
못가는 길?
시작 지점 to 목표 지점

4. (55. Algo: Flood Fill...)
8방향?
*/
