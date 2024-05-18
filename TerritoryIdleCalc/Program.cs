namespace TerritoryIdleCalc
{
    internal class Driver
    {
        static void Main(string[] args)
        {
            //never higher than 102
            int totalTiles = 0;
            //never higher than 43
            int coastalTiles = 0;

            int quarries = 0;
            int schools = 0;
            int shipyards = 0;
            int pyramids = 0;

            Console.WriteLine("Cromlechis Build Calculator");
            Console.WriteLine("Input your total tiles: ");

            bool inputflag = false;

            while (inputflag == false)
            {
                if (int.TryParse(Console.ReadLine(), out totalTiles))
                {
                    if (totalTiles <= 102 && totalTiles>=4)
                    {
                        inputflag = true;
                    }
                }
                if (inputflag == false)
                {
                    Console.WriteLine("Invalid Input, try again ");
                }
            }

            if (totalTiles>=21)
            {
                coastalTiles = totalTiles-21; //rough math but good enough if the user is selecting tiles properly
            }

            if (coastalTiles >=43)
            {
                coastalTiles = 43;
            }

            int remainder = 2;

            int buildTiles = totalTiles - 2;

            remainder += buildTiles % 4;

            double calcnum = buildTiles / 4;

            calcnum = double.Floor(calcnum);

            quarries = (int)calcnum;
            schools = (int)calcnum;
            shipyards = (int)calcnum;
            pyramids = (int)calcnum - 2;

            bool coastalFlag = false;

            if (shipyards > coastalTiles)
            {
                remainder += (shipyards-coastalTiles);
                shipyards = coastalTiles;
                coastalFlag = true;
            }

            while (remainder > 0)
            {
                if (remainder > 0)
                {
                    quarries++;
                    remainder--;
                }
                if (remainder > 0)
                {
                    schools++;
                    remainder--;
                }
                if (remainder > 0 && coastalFlag == false && (shipyards+1)<=coastalTiles)
                {
                    shipyards++;
                    remainder--;
                }
                if (remainder > 0)
                {
                    pyramids++;
                    remainder--;
                }
            }

            //Console.WriteLine($"Coastal tiles is: {coastalTiles}, Remainder is: {remainder}");

            //Console.WriteLine($"Coastal tiles is: {coastalTiles}");
            Console.WriteLine($"You should use: 1 Forest camp, 1 Temple, {quarries} Quarries, {schools} Schools, {shipyards} Shipyards, {pyramids} Pyramids\n");
            Console.WriteLine("Press any key to exit");
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
        }
    }
}