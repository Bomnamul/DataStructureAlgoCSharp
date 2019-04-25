using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) { // task 사용 시 main thread 종료안되게 주의, whenall에 taskcollection?
    var p = new CheckPrimerNumber();
    p.AddTask(0, 11);
    p.AddTask(12, 20);
    p.AddTask(21, 1000);
    p.Start();

    int n = p.GetNumberOfPrime();
    Console.WriteLine("#PrimeNumber = " + n);
    Console.WriteLine(n == 168); // 총 갯수
  }
}
// task return type는 array
// 각 부분 callback? callback // Task(lambda, object(array?) lambda에 들어갈 파라미터(시작과 끝)) how to pass param in task
public class CheckPrimerNumber {
  List<Task> taskList = new List<Task>();
  public void AddTask(int start, int end) {
    Task<List<int>> t = new Task<List<int>>( () => {
      List<int> list = new List<int>();
      for (int i = start; i <= end; i++) {
        if (IsPrime(i) == true)
          list.Add(i);
      }
      return list;
    });
    taskList.Add(t);
  }

  public void Start() {
    // this.Start();
  }

  public int GetNumberOfPrime() {
    return -1;
  }

  public static bool IsPrime(int number) {
    if (number < 2)
      return false;
    if (number != 2 && number % 2 == 0)
      return false;
    for (int i = 2; i < number; i++) {
      if (number % i == 0)
        return false;
    }
    return true;
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}

/*
2. Thread

// https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/concepts/async/
// https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/concepts/async/how-to-extend-the-async-walkthrough-by-using-task-whenall

소수(prime number)
2보다 작으면 소수가 아님
짝수는 소수가 아님
i=2부터 number 전까지 i++ i로 나눠서 나머지가 0이면 아님

bool IsPrime(int number)

CheckPrimerNumber p = new CheckPrimerNumber();
  p.AddTask(0, 11);
  p.AddTask(12, 20);
  p.AddTask(21, 1000);
  p.Start();

  int n = p.GetNumberOfPrime();
  Console.WriteLine("#PrimeNumber = " + n);
  Console.WriteLine(n == 168); // 총 갯수
  whenall 써봅시다
*/