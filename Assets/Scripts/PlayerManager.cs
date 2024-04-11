public static class PlayerManager
{
    private static int lives = 3; // Default lives value
    private static int score = 0;
    private static int pickups = 0;
    private static float distance = 0;

    public static int Lives
    {
        get { return lives; }
        set { lives = value; }
    }

    public static int Score 
    { 
        get { return score; } 
        set { score = value; } 
    }

    public static float Distance
    {
        get { return distance; }
        set { distance = value; }
    }

    public static int Pickups
    {
        get { return pickups; }
        set { pickups = value; }
    }
    public static void Reset()
    {
        lives = 3;
        score = 0;
        distance = 0;
        pickups = 0;
    }
}
