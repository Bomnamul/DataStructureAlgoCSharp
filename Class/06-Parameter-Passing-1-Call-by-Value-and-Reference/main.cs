using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine; //외워둡시다

    int a = 10;
    int b = 20;
    Swap(ref a, ref b); // primtive type
    print(a == 20 && b == 10);

    Point pointA = new Point(10, 20);
    Point pointB = new Point(30, 40);
    Swap(pointA, pointB); // reference type, 함수 오버로딩 발생
    print(pointA.x == 30 && pointA.y == 40);

    // int sum = 0; // = 0이 없으면 input이 없어 에러
    // Sum(10, 20, ref sum);
    // print(sum == 30);

    int sum;
    Sum(10, 20, out sum); // out이랑 ref랑 같지만 output 전용 무조건 결과값을 받아와야함 (ref는 in, out 둘다)
    print(sum == 30);
  }

  // public static void Sum(int a, int b, ref int sum) {
  //   sum = a + b;
  // }

  // The out parameter `sum' must be assigned to before control leaves the current method

  public static void Sum(int a, int b, out int sum) {
    sum = a + b;
  }

  public static void Swap(ref int a,ref int b) { // Call by Value, ref(주소)를 명시해야함
    int temp = a;
    a = b;
    b = temp;
  }

  public static void Swap(Point a, Point b) { // Call by Reference, deep copy
    int x = a.x;
    int y = a.y;
    a.x = b.x;
    a.y = b.y;
    b.x = x;
    b.y = y;
  }

  public class Point { // caution: public, Class : Types and Variables 에서 복사함
    public int x, y;
    public Point(int _x, int _y) {
      x = _x;
      y = _y;
    }

    public override bool Equals(object obj) {
      Console.WriteLine("Equals()");
      if (obj.GetType() != this.GetType())
        return false;
      Point other = (Point) obj;
      return (this.x == other.x) && (this.y == other.y);
    }
    public override int GetHashCode() {
      return x ^ y;
    }
  }
}

/*
Swap
1. double형 Swap(double a, double b) 작성
2. int[]형 Swap(int[] arrayA, int[] arrayB)를 작성 사이즈가 서로 다른 경우 호출자에게 return 해서 실패를 알려줄것
3. Book 클래스 (멤버가 Title, Price) Swap(Book a, Book b) 작성
4. 하나의 int[]를 주어졌을 때 min, max 값을 서로 swap 시키는 SwapMinMax(int[] array)를 작성

출력 필요없음 True만 뜨게할 것
클래스 1개 함수 4개
*/