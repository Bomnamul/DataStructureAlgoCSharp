using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Troops hogRider = new Troops(1, "Hog Rider", 4, Card.Rarity.Rare, Card.Type.Troops, "Hog Riderrrrrr!", 800, 160, 1.5, 106, 0, 0, 1, 1);
    Buildings bombTower = new Buildings(1, "Bomb Tower", 4, Card.Rarity.Rare, Card.Type.Buildings, "Defensive Building", 1126, 184, 1.6, 115, 6);
    Spells arrows = new Spells(1, "Arrows", 3, Card.Rarity.Common, Card.Type.Spells, "Arrows pepper a large area", 243, 86, 4);

    int[] array = {1, 5, 3, 4, 9, 7, 2};                    // BubbleSort Testcase
    print(BubbleSort(array).Stringify() == "1 2 3 4 5 7 9");
  }

  public static int[] BubbleSort (int[] list) {             // BubbleSort Method
    for (int i = 0; i < list.Length; i++) {
      for (int j = 1; j <list.Length; j++) {
        if (list[j - 1] > list[j]) {
          int temp = list[j];
          list[j] = list[j - 1];
          list[j - 1] = temp;
        }
      }
    }
    return list;
  }
}

public class Card {
  public enum Rarity {Common, Rare, Epic, Legendary};
  public enum Type {Troops, Spells, Buildings};

  public int level;
  public string name;
  public int cost;
  public Rarity rarity;
  public Type type;
  public string description;
}

public class Troops : Card {
  public int health;
  public int damage;
  public double hitspeed;
  public int dps;
  public int spawndmg;
  public int deathdmg;
  public double range;
  public int count;

  public Troops(int _level, string _name, int _cost, Rarity _Rarity, Type _Type,
                string _description, int _health, int _damage, double _hitspeed, int _dps,
                int _spawndmg, int _deathdmg, double _range, int _count) {

                this.level = _level;
                this.name = _name;
                this.cost = _cost;
                this.rarity = _Rarity;
                this.type = _Type;
                this.description = _description;
                this.health = _health;
                this.damage = _damage;
                this.hitspeed = _hitspeed;
                this.dps = _dps;
                this.spawndmg = _spawndmg;
                this.deathdmg = _deathdmg;
                this.range = _range;
                this.count = _count;
  }
}

public class Buildings : Card {
  public int health;
  public int lifetime;
  public int damage;
  public double hitspeed;
  public int dps;
  public double range;

  public Buildings(int _level, string _name, int _cost, Rarity _Rarity, Type _Type,
                  string _description, int _health, int _damage, double _hitspeed, int _dps,
                  double _range) {

                  this.level = _level;
                  this.name = _name;
                  this.cost = _cost;
                  this.rarity = _Rarity;
                  this.type = _Type;
                  this.description = _description;
                  this.health = _health;
                  this.damage = _damage;
                  this.hitspeed = _hitspeed;
                  this.dps = _dps;
                  this.range = _range;
  }
}

public class Spells : Card {
  public int damage;
  public int crowntowerdmg;
  public double radius;

  public Spells(int _level, string _name, int _cost, Rarity _Rarity, Type _Type,
                string _description, int _damage, int _crowntowerdmg, double _radius) {

                this.level = _level;
                this.name = _name;
                this.cost = _cost;
                this.rarity = _Rarity;
                this.type = _Type;
                this.description = _description;
                this.damage = _damage;
                this.crowntowerdmg = _crowntowerdmg;
                this.radius = _radius;
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) { // 지금은 외워쓰자
    return String.Join(" ", list);
  }
}

/*
숙제1. class 만들기
구현은 안해도되고 함수 정의 (타입도 할 수 있으면 ㄱ)
testcode 에러는 안나게
사진 코스트 
공격 대상 enum?

숙제2. Bubble Sort 구현
*/