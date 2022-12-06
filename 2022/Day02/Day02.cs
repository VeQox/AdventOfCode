namespace AdventOfCode.Y2022
{
  public class Day02 : Solution<int>
  {
    const int SCORE_WON = 6;
    const int SCORE_DRAW = 3;
    const int SCORE_LOSE = 0;

    enum Outcome
    {
      Lose = 0,
      Draw = 1,
      Win = 2,
    };

    enum Move
    {
      Rock = 1,
      Paper = 2,
      Scissors = 3,
    };

    protected override int PartOne(string[] input)
    {
      int score = 0;

      foreach (string line in input)
      {
        string[] lineSplit = line.Split(' ');

        Move opponent = (Move)lineSplit[0][0] - 'A' + 1;
        Move me = (Move)lineSplit[1][0] - 'X' + 1;

        score += (int)me;
        switch (GetWinner(opponent, me))
        {
          case -1:
            score += SCORE_WON;
            break;
          case 0:
            score += SCORE_DRAW;
            break;
          case 1:
            score += SCORE_LOSE;
            break;
        }
      }

      return score;
    }

    protected override int PartTwo(string[] input)
    {
      int score = 0;

      foreach (string line in input)
      {
        string[] lineSplit = line.Split(' ');

        Move opponent = (Move)lineSplit[0][0] - 'A' + 1;
        Outcome outcome = (Outcome)lineSplit[1][0] - 'X';

        score += (int)outcome * 3;

        if (outcome == Outcome.Lose) score += (int)GetLosingMove(opponent);
        else if (outcome == Outcome.Draw) score += (int)opponent;
        else if (outcome == Outcome.Win) score += (int)GetWinningMove(opponent);
      }

      return score;
    }

    static int GetWinner(Move player1, Move player2)
    {
      if (player1 == player2) return 0;
      return player1 switch
      {
        Move.Rock => player2 == Move.Paper ? -1 : 1,
        Move.Paper => player2 == Move.Scissors ? -1 : 1,
        Move.Scissors => player2 == Move.Rock ? -1 : 1,
        _ => throw new InvalidDataException(nameof(player1))
      };
    }

    static Move GetLosingMove(Move opponent)
    {
      return opponent switch
      {
        Move.Rock => Move.Scissors,
        Move.Paper => Move.Rock,
        Move.Scissors => Move.Paper,
        _ => throw new InvalidDataException(nameof(opponent))
      };
    }

    static Move GetWinningMove(Move opponent)
    {
      return opponent switch
      {
        Move.Rock => Move.Paper,
        Move.Paper => Move.Scissors,
        Move.Scissors => Move.Rock,
        _ => throw new InvalidDataException(nameof(opponent))
      };
    }

    protected override string[] GetInput()
        => File.ReadAllLines(@"2022\Day02\input.txt");
  }
}
