using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DiceWars.Field;

namespace DiceWars
{
    class Renderer
    {
        
        public Game Game { get; private set; }
        public Coordinates mouseCursorCoordinates;
        public Renderer(Game game) {
            Game = game;
            mouseCursorCoordinates = new Coordinates(0, 0);
            Game.fieldSelected = false;
        }     

        public void SetRendererTarget(Panel targetPanel)
        {
            targetPanel.Paint += TargetPanel_Paint;
            targetPanel.MouseMove += TargetPanel_MouseMove;
            targetPanel.MouseClick += TargetPanel_MouseClick;           
        }

        private void TargetPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (Game.fieldSelected == true)
            {
                reselectField();
            }
            else
            {
               Game.selectedField = selectField();
            }
        }

        private Field selectField() {
            Field field;
            int Column = mouseCursorCoordinates.Column;
            int Row = mouseCursorCoordinates.Row;
                if (Game.PlayerTurn == 1)
                {
                     field = new Field(Field.FieldEnum.player1, mouseCursorCoordinates);
                    if (Game.mapa[Row, Column].FieldType.Equals(Field.FieldEnum.player1))
                    {
                        field.Position.Column = Column;
                        field.Position.Row = Row;
                        field.diceNumber = Game.mapa[Row, Column].diceNumber;
                        Game.fieldSelected = true;
                        return field;
                }
                    else
                    {
                        return null;
                    }
                }
                else if (Game.PlayerTurn == 2)
                {
                field = new Field(Field.FieldEnum.player2, mouseCursorCoordinates);
                if (Game.mapa[Row, Column].FieldType.Equals(Field.FieldEnum.player2))
                {
                    field.Position.Column = Column;
                    field.Position.Row = Row;
                    field.diceNumber = Game.mapa[Row, Column].diceNumber;
                    Game.fieldSelected = true;
                    return field;
                }
                else
                    {
                        return null;
                    }
                }
            Game.fieldSelected = true;                  
            return null;
        }

        private Field reselectField()
        {
            int Column = mouseCursorCoordinates.Column;
            int Row = mouseCursorCoordinates.Row;
            Field field = Game.mapa[0, 0];
            if (Game.PlayerTurn == 1)
            {
                if (Game.mapa[Row, Column].FieldType.Equals(Field.FieldEnum.player1))
                {
                    Game.selectedField.Position.Column = Column;
                    Game.selectedField.Position.Row = Row;
                }
                else
                {
                    if (Game.mapa[Row, Column].FieldType.Equals(Field.FieldEnum.player2)) { 
                    int ColumnSource = Game.selectedField.Position.Column;
                    int RowSource = Game.selectedField.Position.Row;
                    if (Game.Attack(Game.mapa[RowSource, ColumnSource], Game.mapa[Row, Column]))
                        {
                            field = new Field(Field.FieldEnum.player1, mouseCursorCoordinates);
                            Game.selectedField = field;
                        }
                    }

                }
            }
            else if (Game.PlayerTurn == 2)
            {
                if (Game.mapa[Row, Column].FieldType.Equals(Field.FieldEnum.player2))
                {
                    Game.selectedField.Position.Column = Column;
                    Game.selectedField.Position.Row = Row;
                }
                else
                {
                    int ColumnSource = Game.selectedField.Position.Column;
                    int RowSource = Game.selectedField.Position.Row;
                    if (Game.Attack(Game.mapa[RowSource, ColumnSource], Game.mapa[Row, Column]))
                    {
                        field = new Field(Field.FieldEnum.player2, mouseCursorCoordinates);
                        Game.selectedField = field;
                    }

                }
            }
            return field;
        }
        private void TargetPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            int fieldWidth = panel.Width / Game.NumberOfColumns;
            int fieldHeight = panel.Height / Game.NumberOfRows;
            Coordinates closestCoordinates = new Coordinates();
            double closestDistance = double.MaxValue;

