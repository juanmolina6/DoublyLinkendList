using DoubleList;

public class Program
{
    public static void Main(string[] args)
    {
        DoubleLinkedList<string> list = new DoubleLinkedList<string>();
        int option;
        do
        {
            Console.WriteLine("\n===== DOUBLY LINKED LIST MENU =====");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Show forward");
            Console.WriteLine("3. Show backward");
            Console.WriteLine("4. Sort descending");
            Console.WriteLine("5. Show mode(s)");
            Console.WriteLine("6. Show graph");
            Console.WriteLine("7. Exists");
            Console.WriteLine("8. Remove one occurrence");
            Console.WriteLine("9. Remove all occurrences");
            Console.WriteLine("10. Clear list");
            Console.WriteLine("0. Exit");
            Console.Write("Enter an option: ");
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        Console.Write("Enter the element to add: ");
                        string element = Console.ReadLine() ?? string.Empty;
                        list.AddInOrder(element);
                        Console.WriteLine("Element added successfully.");
                        break;
                    case 2:
                        Console.WriteLine("Showing list forward:");
                        list.ShowForward();
                        break;
                    case 3:
                        Console.WriteLine("Showing list backward:");
                        list.ShowBackward();
                        break;
                    case 4:
                        list.SortDescending(); 
                        Console.WriteLine("List sorted in descending order.");
                        break;
                    case 5:
                        list.ShowModes();
                        break;
                    case 6:
                        Console.WriteLine("Frequency graph:");
                        list.ShowGraph();
                        break;
                    case 7:
                        Console.Write("Enter the element to search: ");
                        string elementToSearch = Console.ReadLine() ?? string.Empty;
                        list.Exists(elementToSearch);
                        break;
                    case 8:
                        Console.Write("Enter the element to remove: ");
                        string elementToRemove = Console.ReadLine() ?? string.Empty;
                        list.RemoveOne(elementToRemove);
                        break;
                    case 9:
                        Console.Write("Enter the element to remove all occurrences: ");
                        string elementToRemoveAll = Console.ReadLine() ?? string.Empty;
                        list.RemoveAll(elementToRemoveAll);
                        break;
                    case 10:
                        list.ClearList();
                        break;
                    case 0:
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                option = -1;
            }
        } while (option != 0);
    }
}