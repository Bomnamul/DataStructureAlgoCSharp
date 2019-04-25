using System;

class MainClass{
	public static void Main()	{
		Action<object> print = Console.WriteLine;
		
		Book lor = new Book("The Lord of the Rings", 30000, "J.R.R Tolkien"); // new: memory heap
		Book hobbit = new Book("The Hobbit", 40000, "J.R.R Tolkien");
    // hobbit.title = "djyang";
    // lor, hobbit: Object

    print(Book.count == 2);

    Book[] books = new Book[2]; // reference를 담는 array
    books[0] = lor;
    books[1] = hobbit;

    foreach(var book in books)
      print(book.title + ", " + book.price + ", " + book.author + ", " + book.DiscountedPrice(0.1));
  }
}

public class Book { // template
	public string title; // private string title == string title 앞에 아무것도 없으면 암묵적으로 private
	public int price;
	public string author;
  // field, member var, attribute
  public static int count = 0;
  // 공통된 부분 (count, const...에 사용)
	
	public Book(string _title, int _price, string _author) {
		this.title = _title;
		this.price = _price;
		this.author = _author;
    count++;
	} // 생성자 ctor constructor

  public double DiscountedPrice(double discount) { // Method, Member Function
    return (price - price * discount);
  }
}