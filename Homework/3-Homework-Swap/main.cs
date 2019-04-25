using System;

class MainClass {

  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    double a = 3.4;
    double b = 7.5;
    Swap(ref a, ref b);
    print(a == 7.5 && b == 3.4);             // 1. Double Swap - Test Case

    int[] arrayA = new int[] {2, 4, 5, 3, 6, 8, 1, 7};
    int[] arrayB = new int[] {20, 40, 50, 30, 60, 80, 10, 70};
    Swap(arrayA, arrayB);
    print(arrayA[0] == 20);                  // 2. Array Swap - Test Case
    print(arrayA[1] == 40);
    print(arrayA[2] == 50);
    print(arrayA[3] == 30);
    print(arrayA[4] == 60);
    print(arrayA[5] == 80);
    print(arrayA[6] == 10);
    print(arrayA[7] == 70);

    //array를 Stringify(ToString)으로 구현하여 문자열로 보여주고 비교하면 test가 편함. (길이 다를경우, 없을경우 false 출력)

    Book bookA = new Book("Alpha", 10000);
    Book bookB = new Book("Beta", 20000);
    Swap(bookA, bookB);
    print(bookA.Title == "Beta");             // 3. Book Swap - Test Case
    print(bookA.Price == 20000);

    int[] scores = new int[] {3, 8, 5, 6, 2, 4, 7};
    SwapMinMax(scores);
    print(scores[1] == 2);                    // 4. SwapMinMax - Test Case
    print(scores[4] == 8);
  }

  public class Book {
    public string Title;
    public int Price;
    public Book(string _Title, int _Price) {
      Title = _Title;
      Price = _Price;
    }
  }

  public static void Swap(ref double a, ref double b) { // 1. Double Swap
    double temp = a;
    a = b;
    b = temp;
  }

  public static void Swap(int[] a, int[] b) {           // 2. int[] Swap
    if (a.Length == b.Length) {
      int[] temp = new int[a.Length];
      for (int i = 0; i < a.Length; i++) {
        temp[i] = a[i];
        a[i] = b[i];
        b[i] = temp[i];
      }
    }
    return;
  }

  public static void Swap(Book a, Book b) {             // 3. Book Swap
    string tempTitle = a.Title;
    int tempPrice = a.Price;
    a.Title = b.Title;
    a.Price = b.Price;
    b.Title = tempTitle;
    b.Price = tempPrice;
  }

  public static void SwapMinMax(int[] a) {              // 4. SwapMinMax
    int max = 0;
    int maxLocation = 0;
    for (int i = 0; i < a.Length; i++) {
      if (max < a[i]) {
        max = a[i];
        maxLocation = i;
      }
    }
    int min = max;
    int minLocation = 0;
    for (int i = 0; i < a.Length; i++) {
      if (min > a[i]) {
        min = a[i];
        minLocation = i;
      }
    }
    a[minLocation] = max;
    a[maxLocation] = min;
  }
}

/*
Swap
1. double형 Swap(double a, double b) 작성
2. int[]형 Swap(int[] arrayA, int[] arrayB)를 작성 사이즈가 서로 다른 경우 호출자에게 return 해서 실패를 알려줄것
3. Book 클래스 (멤버가 Title, Price) Swap(Book a, Book b) 작성
4. 하나의 int[]를 주어졌을 때 min, max 값을 서로 swap 시키는 SwapMinMax(int[] array)를 작성

  // print(Min(scores) == 1); Homework
  // print(Max(scores) == 8); Homework

5. 근의 공식 구하는 거 함수 형태로 (param passing)

출력 필요없음 True만 뜨게할 것
클래스 1개 함수 4개
*/
