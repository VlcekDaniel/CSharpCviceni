using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceWars
{
    class Game
    {
        public int NumberOfColumns { get; set; }
        public int NumberOfRows { get; set; }
        public int PlayerTurn { get; set; }
        public int NumberOfDicesPlayer1 { get;set;}
        public int NumberOfDicesPlayer2 { get; set; }
        public Field selectedField { get; set; }

        public Field[,] mapa;
        public bool fieldSelected;
        private int seed;
        private Random random;

        public event UpdatedStatsEventHandler UpdatedStats;
        public delegate void UpdatedStatsEventHandler(object sender, EventArgs e);

        public event UpdatedStatsEventHandler UpdatedWin;
        public delegate void UpdatedWinEventHandler(object sender, EventArgs e);

        public Game(int height, int width, int seed)
        {
            NumberOfColumns = width;
            NumberOfRows = height;
            this.seed = seed;          
            mapa = new Field[NumberOfRows, NumberOfColumns];
            random = new Random(this.seed);
            PlayerTurn = 1;
            GenerateGrid(seed);
        }

        public void GenerateGrid(int seed)
        {                       
                Random random = new Random();
                for (int row = 0; row < NumberOfRows; row++)
                {
                    for (int column = 0; column < NumberOfColumns; column++)
                    {
                        randomField(row, column, random);
                    }
                }
           
            for (int i = 0; i < 20; i++)
            {
                int a = random.Next(0, 10);
                int b = random.Next(0, 10);
                mapa[a, b].FieldType = Field.FieldEnum.wall;
            }
        }

        public bool Attack(Field source, Field target)
        {            
            if (checkCoordinates(source, target)&&source.diceNumber>1)
            {
                Dice dice = new Dice();
                int throwPlayer1 = dice.ThrowDice(source.diceNumber);
                int throwPlayer2 = dice.ThrowDice(target.diceNumber);
                Console.WriteLine($"source: {throwPlayer1} target:{throwPlayer2}");
                Console.WriteLine($"from: {source.Position} to:{target.Position}");
                if (throwPlayer1 > throwPlayer2)
                {                   
                    capture(source, target);
                    (NumberOfDicesPlayer1, NumberOfDicesPlayer2) = CountDices();
                    OnUpdatedStats();
                    checkWin();
                    return true;
                }
                else {
                    source.diceNumber = 1;
                    (NumberOfDicesPlayer1, NumberOfDicesPlayer2) = CountDices();
                    OnUpdatedStats();
                    return false;
                }
            }
            return false;
        }

        private void checkWin() {
            int fields1 = 0;
            int fields2 = 0;
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    if (mapa[i, j].FieldType == Field.FieldEnum.player1) {
                        fields1++;
                    }
                    if (mapa[i, j].FieldType == Field.FieldEnum.player2)
                    {
                        fields2++;
                    }
                }
            }
        }

        private void capture(Field source, Field target)
        {
            target.FieldType = source.FieldType;
            target.diceNumber = source.diceNumber - 1;
            source.diceNumber = 1;
        }

        private bool checkCoordinates(Field source, Field target)
        {
            if (source.Position.Column - 1 == target.Position.Column&& source.Position.Row == target.Position.Row) {
                return true;
            }
            if (source.Position.Column + 1 == target.Position.Column && source.Position.Row == target.Position.Row) {
                return true;
            }
            if (source.Position.Row - 1 == target.Position.Row&& source.Position.Column == target.Position.Column) {
                return true;
            }
            if (source.Position.Row + 1 == target.Position.Row && source.Position.Column == target.Position.Column)
            {
                return true;
            }
            return false;
        }

        private void randomField(int row, int column, Random random)
        {             
            switch (random.Next(0,2))
            {
                case 0:
                    int pom = random.Next(1, 4);
                    mapa[row, column] = new Field(Field.FieldEnum.player1, new Coordinates(row, column),pom );
                    NumberOfDicesPlayer1 += pom;
                    break;
                case 1:
                    pom = random.Next(1, 4);
                    mapa[row, column] = new Field(Field.FieldEnum.player2, new Coordinates(row, column), pom);
                    NumberOfDicesPlayer2 += pom;
                    break;
                case 2:
                    pom = 0;
                    mapa[row, column] = new Field(Field.FieldEnum.wall, new Coordinates(row, column), pom);
                    break;
            }
        }

        public void EndTurn() {

            switch (PlayerTurn)
            {
                case 1:
                    PlayerTurn = 2;
                    break;
                case 2:
                    PlayerTurn = 1;                  
                    break;
            }
            addDices();
            (NumberOfDicesPlayer1, NumberOfDicesPlayer2) = CountDices();
            
            selectedField = null;
            fieldSelected = false;
            OnUpdatedStats();            
        }

        public (int,int) CountDices() {
            NumberOfDicesPlayer1 = 0;
            NumberOfDicesPlayer2 = 0;
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    if (mapa[i, j].FieldType == Field.FieldEnum.player1)
                    {
                        NumberOfDicesPlayer1 += mapa[i, j].diceNumber;
                    }
                    if (mapa[i, j].FieldType == Field.FieldEnum.player2)
                    {
                        NumberOfDicesPlayer2 += mapa[i, j].diceNumber;
                    }
                }
            }
            return (NumberOfDicesPlayer1, NumberOfDicesPlayer2);
        }

        public void OnUpdatedStats()
        {
            UpdatedStatsEventHandler handler = UpdatedStats;
            if (handler != null)
                handler(this, new EventArgs());
        }

            public void OnUpdatedWin(int player)
        {
                UpdatedStatsEventHandler handler = UpdatedWin;
                if (handler != null)
                    handler(this, new EventArgs());
        }

            private void addDices()
        {
            int dices = 0;
            if (PlayerTurn == 1)
            {
                dices = NumberOfDicesPlayer1;
            }
            if (PlayerTurn == 2)
            {
                dices = NumberOfDicesPlayer2;           
            }

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    int pom = random.Next(0, 4);
                    if (PlayerTurn == 1) {

                        // a,b random fields
                        int a = random.Next(0, 10);
                        int b = random.Next(0, 10);
                        if (mapa[a, b].FieldType == Field.FieldEnum.player1)
                        {
                            mapa[a, b].diceNumber += pom;
                            if (mapa[a, b].diceNumber >= 8) {
                                mapa[a, b].diceNumber = 8;
                            }
                            if (pom > dices)
                            {
                                break;
                            }
                        }
                    }
                    if (PlayerTurn == 2)
                    {
                        if (mapa[i, j].FieldType == Field.FieldEnum.player2)
                        {
                            mapa[i, j].diceNumber += pom;
                            if (mapa[i, j].diceNumber >= 8)
                            {
                                mapa[i, j].diceNumber = 8;
                            }
                            if (pom > dices)
                            {
                                break;
                            }
                        }
                    }
                    dices -= pom;
                }
            }
        }
    }
}
