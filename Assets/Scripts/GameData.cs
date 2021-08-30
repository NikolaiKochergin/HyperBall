using System;

[Serializable]
class GameData
{
    public int Score => _score;

    private int _score;

    public GameData(int score = 0)
    {
        _score = score;
    }
}

