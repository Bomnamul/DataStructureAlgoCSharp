using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] array = {10, 4, 35, 9, 0, 6, 13, 22, 7, 9, 28};
    print(QSort(array).Stringify() == "0 4 6 7 9 9 10 13 22 28 35");
  }

  public static int[] QSort(int[] list) { // inplace algorithm (추가적인 메모리 필요 x)
    int result = partition(list);
    // 왼쪽 partition호출, 오른쪽 partition호출
    // left = {list[0] ~ pivot - 1}
    // right = {list[pivot + 1] ~ list[list.Length - 1]}
    partition(left);
    partition(right);
  }

  public static int partition(int[] list) { // 파라미터로 시작 부분과 끝 부분
    int pivot = 0;
    int i = 1;
    int j = list.Length - 1;

    if (list.Length < 2){
      return pivot;
    }
    while (true) {
      while (list[i] <= list[pivot])
        i++;
      while (list[j] >= list[pivot])
        j--;
      if (j < i) {
        break;
      }
      int temp = list[i];
      list[i] = list[j];
      list[j] = temp;
    }
    int temp2 = list[pivot];
    list[pivot] = list[j];
    list[j] = temp2;
    
    return j;
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}

/*
QSort
Pivot을 앞에서 잡을 것
p 보다 큰것을 앞에서부터 찾기
  작은것을 뒤에서부터 찾기
*/
