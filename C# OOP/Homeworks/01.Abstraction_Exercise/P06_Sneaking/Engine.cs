namespace P06_Sneaking
{
    using System;

    public class Engine
    {
        static Board board;

        public void Run()
        {
            int size = int.Parse(Console.ReadLine());
            Board board = new Board(size);
            Player player = new Player();
            char[] commands = Console.ReadLine().ToCharArray();
            int[] playerSam = board.FindPlayer();
            player.Row = playerSam[0];
            player.Col = playerSam[1];

            foreach (var command in commands)
            {
                board.EnamiesMoving();
                board.CheckEnemiesAndSam();
                board.MoveSam(command, player);
                board.CheckNikoladze();
            }
            board.PrintMatrix();
        }
    }
}
