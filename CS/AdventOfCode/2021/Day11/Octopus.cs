namespace Day11
{
    public class Octopus
    {
        public int Energy;
        public bool Flashed;
        public int Line;
        public int Index;

        public Octopus(int energy, int line, int index, bool flashed = false)
        {
            Energy = energy;
            Flashed = flashed;
            Line = line;
            Index = index;
        }

        public Octopus(Octopus input)
        {
            Energy = input.Energy + 1;
            Flashed = input.Flashed;
            Line = input.Line;
            Index = input.Index;
        }

    }
}