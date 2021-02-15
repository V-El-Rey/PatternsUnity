using UnityEngine;

public class ScoreInterpreter
{
    public static string InterpretateScore(float score)
    {
        if (score < 1) return "0";
        if (score > 1 && score <= 1000) return $"{score}";
        if (score > 1000 && score <= 1000000) return $"{score / 1000}K";
        if (score > 1000000 && score <= 1000000000) return $"{score / 1000000}KK";
        return "You ROCK!";
    }
}
