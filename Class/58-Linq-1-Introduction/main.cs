using System;
using System.Collections.Generic;
using System.Linq; 

// ClassExtension처럼 모든 함수에 injection됨
// https://docs.microsoft.com/ko-kr/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2#extension-methods (Extension method 참고)

/* 
* Linq: Language INtegrated Query (언어에 통합된 쿼리)
* 일종의 쿼리 표현식
* Query: 다양한 형태의 Data Source로부터 일관된 방식으로 데이터를 추출하는 표현식
* Data Source: DB, ADO.NET Data sets, .NET Collecitons (IEnumerable한 type 전부)
* IEnumerable<T> type은 모두 Linq 적용이 가능하다 == Queryable type
* 
* Deferred execution: foreach, ToArray(), ToList(), Count(), Max(), Average() ... 즉시 실행
* 컴파일러가 알아서 함수 형식으로 변경시킴
* IEnumerable Extension Method로 정의
* using System.Linq
* class extension으로 구현
*
* 이 모든게 IEnumerable 덕분에 가능 
*/

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    // 1. Data Source
    int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    
    // 2. Query creation: Query syntex
    IEnumerable<int> evens =
      from n in numbers               // data source
      where n%2 == 0                  // filtering
      select n;                       // result type (IEnumerable<int>와 n이 매칭)

    // 3. Query execution: Deferred execution (foreach 전엔 실행 x)
    foreach(int n in evens)
      print(n);

    print(evens);
    print(evens.Stringify() == "2 4 6 8 10"); // String.Join() 어딘가에 foreach가 사용되기에 실행됨

    // 즉시 실행
    print(evens.ToArray().Stringify() == "2 4 6 8 10");
    print(evens.ToList().Stringify() == "2 4 6 8 10");

    // Method syntex
    IEnumerable<int> evens2 = 
      numbers.Where(n => n%2 == 0).Select(n => n); // (where, select는 extension으로 정의)
    print(evens2.Stringify() == "2 4 6 8 10");
    print(evens2);

    List<Student> list = new List<Student> {
      new Student() {Name = "djyang", Height = 175, Scores = new List<int>() {100, 70, 90, 77, 88}},
      new Student() {Name = "Steve", Height = 167, Scores = new List<int>() {77, 60, 90, 77, 55}},
      new Student() {Name = "Brown", Height = 180, Scores = new List<int>() {30, 61, 91, 100, 57}},
      new Student() {Name = "Won", Height = 171, Scores = new List<int>() {100, 100, 91, 100, 100}},
      new Student() {Name = "JJ", Height = 165, Scores = new List<int>() {10, 100, 9, 100, 100}}
    };
    print(list.Stringify() == "djyang Steve Brown Won JJ");
    List<Student> ss1 = list.FindAll(s => s.Height < 175);
    print(ss1.Stringify() == "Steve Won JJ");

    // linq version

    IEnumerable<Student> ss2 = 
              from student in list
              where student.Height < 175
              select student;
    print(ss2.Stringify() == "Steve Won JJ");
    // print(ss2);

    IEnumerable<Student> ss3 = 
              from student in list
              where student.Height < 175
              orderby student.Height // 오름차순
              select student;
    print(ss3.Stringify() == "JJ Steve Won");

    IEnumerable<Student> ss4 = 
              from student in list
              where student.Height < 175
              orderby student.Height descending // 내림차순
              select student;
    print(ss4.Stringify() == "Won Steve JJ");

    IEnumerable<string> ss5 = 
              from student in list
              where student.Height < 175
              orderby student.Height descending // 내림차순
              select student.Name; // string
    print(ss5.Stringify() == "Won Steve JJ");

    var ss6 = 
              from student in list
              where student.Height < 175
              orderby student.Height
              select new {Name = student.Name, InchHeight = student.Height * 0.393};
    print(ss6.Stringify());
    
    var ss6_ = list
               .Where(student => student.Height < 175)
               .OrderBy(student => student.Height)
               .Select(student => new {Name = student.Name, InchHeight = student.Height * 0.393});
    print(ss6_.Stringify());

    print("\n");

    var ct = new {Name = "ctkim", Height = 178};
    print(ct.Name);
    print(ct.GetType().ToString());

    print("\n");

    var ss7 = 
      from s in list
      let totalScore = s.Scores[0] + s.Scores[1] + s.Scores[2] + s.Scores[3] + s.Scores[4]
      select totalScore;
    print(ss7.Stringify() == "425 359 339 491 319");
    double averageScore = ss7.Average();
    print(averageScore == 386.6);
    // https://docs.microsoft.com/ko-kr/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2#extension-methods (Linq가 있으면 Average가 추가됨)
  }
}

public class Student {
  public string Name {get; set;}
  public int Height {get; set;}
  public List<int> Scores {get; set;}
  public override string ToString() {
    return Name;
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}