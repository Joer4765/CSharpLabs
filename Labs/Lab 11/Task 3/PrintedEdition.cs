using System;
using System.Windows;

namespace Task_3;

public class PrintedPublication
{
    public string Title { get; set; }
    public string Publisher { get; set; }
    public int Pages { get; set; }
    public int Characters { get; set; }

    public PrintedPublication()
    {
        Console.WriteLine("PrintedPublication created");
    }

    public PrintedPublication(string title, string publisher, int pages, int characters)
    {
        Title = title;
        Publisher = publisher;
        Pages = pages;
        Characters = characters;
        Console.WriteLine("PrintedPublication created with parameters");
    }

    ~PrintedPublication()
    {
        Console.WriteLine("PrintedPublication destroyed");
    }

    public virtual string Show()
    {
        return $"Title: {Title}, \nPublisher: {Publisher}, \nPages: {Pages}\n";
    }
    //
    // public virtual double AdditionalMethod()
    // {
    //     return (double)Characters / Pages;
    // }
}

public class Book : PrintedPublication
{
    public string Author { get; set; }
    public string ISBN { get; set; }

    public Book()
    {
        MessageBox.Show("Book created");
    }

    public Book(string title, string publisher, int pages, int characters, string author, string isbn) : base(title,
        publisher, pages, characters)
    {
        Author = author;
        ISBN = isbn;
        MessageBox.Show("Book created with parameters");
    }

    ~Book()
    {
        MessageBox.Show("Book destroyed");
    }

    public override string Show()
    {
        return base.Show() +  $"Author: {Author},\nISBN: {ISBN}\n";
    }
}

public class Textbook : Book
{
    public string Subject { get; set; }
    public int GradeLevel { get; set; }

    public Textbook()
    {
        MessageBox.Show("Textbook created");
    }

    public Textbook(string title, string publisher, int pages, int characters, string author, string isbn, string subject, int gradeLevel) : base(title, publisher, pages, characters, author, isbn)
    {
        Subject = subject;
        GradeLevel = gradeLevel;
        MessageBox.Show("Textbook created with parameters");
    }

    ~Textbook()
    {
        MessageBox.Show("Textbook destroyed");
    }

    public override string Show()
    {
        return base.Show() + $"Subject: {Subject},\nGrade Level: {GradeLevel}\n";
    }
}

public class Journal : PrintedPublication
{
    public string Editor { get; set; }
    public int Volume { get; set; }
    public int Issue { get; set; }

    public Journal()
    {
        MessageBox.Show("Journal created");
    }

    public Journal(string title, string publisher, int pages, int characters, string editor, int volume, int issue) : base(title, publisher, pages, characters)
    {
        Editor = editor;
        Volume = volume;
        Issue = issue;
        MessageBox.Show("Journal created with parameters");
    }

    ~Journal()
    {
        MessageBox.Show("Journal destroyed");
    }

    public override string Show()
    {
        return base.Show() + $"Editor: {Editor},\n Volume: {Volume},\n Issue: {Issue}\n";
    }
}