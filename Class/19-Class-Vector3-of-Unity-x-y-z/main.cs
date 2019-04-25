using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print(Vector3.forward.magnitude == 1f); // (0,0,1) -> 1
    print(Vector3.Magnitude(Vector3.forward) == 1f);

    Vector3 v = -Vector3.one; // operator - 가 call
    // v.magnitude = 0; // error ! (Read Only)
    print(v.x == -1f && v.y == -1f && v.z == -1f);

    Vector3 v2 = Vector3.right + Vector3.up;
    print(v2.x == 1f && v2.y == 1f && v2.z == 0f);

    Vector3 a = new Vector3(2f, 2f, 0f);
    Vector3 b = new Vector3(2f, 0f, 0f);
    print(Vector3.Distance(a, b) == 2f);

  }

  public class Vector3 {
    public static readonly Vector3 zero = new Vector3(0f, 0f, 0f); // class 내부에 쓰는 const(재귀적인 형태일 경우 사용)
    public static readonly Vector3 one = new Vector3(1f, 1f, 1f);
    public static readonly Vector3 forward = new Vector3(0f, 0f, 1f);
    public static readonly Vector3 right = new Vector3(1f, 0f, 0f);
    public static readonly Vector3 up = new Vector3(0f, 1f, 0f);
    // 기억해둡시다 (클래스 내부에 상수 지정);

    public float x{get; set;}
    public float y{get; set;}
    public float z{get; set;}

    public Vector3(float _x, float _y, float _z) { // Engine이라 float 사용
      x = _x; y = _y; z = _z;
    }

    public float magnitude { // 특정 Vecter3 (ex. Vecter3 v)
      get {return Math.Abs((float)Math.Sqrt(x * x + y * y + z * z));} // Math.Sqrt(x * x + y * y + z * z) 피타고라스 , Math.abs: 절대값
    }

    public static float Magnitude(Vector3 a) {
      return Math.Abs((float)Math.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z));
    }

    public static float Distance(Vector3 a, Vector3 b) { // param을 받아서 쓸경우 static
      return (a - b).magnitude;
    }

    public static Vector3 operator+(Vector3 a, Vector3 b) {
      return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static Vector3 operator-(Vector3 a) {
      return new Vector3(-a.x, -a.y, -a.z);
    }

    public static Vector3 operator-(Vector3 a, Vector3 b) {
      return (a + -b);
    }

    // multiplier and angle(내접 연산 이용)
  }
}
