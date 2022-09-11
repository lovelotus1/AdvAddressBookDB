using System;
namespace AddressBookSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To AddressBook");
            AddressBookRepo repo = new AddressBookRepo();
            AddressBookModel model = new AddressBookModel();
            repo.GetAllEntries();
        }
    }
}

