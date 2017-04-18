namespace Syphon
{
    public sealed class Level
    {
        public Level(string id, string name, int value)
        {
            Id = id;
            Name = name;
            Value = value;
        }

        public string Id { get; }
        public string Name { get; }
        internal int Value { get; }

        public static Level L1 { get; } = new Level("L1", "Ааа!!!", 2);
        public static Level L2 { get; } = new Level("L2", "Злой Челябинский мужик", 10);
        public static Level L3 { get; } = new Level("L3", "Злая бабка", 20);
        public static Level L4 { get; } = new Level("L4", "Слесарь-фрезеровщик", 50);
        public static Level L5 { get; } = new Level("L5", "Каждодневный", 100);
        public static Level L6 { get; } = new Level("L6", "PG-13", 250);
        public static Level L7 { get; } = new Level("L7", "Детский сад", 500);


        public static Level[] All { get; } =
        {
            L1, L2, L3, L4, L5, L6, L7
        };
    }
}
