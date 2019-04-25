using System;

class MainClass {
  public static void Main (string[] args) {
    Tokens f = new Tokens("this is a sample sentence.", new char[] {' ', '-'});

    foreach (string item in f.Tokenize()) {
      Console.WriteLine(item);
    }
  }
}

public class Tokens {
  string Str { get; set; }
  char[] List { get; set; }

  public Tokens(string str, char[] list) {
    Str = str;
    List = list;
  }

  public string[] Tokenize() {
    string[] split = Str.Split(List);
    return split;
  }
}