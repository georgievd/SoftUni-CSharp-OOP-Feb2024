using System.Text;
using Collections.Model;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var removeCommandsCount = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            for (int i = 0; i < 3; i++)
            {
                for (int c = 0; c < input.Length; c++)
                {
                    if (i == 0)
                    {
                        var index = IndexToString(addCollection.Add(input[c]));
                        sb.Append(index.ToString() + ' ');
                    }

                    else if (i == 1)
                    {
                        var index = IndexToString(addRemoveCollection.Add(input[c]));
                        sb.Append(index + ' ');
                    }

                    else
                    {
                        var index = IndexToString(myList.Add(input[c]));
                        sb.Append(index + ' ');
                    }
                }

                sb.AppendLine();
            }

            for (int i = 0; i < 2; i++)
            {
                for (int c = 0; c < removeCommandsCount; c++)
                {
                    if (i == 0)
                    {
                        sb.Append(addRemoveCollection.Remove() + ' ');
                    }

                    else
                    {
                        sb.Append(myList.Remove() + ' ');
                    }

                }
                sb.AppendLine();
            }
            Console.Write(sb);

        }

        private static string IndexToString(int index)
        {
            var result = index.ToString();
            return result;
        }

    }
}
