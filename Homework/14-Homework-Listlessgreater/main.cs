using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    // List Constructor
    var list = new List<int>();
    var list2 = new List<int>() {8, 3, 2};
    print(list.Stringify() == "");
    print(list2.Stringify() == "8 3 2");
    var list3 = new List<int>(list2);
    print(list3.Stringify() == "8 3 2");
    var list4 = new List<int>(10);
    print(list4.Stringify() == "");

    // List[index]
    int item = list2[1];
    print(item == 3);
    list2[1] = 4;
    print(list2.Stringify() == "8 4 2");

    // List.Add
    list2.Add(5);
    print(list2.Stringify() == "8 4 2 5");

    // List.AddRange
    list2.AddRange(list3);
    print(list2.Stringify() == "8 4 2 5 8 3 2");

    // List.BinarySearch
    var list5 = new List<int>() {1, 3, 4, 6, 7, 9};
    int index = list5.BinarySearch(6);
    print(index == 3);
    index = list5.BinarySearch(6, new MyComparer());
    print(index == 3);
    index = list5.BinarySearch(1, 3, 6, new MyComparer());
    print(index == 3);
    index = list5.BinarySearch(1, 2, 6, new MyComparer());
    print(index == -4);

    // List.Clear
    list5.Clear();
    print(list5.Stringify() == "");
    
    // List.Contains
    bool result = list3.Contains(3);
    print(result == true);
    result = list3.Contains(6);
    print(result == false);

    // List.ConvertAll
    var conv = new Converter<int, decimal>(x => (decimal)(x+1));
    var list6 = list3.ConvertAll<decimal>(conv);
    print(list6.Stringify() == "9 4 3");

    // List.CopyTo
    int[] array = new int[5];
    list3.CopyTo(array);
    print(array.Stringify() == "8 3 2 0 0");
    Array.Clear(array, 0, 5);
    list3.CopyTo(array, 2);
    print(array.Stringify() == "0 0 8 3 2");
    Array.Clear(array, 0, 5);
    list3.CopyTo(1, array, 3, 1);
    print(array.Stringify() == "0 0 0 3 0");

    // List.Exists
    bool result2 = list3.Exists(x => x == 3);
    print(result2 == true);
    result2 = list3.Exists(x => x > 10);
    print(result2 == false);

    // List.Equals

    var listA = new List<int>() {8, 3, 2};
    var listB = listA;
    bool result3 = listA.Equals(listB);
    print(result3 == true);
    listB = new List<int>() {8, 3, 2};
    result3 = listA.Equals(listB);
    print(result3 == false);

    // List.Find
    int item2 = list3.Find(x => x > 2);
    print(item2 == 8);
    item2 = list3.Find(x => x > 10);
    print(item2 == 0);

    // List.FindAll
    var listC = listA.FindAll(x => x > 2);
    print(listC.Stringify() == "8 3");
    listC = listA.FindAll(x => x > 10);
    print(listC.Stringify() == "");

    // List.FindIndex
    var listD = new List<int>() {8, 3, 6, 4, 2};
    int index2 = listD.FindIndex(x => x < 5);
    print(index2 == 1);
    index2 = listD.FindIndex(2, x => x < 5);
    print(index2 == 3);
    index2 = listD.FindIndex(2, 2, x => x < 5);
    print(index2 == 3);
    index2 = listD.FindIndex(2, 2, x => x < 3);
    print(index2 == -1);

    // List.FindLastIndex
    var listE = new List<int>() {2, 4, 6, 3, 8};
    int index3 = listE.FindLastIndex(x => x < 5);
    print(index3 == 3);
    index3 = listE.FindLastIndex(2, x => x < 5);
    print(index3 == 1);
    index3 = listE.FindLastIndex(2, 2, x => x < 5);
    print(index3 == 1);
    index3 = listE.FindLastIndex(2, 2, x => x < 3);
    print(index3 == -1);

    // List.ForEach
    list3.ForEach(x => {Console.Write(x);});
    Console.WriteLine();

    // List.GetRange
    var listF = listD.GetRange(1, 3);
    print(listF.Stringify() == "3 6 4");

    // List.IndexOf
    var listG = new List<int>() {8, 3, 2, 6, 8};
    int index4 = listG.IndexOf(8);
    print(index4 == 0);
    index4 = listG.IndexOf(8, 1);
    print(index4 == 4);
    index4 = listG.IndexOf(3, 1, 2);
    print(index4 == 1);
    index4 = listG.IndexOf(8, 1, 2);
    print(index4 == -1);

    // List.Insert
    listG.Insert(1, 5);
    print(listG.Stringify() == "8 5 3 2 6 8");

    // List.InsertRange
    listG.InsertRange(1, list3);
    print(listG.Stringify() == "8 8 3 2 5 3 2 6 8");

    // List.LastIndexOf
    index4 = listG.LastIndexOf(8);
    print(index4 == 8);
    index4 = listG.LastIndexOf(8, 3);
    print(index4 == 1);
    index4 = listG.LastIndexOf(3, 4, 3);
    print(index4 == 2);
    index4 = listG.LastIndexOf(8, 3, 2);
    print(index4 == -1);

    // List.Remove
    listG.Remove(3);
    print(listG.Stringify() == "8 8 2 5 3 2 6 8");
    
    // List.RemoveAll
    listG.RemoveAll(x => x < 6);
    print(listG.Stringify() == "8 8 6 8");

    // List.RemoveAt
    listG.RemoveAt(2);
    print(listG.Stringify() == "8 8 8");

    // List.RemoveRange
    listG.RemoveRange(1, 2);
    print(listG.Stringify() == "8");

    // List.Reverse
    var listH = new List<int>() {8, 3, 6, 2};
    listH.Reverse();
    print(listH.Stringify() == "2 6 3 8");
    listH.Reverse(1, 2);
    print(listH.Stringify() == "2 3 6 8");

    // List.Sort
    var list7 = new List<int>() {8, 3, 6, 2};
    list7.Sort();
    print(list7.Stringify() == "2 3 6 8");
    list7.Sort((x, y) => y.CompareTo(x));
    print(list7.Stringify() == "8 6 3 2");
    list7.Sort((x, y) => x.CompareTo(y));
    print(list7.Stringify() == "2 3 6 8");
    var list8 = new List<int>() {8, 3, 6, 2, 4, 5};
    list8.Sort(2, 3, new MyComparer());
    print(list8.Stringify() == "8 3 2 4 6 5");

    // List.ToArray
    int[] array2 = list7.ToArray();
    print(array2.Stringify() == "2 3 6 8");
    array2 = list.ToArray();
    print(array2.Stringify() == "");

    // List.TrimExcess
    var list9 = new List<int>(8) {1, 2, 3, 4, 5};
    list9.TrimExcess();
    print(list9.Count == 5);

    // List.TreuForAll
    var list10 = new List<int>() {8, 3, 2};
    bool result4 = list10.TrueForAll(x => x < 10);
    print(result4 == true);
    result4 = list10.TrueForAll(x => x < 5);
    print(result4 == false);
  }
}

public class MyComparer : IComparer<int> {
  public int Compare(int x, int y) {
    return x.CompareTo(y);
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}

// list<t> 다 사용 해보기 testcase