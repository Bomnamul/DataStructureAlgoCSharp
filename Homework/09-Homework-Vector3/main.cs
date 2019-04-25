using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print(Vector3.forward.magnitude == 1f); // (0,0,1) -> 1
    print(Vector3.Magnitude(Vector3.forward) == 1f); // 똑같은 연산이지만 mag가 더 편하다

    print((-Vector3.one).ToString() == "-1, -1, -1");

    // Vector3 v = -Vector3.one; // operator - 가 call
    // // v.magnitude = 0; // error ! (Read Only)
    // print(v.x == -1f && v.y == -1f && v.z == -1f);

    print((Vector3.right + Vector3.up).ToString() == "1, 1, 0");
    // Vector3 v2 = Vector3.right + Vector3.up;
    // print(v2.x == 1f && v2.y == 1f && v2.z == 0f);

    Vector3 a = new Vector3(2f, 2f, 0f);
    Vector3 b = new Vector3(2f, 0f, 0f);
    print(Vector3.Distance(a, b) == 2f);

    print((2f * a).ToString() == "4, 4, 0");
    print((a * 2f).ToString() == "4, 4, 0");

    print(b.normalized.ToString() == "1, 0, 0");
    print((3f * b).normalized.ToString() == "1, 0, 0");

    print((a + b).ToString() == "4, 2, 0"); // operator+

    Vector3 m = new Vector3(2f, 1f, 4f);    // multiplier testcode
    print((m * 3).ToString() == "6, 3, 12");

    Vector3 d = new Vector3(3f, 4f, 0f);    // normalized testcode
    print(d.normalized.ToString() == "0.6, 0.8, 0");

    Vector3 ua = new Vector3(1f, 2f, 1f);
    Vector3 va = new Vector3(4f, 3f, 3f);
    print(Vector3.Angle(ua, va));

    print(Vector3.Angle(Vector3.right, Vector3.up) == 90);
    print(Vector3.Angle(a, Vector3.right) == 45);
    print(Vector3.Angle(Vector3.right, a) == 45);
    print(Vector3.Angle(Vector3.right, Vector3.right) == 0);
    print(Vector3.Angle(Vector3.left, Vector3.right) == 180);
    print(Vector3.Angle(Vector3.down, Vector3.right) == 90);

    print(Vector3.Dot(Vector3.right, Vector3.right) == 1);
    print(Vector3.Dot(Vector3.right, Vector3.up) == 0); // 90도 차이 cos theta == 0
    print(Vector3.Dot(Vector3.right, Vector3.left) == -1);

  }

  public class Mathf {
    public static double Rad2Deg = 360 / (2 * Math.PI);
    public static double Deg2Rad = (2 * Math.PI * d) / 360;
  }

  public class Vector3 {
    public static readonly Vector3 zero = new Vector3(0f, 0f, 0f); // class 내부에 쓰는 const(재귀적인 형태일 경우 사용)
    public static readonly Vector3 one = new Vector3(1f, 1f, 1f);
    public static readonly Vector3 forward = new Vector3(0f, 0f, 1f);
    public static readonly Vector3 back = -forward;
    public static readonly Vector3 right = new Vector3(1f, 0f, 0f);
    public static readonly Vector3 left = -right;
    public static readonly Vector3 up = new Vector3(0f, 1f, 0f);
    public static readonly Vector3 down = -up;
    // 기억해둡시다 (클래스 내부에 상수 지정);

    public float x{get; set;}
    public float y{get; set;}
    public float z{get; set;}

    public override string ToString() {
      return $"{x}, {y}, {z}";
    }

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

    public static Vector3 operator*(Vector3 a, float d) { // multiplier
      return new Vector3(a.x * d, a.y * d, a.z * d);
    }

    public static Vector3 operator*(float d, Vector3 a) { // multiplier
      return a * d;
    }

    public static float operator*(Vector3 a, Vector3 b) {
      return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z));
    }

    public static float Dot(Vector3 a, Vector3 b) {
      return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z));
    }

    public Vector3 normalized {                           // normalized
      // get {return new Vector3(x / magnitude, y / magnitude, z / magnitude);}
      get {return this * (1 / this.magnitude);}
    }

    public static float Angle(Vector3 a, Vector3 b) {
      // float cos = (a.normalized * b.normalized); // a, b의 내적값 / 길이
      double radian = Math.Acos(a.normalized * b.normalized); // radian (한바퀴를 PI)
      // 360 : 2*PI = d : r radian의 정의
      // 2 * PI * d = 360 * r
      // d = r * (360 / (2 * PI))
      double angle = radian * Mathf.Rad2Deg;
      /*
      v1 * v2 = cos theta
      acos(v1 * v2) = theta
      arccos(x) = y
      x = cos y
      -1 <= cos x <= 1
      -180 <= y <= 180
      */
      // float angle = arccosine(a.normalizer * b.normalizer)
      // 24.469471

      // return (float)(Math.Acos(Dot(a.normalized, b.normalized)) * Mathf.Rad2Deg);
      
      return (float)angle;
    }

    // multiplier and angle(내적 연산 이용)
    // 벡터를 벡터의 magni로 나누면 1이 나옴 normalizer
  }
}
