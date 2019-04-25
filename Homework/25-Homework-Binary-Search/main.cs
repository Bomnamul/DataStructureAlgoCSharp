// https://www.geeksforgeeks.org/binary-search/

using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] list = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    print(BinarySearch(list, 0, 0, list.Length - 1) == 0);
    print(BinarySearch(list, 7, 0, list.Length - 1) == 7);
    print(BinarySearch(list, 100, 0, list.Length - 1) == -1);

    list = new int[] {8};
    print(BinarySearch(list, 8, 0, list.Length - 1) == 0);
    print(BinarySearch(list, 100, 0, list.Length - 1) == -1);

    int[] list2 = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    print(BinarySearch2(list2, 0, 0, list2.Length - 1) == 0);
    print(BinarySearch2(list2, 7, 0, list2.Length - 1) == 7);
    print(BinarySearch2(list2, 100, 0, list2.Length - 1) == -1);
  }

  public static int BinarySearch(int[] list, int value, int left, int right) {
    if (left > right)
      return -1;
    int mid = (left + right) / 2;
    if (list[mid] == value)
      return mid; // index
    if (list[mid] < value)
      return BinarySearch(list, value, mid + 1, right);
    else
      return BinarySearch(list, value, left, mid - 1);
  }

  public static int BinarySearch2(int[] list, int value, int left, int right) {
    while (left <= right) {
      int mid = (left + right) / 2;
      if (list[mid] == value)
        return mid;
      if (list[mid] < value)
        left = mid + 1;
      else
        right = mid - 1;
    }
    return -1;
  }
}
// recursion 아닌 방법으로도 할 수 있음 (숙제) while 문
