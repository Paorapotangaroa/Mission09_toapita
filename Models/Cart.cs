using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_toapita.Models
{
    //Model out a shopping cart
    public class Cart
    {
        //It can contain mutiple items so we use a list
        public List<BookItem> Items { get; set; } = new List<BookItem>();
        public virtual void AddItem(Book book, int qty)
        {
            //Check if our item is in the list
            BookItem Item =
                Items.Where(p => p.Book.BookId == book.BookId)
                .FirstOrDefault();
            //If the above query returns null then it isn't in the list so add it
            if(Item == null)
            {
                Items.Add(
                 new BookItem
                 {
                     Book = book,
                     Quantity = qty
                 });
            }
            else
            {
                //if it wasn't null it means they are already ordering that item so just increase the associated qty
                Item.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        } 
        public double CalcTotal()
        {
            //Sum up the quantity times price for each book
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            return sum;
        }
    }

    //Class for line items(Basically just storing what info we need for each line in the list)
    public class BookItem
    {
        [Key]
        [Required]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
