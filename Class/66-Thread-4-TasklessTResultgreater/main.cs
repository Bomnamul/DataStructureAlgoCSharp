using System;
using System.Threading;
using System.Threading.Tasks;

class MainClass {
  public static void Main (string[] args) {
    var task = new Task<string>( () => { // 람다 함수: Func<string> delegate // return type이 string
      Thread.Sleep(100);
      Console.WriteLine("in Task");
      return "Task result";
    });
    task.Start();
    Console.WriteLine("in Main");

    Console.WriteLine(task.Result == "Task result"); // Main Thread가 tesk.Result값을 받을 때 까지 Block됨
    // ex: web에서 데이터 받아올때 이런 식으로 사용
  }
}