            for (int i = 0; i < Game.NumberOfRows; i++)
            {
                for (int j = 0; j < Game.NumberOfColumns; j++)
                {
                    int x = j * fieldWidth;
                    int y = i * fieldHeight;

                    x += fieldWidth / 2;
                    y += fieldHeight / 2;

                    double distance = (x - e.X) * (x - e.X) + (y - e.Y) * (y - e.Y);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestCoordinates = new Coordinates()
                        {
                            Column = j,
                            Row = i
                        };
                    }
                }
            }
            if (!mouseCursorCoordinates.Equals(closestCoordinates))
            {
                mouseCursorCoordinates = closestCoordinates;
                panel.Refresh();
            }       
        }

        public void TargetPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int fieldWidth = panel.Width/Game.NumberOfColumns;
            int fieldHeight = panel.Height/Game.NumberOfRows;

            Pen blackPen = new Pen(Color.Black, 3);
            Pen yellowPen = new Pen(Color.Yellow, 3);
            Pen greenPen = new Pen(Color.Green, 3);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            for (int i = 0; i < Game.NumberOfRows; i++)
            {
                for (int j = 0; j < Game.NumberOfColumns; j++)
                {
                    int x = j*fieldWidth;
                    int y = i*fieldHeight;

                    FieldEnum fieldType = Game.mapa[i,j].FieldType;
                    string fieldDice = Convert.ToString(Game.mapa[i, j].diceNumber);

                    switch (fieldType)
                    {
                        case FieldEnum.player1:
                            e.Graphics.FillRectangle(blueBrush, x, y, fieldWidth, fieldHeight);
                            break;
                        case FieldEnum.player2:
                            e.Graphics.FillRectangle(redBrush, x, y, fieldWidth, fieldHeight);
                            break;
                        case FieldEnum.wall:
                            e.Graphics.FillRectangle(grayBrush, x, y, fieldWidth, fieldHeight);
                            break;
                        default:
                            break;
                    }
                    e.Graphics.DrawRectangle(blackPen, x, y, fieldWidth, fieldHeight);

                    if (Game.mapa[i, j].FieldType != Field.FieldEnum.wall)
                    {
                        Image image;
                        switch (Game.mapa[i,j].diceNumber)
                        {                                    
                            case 1:
                                image = Image.FromFile(@"Images\dice1.png");
                                e.Graphics.DrawImage(image, x + fieldWidth / 2 - image.Width / 2 + 5, y + fieldHeight / 2 - image.Height / 3 -5, fieldWidth +20  , fieldHeight+20 );
                                break;
                            case 2:
                                image = Image.FromFile(@"Images\dice2.png");
                                e.Graphics.DrawImage(image, x + fieldWidth / 2 - image.Width / 2, y + fieldHeight / 2 - image.Height / 3, fieldWidth , fieldHeight );
                                break;
                            case 3:
                                image = Image.FromFile(@"Images\dice3.png");
                                e.Graphics.DrawImage(image, x + fieldWidth / 2 - image.Width / 2, y + fieldHeight / 2 - image.Height / 3, fieldWidth , fieldHeight );
                                break;
                            case 4:
                                image = Image.FromFile(@"Images\dice4.png");
                                e.Graphics.DrawImage(image, x + fieldWidth / 2 - image.Width / 2, y + fieldHeight / 2 - image.Height / 3, fieldWidth , fieldHeight+2 );
                                break;
                            case 5:
                                image = Image.FromFile(@"Images\dice5.png");
                                e.Graphics.DrawImage(image, x + fieldWidth / 2 - image.Width / 2, y + fieldHeight / 2 - image.Height / 3, fieldWidth - 10, fieldHeight - 10);
                                break;
                            case 6:
                                image = Image.FromFile(@"Images\dice6.png");
                                e.Graphics.DrawImage(image, x + fieldWidth / 2 - image.Width / 2, y + fieldHeight / 2 - image.Height / 3, fieldWidth - 10, fieldHeight - 10);
                                break;
                            case 7:
                                image = Image.FromFile(@"Images\dice7.png");
                                e.Graphics.DrawImage(image, x + fieldWidth / 2 - image.Width / 2, y + fieldHeight / 2 - image.Height / 3, fieldWidth - 10, fieldHeight - 10);
                                break;
                            case 8:
                                image = Image.FromFile(@"Images\dice8.png");
                                e.Graphics.DrawImage(image, x + fieldWidth / 2 - image.Width / 2, y + fieldHeight / 2 - image.Height / 3, fieldWidth - 10, fieldHeight -10);
                                break;
                            default:
                                break;
                        }         
                    }
                }
            }
            int x1 = mouseCursorCoordinates.Column * fieldWidth;
            int y1 = mouseCursorCoordinates.Row * fieldHeight;
            e.Graphics.DrawRectangle(yellowPen, x1, y1, fieldWidth, fieldHeight);
            if (Game.selectedField != null)
            {
                e.Graphics.DrawRectangle(greenPen, Game.selectedField.Position.Column * fieldWidth, Game.selectedField.Position.Row * fieldHeight, fieldWidth, fieldHeight);
            }
        }   
    }
}
