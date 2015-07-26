namespace MineSweeper
{
    using System;

    public class PointsSheat
    {
        private string playerName;
        private int points;

        public PointsSheat() 
        {
        }

        public PointsSheat(string playerName, int points)
        {
            this.playerName = playerName;
            this.points = points;
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }

            set
            {
                if (value.Length < 3 || value.Length > 33)
                {
                    throw new ArgumentOutOfRangeException("Player name must be between 3 and 33 characters.");
                }

                this.playerName = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                this.points = value;
            }
        }
    }
}