

class Program
{
    static void Main(string[] args)
    {
     
        // var input = """
        //             L68
        //             L30
        //             R48
        //             L5
        //             R60
        //             L55
        //             L1
        //             L99
        //             R14
        //             L82
        //             """;
        var input = File.ReadAllText("Input.txt");
        Part1(input);
        Part2(input);
    }

    private static void Part1(string input)
    {
        int current = 50;
        int max = 99;
        int min = 0;

        int count = 0;
        foreach (var l in input.Split("\n"))
        {
            char direction = l[0];
            int distance = int.Parse(l[1..]);
            int modDistance = distance % max;
            if (direction == 'L')
            {
                current -= distance;
                
                // current = current % max;
                while (current < min)
                {
                    current = max + current + 1;
                }
                
            }
            else
            {
                current += distance;
                // current = current % max;
                while (current > max)
                {
                    current = current - max - 1;
                }
            }

            Console.WriteLine(current);
            if (current ==0)
               count++;
        }

        Console.WriteLine(count);
    }
    private static void Part2(string input)
    {
        int current = 50;
        int max = 99;
        int min = 0;

        int count = 0;
        foreach (var l in input.Split("\n"))
        {
            Console.WriteLine($"Input is {l}");
            char direction = l[0];
            int distance = int.Parse(l[1..]);

            // count += distance / max;
            if (direction == 'L')
            {
                //TODO:
                //account for if we cross 0 again after adding the modulo distance
                
                current -= distance;
                while (current < min)
                {
                    current = max + current + 1;
                    count++;
                }
                
            }
            else
            {
                current += distance;
                // count += distance / max;
                while (current > max)
                {
                    count++;
                    current = current - max - 1;
                }
            }

            Console.WriteLine($"count={count}");
            Console.WriteLine(current);
            // if (current ==0)
            //     count++;
        }

        Console.WriteLine(count);
    }
}