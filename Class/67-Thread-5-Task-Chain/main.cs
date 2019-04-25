using System;
using System.Threading;
using System.Threading.Tasks;

class MainClass {
  public static void Main (string[] args) {
    Task<string> taskChain = Task<int>.Run( () => { // async처리를 여러 개 묶어 sync처럼 보이게 처리
      Console.WriteLine("1 task");
      Thread.Sleep(100);
      return 100;
    }).ContinueWith(task => {
      Console.WriteLine();
      Console.WriteLine(task.Result); // block
      Console.WriteLine("2 task");
      Thread.Sleep(100);
      return 200;
    }).ContinueWith(task => {
      Console.WriteLine();
      Console.WriteLine(task.Result); // block
      Console.WriteLine("3 task");
      Thread.Sleep(100);
      return 300.ToString();
    });

    Console.WriteLine("in Main");
    Console.WriteLine(taskChain.Result == "300");
  }
}
