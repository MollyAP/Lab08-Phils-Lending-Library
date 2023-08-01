using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_08_Library
{
    public class Library : ILibrary
    {
        private Dictionary<string, Book> Storage;

        public Library()
        {
            Storage = new Dictionary<string, Book>();
        }

        public int Count => Storage.Count;

        public void Add(string title, string firstName, string lastName, int numberOfPages)
        {
            Book newBook = new Book(title, $"{firstName} {lastName}", numberOfPages);
            Storage.Add(newBook.Title, newBook);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return Storage.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Book Borrow(string title)
        {
            if (Storage.TryGetValue(title, out Book returnedBook))
            {
                Storage.Remove(title);
                return returnedBook;
            }
            return null;
        }

        public void Return(Book book)
        {
            Storage.Add(book.Title, book);
        }

        public Book Search(string title)
        {
            if (Storage.TryGetValue(title, out Book book))
            {
                return book;
            }
            return null;
        }
    }
}
