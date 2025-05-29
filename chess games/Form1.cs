using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kk
{
    public partial class Form1 : Form
    {
        private Button[,] boardButtons = new Button[8, 8];

        private bool isSelectingStartPosition = true;
        private int startX, startY, endx = 0, endy = 0;




        private string currentPlayer = "White";     

        public Form1()
        {
            InitializeComponent();
            imgset();

        }

        private void statbtn_Click(object sender, EventArgs e)
        {
            InitializeBoard();
            Controls.Remove(label1);
            label1.Dispose();
            Controls.Remove(label2);
            label2.Dispose();
            ggg.Enabled = true;
            button1.Enabled = false;
            statbtn.Enabled = false;
        }

        private void ggg_Click(object sender, EventArgs e)
        {
            SetupInitialBoard();
            ggg.Enabled = false;
            button1.Enabled = true;
            Uplabobo();


        }

        private void InitializeBoard()
        {

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    boardButtons[row, col] = new Button
                    {

                        Width = 60,
                        Height = 60,
                        Left = (col + 1) * 60,
                        Top = (row + 1) * 60,
                        BackColor = (row + col) % 2 == 0 ? System.Drawing.Color.Brown : System.Drawing.Color.Brown,
                        Tag = new Tuple<int, int>(row, col),// ใช้เพื่อเก็บตำแหน่งของปุ่ม
                        BackgroundImageLayout = ImageLayout.Stretch
                    };


                    boardButtons[row, col].Click += button1_Click;

                    Controls.Add(boardButtons[row, col]);
                }



            }
            // กำหนดตำแหน่งหมากรุกเริ่มต้น

        }
        private Image pawnB, pawnW, rookB, rookW, kingB, kingW, knightB, knightW, bishopB, bishopW, queenB, queenW;
        private void imgset()
        {
            pawnB = Image.FromFile("Img/pawn-b-rbg.png");
            pawnW = Image.FromFile("Img/pawn-w-rbg.png");

            rookB = Image.FromFile("Img/rook-b-rbg.png");
            rookW = Image.FromFile("Img/rook-w-rbg.png");

            kingB = Image.FromFile("Img/king-b-rbg.png");
            kingW = Image.FromFile("Img/king-w-rbg.png");

            knightB = Image.FromFile("Img/knight-b-rbg.png");
            knightW = Image.FromFile("Img/knight-w-rbg.png");

            bishopB = Image.FromFile("Img/bishop-b-rbg.png");
            bishopW = Image.FromFile("Img/bishop-w-rbg.png");

            queenB = Image.FromFile("Img/queen-b-rbg.png");
            queenW = Image.FromFile("Img/queen-w-rbg.png");
        }

        private void SetupInitialBoard()
        {

            boardButtons[1, 0].BackgroundImage = pawnB;
            boardButtons[1, 1].BackgroundImage = pawnB;
            boardButtons[1, 2].BackgroundImage = pawnB;
            boardButtons[1, 3].BackgroundImage = pawnB;
            boardButtons[1, 4].BackgroundImage = pawnB;
            boardButtons[1, 5].BackgroundImage = pawnB;
            boardButtons[1, 6].BackgroundImage = pawnB;
            boardButtons[1, 7].BackgroundImage = pawnB;// Pawn สีขาว


            boardButtons[6, 0].BackgroundImage = pawnW;
            boardButtons[6, 1].BackgroundImage = pawnW;
            boardButtons[6, 1].BackgroundImage = pawnW;
            boardButtons[6, 2].BackgroundImage = pawnW;
            boardButtons[6, 3].BackgroundImage = pawnW;
            boardButtons[6, 4].BackgroundImage = pawnW;
            boardButtons[6, 5].BackgroundImage = pawnW;
            boardButtons[6, 6].BackgroundImage = pawnW;
            boardButtons[6, 7].BackgroundImage = pawnW;// Pawn สีดำ

            boardButtons[0, 4].BackgroundImage = kingB;  // King
            boardButtons[7, 4].BackgroundImage = kingW;

            boardButtons[0, 0].BackgroundImage = rookB;
            boardButtons[0, 7].BackgroundImage = rookB;

            boardButtons[7, 0].BackgroundImage = rookW;
            boardButtons[7, 7].BackgroundImage = rookW; // Rook


            boardButtons[0, 1].BackgroundImage = knightB;
            boardButtons[0, 6].BackgroundImage = knightB;

            boardButtons[7, 1].BackgroundImage = knightW;
            boardButtons[7, 6].BackgroundImage = knightW;// Knight

            boardButtons[0, 2].BackgroundImage = bishopB;
            boardButtons[0, 5].BackgroundImage = bishopB;

            boardButtons[7, 2].BackgroundImage = bishopW;
            boardButtons[7, 5].BackgroundImage = bishopW;// Bishop

            boardButtons[0, 3].BackgroundImage = queenB;  // Queen
            boardButtons[7, 3].BackgroundImage = queenW;  // Queen





            // แสดงหมากรุกบนกระดาน

        }

        private Label currentPlayerLabel;

        private void Uplabobo()
        {
            
            if (currentPlayerLabel != null)
            {
                Controls.Remove(currentPlayerLabel);
                currentPlayerLabel.Dispose(); 
            }

            currentPlayerLabel = new Label
            {
                Text = "Current Player: " + currentPlayer,
                Left = 20,
                Top = 20,
                Width = 200,
                ForeColor = System.Drawing.Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            Controls.Add(currentPlayerLabel); 
        }

        private void labolo()
        {
            
            if (currentPlayer == "White")
            {
                currentPlayer = "Black";
            }
            else
            {
                currentPlayer = "White";
            }
            
            
            Uplabobo();
        }

        private void ResetGamy()
        {
            // ลบภาพจากปุ่มทั้งหมดและรีเซ็ตสีพื้นหลัง
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    boardButtons[row, col].BackgroundImage = null; // ลบภาพบนปุ่ม
                    boardButtons[row, col].BackColor = (row + col) % 2 == 0
                        ? System.Drawing.Color.Brown
                        : System.Drawing.Color.Brown; // รีเซ็ตสีพื้นหลัง
                }
            }

            // รีเซ็ตสถานะผู้เล่นเริ่มต้น
            currentPlayer = "White";

            ClearOtherLabels();
        }

        private void ClearOtherLabels()
        {
            Controls.Remove(currentPlayerLabel);

        }


        private Image imgstart = null;


        //private void MoveKing(int startX, int startY, int endx, int endy)
        //{

        //    // ตรวจสอบว่าเดินหนึ่งช่องในทุกทิศทาง
        //    if (Math.Abs(endx - startX) <= 1 && Math.Abs(endy - startY) <= 1)
        //    {
        //        // ตรวจสอบว่าตำแหน่งปลายทางว่าง หรือมีหมากฝ่ายตรงข้าม
        //        var targetPiece = boardButtons[endx, endy].BackgroundImage;

        //        // ตรวจสอบว่าตำแหน่งปลายทางว่าง หรือมีหมากฝ่ายตรงข้าม
        //        if (boardButtons[endx, endy].BackgroundImage == null ||
        //            ((imgstart == kingB && boardButtons[endx, endy].BackgroundImage == kingW) ||
        //            (imgstart == kingB && boardButtons[endx, endy].BackgroundImage == pawnW) ||
        //            (imgstart == kingB && boardButtons[endx, endy].BackgroundImage == rookW) ||
        //            (imgstart == kingB && boardButtons[endx, endy].BackgroundImage == knightW) ||
        //            (imgstart == kingB && boardButtons[endx, endy].BackgroundImage == queenW) ||
        //            (imgstart == kingB && boardButtons[endx, endy].BackgroundImage == bishopW)) ||

        //            ((imgstart == kingW && boardButtons[endx, endy].BackgroundImage == kingB) ||
        //            (imgstart == kingW && boardButtons[endx, endy].BackgroundImage == pawnB) ||
        //            (imgstart == kingW && boardButtons[endx, endy].BackgroundImage == rookB) ||
        //            (imgstart == kingW && boardButtons[endx, endy].BackgroundImage == knightB) ||
        //            (imgstart == kingW && boardButtons[endx, endy].BackgroundImage == queenB) ||
        //            (imgstart == kingW && boardButtons[endx, endy].BackgroundImage == bishopB)))
        //        {

        //            boardButtons[endx, endy].BackgroundImage = imgstart;

        //            boardButtons[startX, startY].BackgroundImage = null;

        //            labolo();
        //        }

        //    }

        //}
        private bool kingMovedW = false; // กษัตริย์ขาวเคลื่อนที่หรือไม่
        private bool rookMovedWLeft = false; // เรือซ้ายขาวเคลื่อนที่หรือไม่
        private bool rookMovedWRight = false; // เรือขวาขาวเคลื่อนที่หรือไม่

        private bool kingMovedB = false; // กษัตริย์ดำเคลื่อนที่หรือไม่
        private bool rookMovedBLeft = false; // เรือซ้ายดำเคลื่อนที่หรือไม่
        private bool rookMovedBRight = false; // เรือขวาดำเคลื่อนที่หรือไม่


        

        private bool IsEnemyPiece(object king, int x, int y)
        {
            
            return (king == kingB && (boardButtons[x, y].BackgroundImage == pawnW ||
                                      boardButtons[x, y].BackgroundImage == rookW ||
                                      boardButtons[x, y].BackgroundImage == knightW ||
                                      boardButtons[x, y].BackgroundImage == bishopW ||
                                      boardButtons[x, y].BackgroundImage == queenW ||
                                      boardButtons[x, y].BackgroundImage == kingW)) ||
                   (king == kingW && (boardButtons[x, y].BackgroundImage == pawnB ||
                                      boardButtons[x, y].BackgroundImage == rookB ||
                                      boardButtons[x, y].BackgroundImage == knightB ||
                                      boardButtons[x, y].BackgroundImage == bishopB ||
                                      boardButtons[x, y].BackgroundImage == queenB ||
                                      boardButtons[x, y].BackgroundImage == kingB));
        }

        private bool IsCastlingMove(int startX, int startY, int endX, int endY)
        {
            // ตรวจสอบว่าเป็นการเดิน Castling
            // ตัวอย่างเงื่อนไข: กษัตริย์เดินสองช่องในแนวนอนและยังไม่เคยเดินมาก่อน
            if (Math.Abs(endY - startY) == 2 && startX == endX)
            {
                // เพิ่มเงื่อนไขอื่น เช่น เส้นทางว่างและปลอดภัย
                return IsPathClear(startX, startY, endX, endY) && IsKingAndRookUnmoved(startX, startY);
            }
            return false;
        }

        private bool IsPathClear(int startX, int startY, int endX, int endY)
        {
            // ตรวจสอบว่าเส้นทางว่างสำหรับ Castling
            int direction = endY > startY ? 1 : -1;
            for (int y = startY + direction; y != endY; y += direction)
            {
                if (boardButtons[startX, y].BackgroundImage != null)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsKingAndRookUnmoved(int startX, int startY)
        {
            if (imgstart == kingW)
            {
                if (startY == 4 && (!kingMovedW|| kingMovedW))
                {
                    return !rookMovedWLeft || !rookMovedWRight;
                }
            }
            else if (imgstart == kingB)
            {
                if (startY == 4 && (!kingMovedB|| kingMovedB))
                {
                    return !rookMovedBLeft || !rookMovedBRight;
                }
            }
            return false;
        }


        private void PerformCastling(int startX, int startY, int endX, int endY)
        {
            // ดำเนินการ Castling
            int rookStartY = endY > startY ? 7 : 0; // ตำแหน่งเรือเริ่มต้น
            int rookEndY = endY > startY ? endY - 1 : endY + 1; // ตำแหน่งเรือปลายทาง

            // ย้ายกษัตริย์
            boardButtons[endX, endY].BackgroundImage = imgstart;
            boardButtons[startX, startY].BackgroundImage = null;

            // ย้ายเรือ
            boardButtons[startX, rookEndY].BackgroundImage = boardButtons[startX, rookStartY].BackgroundImage;
            boardButtons[startX, rookStartY].BackgroundImage = null;

            labolo();
        }
        private void UpdatePieceStatus(int startX, int startY, int endX, int endY)
        {
            if (imgstart == kingW)
            {
                kingMovedW = true;
            }
            else if (imgstart == kingB)
            {
                kingMovedB = true;
            }

            if (imgstart == rookW && startY == 0)
            {
                rookMovedWLeft = true;
            }
            else if (imgstart == rookW && startY == 7)
            {
                rookMovedWRight = true;
            }
            else if (imgstart == rookB && startY == 0)
            {
                rookMovedBLeft = true;
            }
            else if (imgstart == rookB && startY == 7)
            {
                rookMovedBRight = true;
            }
        }




        private void MoveQueen(int startX, int startY, int endX, int endY)
        {
            if (startX == endX || startY == endY)
            {
                // หาก Queen เดินเหมือน Rook
                 MoveRook(startX, startY, endX, endY);
            }
            else if (Math.Abs(endX - startX) == Math.Abs(endY - startY))
            {
                // หาก Queen เดินเหมือน Bishop
                 MoveBishop(startX, startY, endX, endY);
            }
           
        }


        private void MoveBishop(int startX, int startY, int endX, int endY)
        {
            // ตรวจสอบว่าการเคลื่อนที่อยู่ในแนวทแยงมุม
            if (Math.Abs(endX - startX) == Math.Abs(endY - startY))
            {
                bool isPathClear = true;

                // ตรวจสอบว่าเส้นทางว่าง
                int xDirection = endX > startX ? 1 : -1; // ทิศทางในแกน X
                int yDirection = endY > startY ? 1 : -1; // ทิศทางในแกน Y

                int steps = Math.Abs(endX - startX);
                for (int step = 1; step < steps; step++)
                {
                    int intermediateX = startX + step * xDirection;
                    int intermediateY = startY + step * yDirection;

                    if (boardButtons[intermediateX, intermediateY].BackgroundImage != null)
                    {
                        isPathClear = false;
                        break;
                    }
                }

                if (isPathClear)
                {
                    var targetImage = boardButtons[endX, endY].BackgroundImage;
                    bool isValidMove = false;

                    // Check if the target position is either empty or contains an opponent's piece
                    if (targetImage == null ||
                        (((imgstart == bishopB || imgstart == queenB) && targetImage == kingW) ||
                        ((imgstart == bishopB || imgstart == queenB) && targetImage == pawnW) ||
                        ((imgstart == bishopB || imgstart == queenB) && targetImage == rookW) ||
                        ((imgstart == bishopB || imgstart == queenB) && targetImage == knightW) ||
                        ((imgstart == bishopB || imgstart == queenB) && targetImage == queenW) ||
                        ((imgstart == bishopB || imgstart == queenB) && targetImage == bishopW)) ||

                        (((imgstart == bishopW || imgstart == queenW) && targetImage == kingB) ||
                        ((imgstart == bishopW || imgstart == queenW) && targetImage == pawnB) ||
                        ((imgstart == bishopW || imgstart == queenW) && targetImage == rookB) ||
                        ((imgstart == bishopW || imgstart == queenW) && targetImage == knightB) ||
                        ((imgstart == bishopW || imgstart == queenW) && targetImage == queenB) ||
                        ((imgstart == bishopW || imgstart == queenW) && targetImage == bishopB)))
                    {
                        isValidMove = true;
                    }

                   

                    if (isValidMove)
                    {
                        boardButtons[endX, endY].BackgroundImage = imgstart;
                        boardButtons[startX, startY].BackgroundImage = null;
                        labolo();
                    }
                   
                }
               
            }
            

           
        }



        private bool MoveKnight(int startX, int startY, int endX, int endY, bool simulate = false)
        {
            // การเคลื่อนที่แบบ L ของ Knight
            int[,] moves = new int[,]
            {
        { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 },
        { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 }
            };

            bool validMove = false;

            for (int i = 0; i < 8; i++)
            {
                int newX = startX + moves[i, 0];
                int newY = startY + moves[i, 1];

                if (newX == endX && newY == endY)
                {
                    validMove = true;
                    break;
                }
            }

            if (validMove)
            {
                var targetImage = boardButtons[endX, endY].BackgroundImage;

                // ตรวจสอบว่าตำแหน่งปลายทางว่าง หรือมีหมากฝ่ายตรงข้าม
                bool isValidTarget = (boardButtons[endX, endY].BackgroundImage == null ||
                    ((imgstart == knightB && targetImage == kingW) ||
                    (imgstart == knightB && targetImage == pawnW) ||
                    (imgstart == knightB && targetImage == rookW) ||
                    (imgstart == knightB && targetImage == knightW) ||
                    (imgstart == knightB && targetImage == queenW) ||
                    (imgstart == knightB && targetImage == bishopW)) ||

                    ((imgstart == knightW && targetImage == kingB) ||
                    (imgstart == knightW && targetImage == pawnB) ||
                    (imgstart == knightW && targetImage == rookB) ||
                    (imgstart == knightW && targetImage == knightB) ||
                    (imgstart == knightW && targetImage == queenB) ||
                    (imgstart == knightW && targetImage == bishopB)));

                if (simulate)
                {
                    return isValidTarget; // Only check validity of the move, do not execute it
                }

                if (isValidTarget)
                {
                    boardButtons[endX, endY].BackgroundImage = imgstart;
                    boardButtons[startX, startY].BackgroundImage = null;

                    labolo();
                }
                
            }
            

            return false;
        }





        private void MoveRook(int startX, int startY, int endX, int endY)
        {
            // ตรวจสอบการเคลื่อนที่ในแนวนอนหรือแนวตั้ง
            if (startX == endX || startY == endY)
            {
                bool isPathClear = true;

                // ตรวจสอบว่าเส้นทางว่าง
                if (startX == endX) // เดินในแนวตั้ง
                {
                    int minY = Math.Min(startY, endY);
                    int maxY = Math.Max(startY, endY);

                    for (int y = minY + 1; y < maxY; y++)
                    {
                        if (boardButtons[startX, y].BackgroundImage != null)
                        {
                            isPathClear = false;
                            break;
                        }
                    }
                }
                else if (startY == endY) // เดินในแนวนอน
                {
                    int minX = Math.Min(startX, endX);
                    int maxX = Math.Max(startX, endX);
                    for (int x = minX + 1; x < maxX; x++)
                    {
                        if (boardButtons[x, startY].BackgroundImage != null)
                        {
                            isPathClear = false;
                            break;
                        }
                    }
                }

                // หากเส้นทางว่างและตำแหน่งปลายทางเหมาะสม
                if (isPathClear)
                {
                    var targetImage = boardButtons[endX, endY].BackgroundImage;
                    bool isValidMove = false;

                    // Check if the target position is either empty or contains an opponent's piece
                    if (targetImage == null ||
                        (((imgstart == rookB || imgstart == queenB) && targetImage == kingW) ||
                        ((imgstart == rookB || imgstart == queenB) && targetImage == pawnW) ||
                        ((imgstart == rookB || imgstart == queenB) && targetImage == rookW) ||
                        ((imgstart == rookB || imgstart == queenB) && targetImage == knightW) ||
                        ((imgstart == rookB || imgstart == queenB) && targetImage == queenW) ||
                        ((imgstart == rookB || imgstart == queenB) && targetImage == bishopW)) ||

                        (((imgstart == rookW || imgstart == queenW) && targetImage == kingB) ||
                        ((imgstart == rookW || imgstart == queenW) && targetImage == pawnB) ||
                        ((imgstart == rookW || imgstart == queenW) && targetImage == rookB) ||
                        ((imgstart == rookW || imgstart == queenW) && targetImage == knightB) ||
                        ((imgstart == rookW || imgstart == queenW) && targetImage == queenB) ||
                        ((imgstart == rookW || imgstart == queenW) && targetImage == bishopB)))
                    { 
                    
                        boardButtons[endX, endY].BackgroundImage = boardButtons[startX, startY].BackgroundImage;
                        boardButtons[startX, startY].BackgroundImage = null;
                        labolo();
                    }
                    
                }
               
            }
            

          
        }


        private void MoveBlackPawn(int startX, int startY, int endX, int endY)
        {
            if ((endX == 7 && startX == 6) && boardButtons[endX, endY].BackgroundImage != kingW) // Pawn reaches the promotion row
            {
                
                PromotePawn();
            }
            // Check for standard one-step move (forward)
            else if (endX == startX + 1 && endY == startY && boardButtons[endX, endY].BackgroundImage == null)
            {
                
                boardButtons[endX, endY].BackgroundImage = pawnB;
                boardButtons[startX, startY].BackgroundImage = null;
                labolo();
            }
            // Check for double-step move from starting position
            else if (startX == 1 && endX == startX + 2 && endY == startY && boardButtons[endX, endY].BackgroundImage == null && boardButtons[startX + 1, startY].BackgroundImage == null)
            {
                
                boardButtons[endX, endY].BackgroundImage = pawnB;
                boardButtons[startX, startY].BackgroundImage = null;
                labolo();
            }
            // Check for capturing an opponent's piece diagonally
            else if (endX == startX + 1 && (endY == startY - 1 || endY == startY + 1))
            {
                var targetImage = boardButtons[endX, endY].BackgroundImage;
                // Check if there is an opponent's piece at the destination
                if ((targetImage == kingW) || (targetImage == pawnW) || (targetImage == rookW) ||
                    (targetImage == knightW) || (targetImage == queenW) || (targetImage == bishopW))
                {
                    boardButtons[endX, endY].BackgroundImage = pawnB;
                    boardButtons[startX, startY].BackgroundImage = null;
                    labolo();
                }
               
            }
            

          
        }
        private void MoveWhitePawn(int startX, int startY, int endX, int endY)
        {
            // Pawn promotion when reaching the last row (0)
            if ((endX == 0 && startX == 1) && boardButtons[endX, endY].BackgroundImage != kingB)
            {

                PromotePawn();
            }
            // Check for standard one-step move (forward)
            else if (endX == startX - 1 && endY == startY && boardButtons[endX, endY].BackgroundImage == null)
            {

                boardButtons[endX, endY].BackgroundImage = pawnW;
                boardButtons[startX, startY].BackgroundImage = null;
                labolo();
            }
            // Check for double-step move from starting position
            else if (startX == 6 && endX == startX - 2 && endY == startY && boardButtons[endX, endY].BackgroundImage == null && boardButtons[startX - 1, startY].BackgroundImage == null)
            {

                boardButtons[endX, endY].BackgroundImage = pawnW;
                boardButtons[startX, startY].BackgroundImage = null;
                labolo();
            }
            // Check for capturing an opponent's piece diagonally
            else if (endX == startX - 1 && (endY == startY - 1 || endY == startY + 1))
            {
                var targetImage = boardButtons[endX, endY].BackgroundImage;
                // Check if there is an opponent's piece at the destination
                if ((targetImage == kingB) || (targetImage == pawnB) || (targetImage == rookB) ||
                    (targetImage == knightB) || (targetImage == queenB) || (targetImage == bishopB))
                {

                    boardButtons[endX, endY].BackgroundImage = pawnW;
                    boardButtons[startX, startY].BackgroundImage = null;
                    labolo();
                }

            }



        }

        public enum PieceType
        {
            Queen,  // ควีน
            Rook,   // รูค
            Bishop, // บิชอป
            Knight  // นัยท์
        }
        private void PromotePawn()
        {

            var promoteForm = new Form2();
            if (promoteForm.ShowDialog() == DialogResult.OK)
            {
                // หลังจากผู้เล่นเลือกหมากแล้ว
                kk.Form1.PieceType selectedPiece = promoteForm.PromotedType; // ใช้ kk.Form1.PieceType
                if (currentPlayer == "White")
                {
                    OnPawnPromotedblack(selectedPiece);
                }
                else
                {
                    OnPawnPromotedwhite(selectedPiece);
                }
            }



        }
        public void OnPawnPromotedwhite(PieceType promotedType)
        {

            // โปรโมตพีออนให้เป็นตัวหมากที่เลือก
            boardButtons[7, endy].BackgroundImage = GetPieceImage(promotedType);
            boardButtons[startX, startY].BackgroundImage = null;
            labolo();
        }

        public void OnPawnPromotedblack(PieceType promotedType)
        {
            boardButtons[0, endy].BackgroundImage = GetPieceImageB(promotedType);
            boardButtons[startX, startY].BackgroundImage = null;
            labolo();
        }
        private Image GetPieceImage(PieceType type)
        {
            switch (type)
            {
                case PieceType.Queen:

                    return queenB;
                // ภาพควีนดำ
                case PieceType.Rook:
                    return rookB;   // ภาพรูคดำ
                case PieceType.Bishop:
                    return bishopB; // ภาพบิชอปดำ
                case PieceType.Knight:
                    return knightB; // ภาพนัยท์ดำ
                default:
                    return null;
            }
        }
        private Image GetPieceImageB(PieceType type)
        {
            switch (type)
            {
                case PieceType.Queen:

                    return queenW;
                // ภาพควีนดำ
                case PieceType.Rook:
                    return rookW;   // ภาพรูคดำ
                case PieceType.Bishop:
                    return bishopW; // ภาพบิชอปดำ
                case PieceType.Knight:
                    return knightW; // ภาพนัยท์ดำ
                default:
                    return null;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ResetGamy();
            ggg.Enabled = true;
            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            var button = sender as Button; // ตรวจสอบว่า sender เป็นปุ่มจริงหรือไม่
            var position = button.Tag as Tuple<int, int>; // ดึงตำแหน่งจาก Tag ของปุ่ม

            if (isSelectingStartPosition)
            {
                // เลือกตำแหน่งเริ่มต้น
                startX = position.Item1;
                startY = position.Item2;
                imgstart = boardButtons[startX, startY].BackgroundImage;

                if (imgstart != null)
                {
                    if ((currentPlayer == "White" && (imgstart == pawnW || imgstart == rookW || imgstart == knightW || imgstart == bishopW || imgstart == queenW || imgstart == kingW)) ||
                        (currentPlayer == "Black" && (imgstart == pawnB || imgstart == rookB || imgstart == knightB || imgstart == bishopB || imgstart == queenB || imgstart == kingB)))
                    {
                        boardButtons[startX, startY].BackColor = Color.Gold;
                       
                        HighlightValidMoves(startX, startY, endx, endy, imgstart);
                        isSelectingStartPosition = false;
                    }
                    else
                    {
                        MessageBox.Show("กรุณาเลือกหมากของคุณ!");
                    }
                }
               
            }
            else
            {
                // เลือกตำแหน่งปลายทาง
                endx = position.Item1;
                endy = position.Item2;

                // ตรวจสอบการเคลื่อนที่
                if (imgstart == pawnB)
                {
                    MoveBlackPawn(startX, startY, endx, endy);
                    CheckpenB(endx, endy, currentPlayer);
                    CheckKingCaptured();

                }
                else if (imgstart == pawnW)
                {
                    MoveWhitePawn(startX, startY, endx, endy);
                    CheckpenW(endx, endy, currentPlayer);
                    CheckKingCaptured();
                }
                else if ((imgstart == rookB) || (imgstart == rookW))
                {
                    MoveRook(startX, startY, endx, endy);
                    LinearMoves(endx, endy, imgstart);
                    CheckKingCaptured();
                }
                else if (imgstart == knightB || imgstart == knightW)
                {
                    MoveKnight(startX, startY, endx, endy);
                    checkKnightMoves( endx, endy, imgstart);
                    CheckKingCaptured();
                }
                else if (imgstart == bishopB || imgstart == bishopW)
                {
                    MoveBishop(startX, startY, endx, endy);
                    DiagonalMoves(endx, endy, imgstart);
                    CheckKingCaptured();
                }
                else if (imgstart == queenB || imgstart == queenW)
                {
                    MoveQueen(startX, startY, endx, endy);
                    LinearMoves(endx, endy, imgstart);
                    DiagonalMoves(endx, endy, imgstart);
                    CheckKingCaptured();
                }

                else if (imgstart == kingB || imgstart == kingW)
                {
                    MoveKing(startX, startY, endx, endy);
                    CheckKingCaptured();

                }
                // สลับผู้เล่น
                // รีเซ็ตสถานะ
                imgstart = boardButtons[endx, endy].BackgroundImage;
                isSelectingStartPosition = true;
                ResetBoardColors();
            }
        }

        private void ResetBoardColors()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    boardButtons[row, col].BackColor = (row + col) % 2 == 0 ? Color.Brown : Color.Brown;
                }
            }
        }

        private void HighlightValidMoves(int startX, int startY, int endx, int endy, Image piece)
        {
            ResetBoardColors(); // รีเซ็ตสีเริ่มต้น

            if (piece == null) return;

            if (piece == pawnB)
            {
                boardButtons[startX, startY].BackColor = Color.Gold;
                HighlightBlackPawnMoves(startX, startY);

            }
            else if (piece == pawnW)
            {
                boardButtons[startX, startY].BackColor = Color.Gold;
                HighlightWhitePawnMoves(startX, startY);

            }
            else if (piece == rookB || piece == rookW)
            {
                boardButtons[startX, startY].BackColor = Color.Gold;
                HighlightLinearMoves(startX, startY);
            }
            else if (piece == bishopB || piece == bishopW)
            {
                boardButtons[startX, startY].BackColor = Color.Gold;
                HighlightDiagonalMoves(startX, startY);
            }
            else if (piece == knightB || piece == knightW)
            {
                boardButtons[startX, startY].BackColor = Color.Gold;
                HighlightKnightMoves(startX, startY);
            }
            else if (piece == queenB || piece == queenW)
            {
                boardButtons[startX, startY].BackColor = Color.Gold;
                HighlightLinearMoves(startX, startY);
                HighlightDiagonalMoves(startX, startY);
            }
            else if (piece == kingB || piece == kingW)
            {
                boardButtons[startX, startY].BackColor = Color.Gold;
                HighlightKingMoves(startX, startY);
            }
        }
        private void HighlightBlackPawnMoves(int startX, int startY)
        {

            if (startX + 1 < 8 && boardButtons[startX + 1, startY].BackgroundImage == null)
            {
                boardButtons[startX + 1, startY].BackColor = Color.LightGreen;
            }
            if (startX == 1 && startX + 2 < 8 && boardButtons[startX + 2, startY].BackgroundImage == null)
            {
                boardButtons[startX + 2, startY].BackColor = Color.LightGreen;
            }
            if (startX + 1 < 8 && startY + 1 < 8)
            {
                if ((boardButtons[startX + 1, startY + 1].BackgroundImage == pawnW) || boardButtons[startX + 1, startY + 1].BackgroundImage == rookW
                    || boardButtons[startX + 1, startY + 1].BackgroundImage == bishopW || boardButtons[startX + 1, startY + 1].BackgroundImage == kingW
                    || boardButtons[startX + 1, startY + 1].BackgroundImage == knightW || boardButtons[startX + 1, startY + 1].BackgroundImage == queenW)
                {
                    boardButtons[startX + 1, startY + 1].BackColor = Color.Red;
                }
                else
                {
                    boardButtons[startX + 1, startY + 1].BackColor = Color.Brown;
                }

            }
            if (startX + 1 < 8 && startY - 1 >= 0)
            {
                if ((boardButtons[startX + 1, startY - 1].BackgroundImage == pawnW) || boardButtons[startX + 1, startY - 1].BackgroundImage == rookW
                    || boardButtons[startX + 1, startY - 1].BackgroundImage == bishopW || boardButtons[startX + 1, startY - 1].BackgroundImage == kingW
                    || boardButtons[startX + 1, startY - 1].BackgroundImage == knightW || boardButtons[startX + 1, startY - 1].BackgroundImage == queenW)
                {
                    boardButtons[startX + 1, startY - 1].BackColor = Color.Red;
                }
                else
                {
                    boardButtons[startX + 1, startY - 1].BackColor = Color.Brown;
                }
            }
        }

        private void HighlightWhitePawnMoves(int startX, int startY)
        {
            if (startX - 1 >= 0 && boardButtons[startX - 1, startY].BackgroundImage == null)
            {
                boardButtons[startX - 1, startY].BackColor = Color.LightGreen;
            }
            if (startX == 6 && startX - 2 >= 0 && boardButtons[startX - 2, startY].BackgroundImage == null)
            {
                boardButtons[startX - 2, startY].BackColor = Color.LightGreen;
            }
            if (startX - 1 >= 0 && startY + 1 < 8)
            {
                if ((boardButtons[startX - 1, startY + 1].BackgroundImage == pawnB) || boardButtons[startX - 1, startY + 1].BackgroundImage == rookB
                    || boardButtons[startX - 1, startY + 1].BackgroundImage == bishopB || boardButtons[startX - 1, startY + 1].BackgroundImage == kingB
                    || boardButtons[startX - 1, startY + 1].BackgroundImage == knightB || boardButtons[startX - 1, startY + 1].BackgroundImage == queenB)
                {
                    boardButtons[startX - 1, startY + 1].BackColor = Color.Red;
                }
                else
                {
                    boardButtons[startX - 1, startY + 1].BackColor = Color.Brown;
                }
            }
            if (startX - 1 >= 0 && startY - 1 >= 0)
            {
                if ((boardButtons[startX - 1, startY - 1].BackgroundImage == pawnB) || boardButtons[startX - 1, startY - 1].BackgroundImage == rookB
                    || boardButtons[startX - 1, startY - 1].BackgroundImage == bishopB || boardButtons[startX - 1, startY - 1].BackgroundImage == kingB
                    || boardButtons[startX - 1, startY - 1].BackgroundImage == knightB || boardButtons[startX - 1, startY - 1].BackgroundImage == queenB)
                {
                    boardButtons[startX - 1, startY - 1].BackColor = Color.Red;
                }
                else
                {
                    boardButtons[startX - 1, startY - 1].BackColor = Color.Brown;
                }
            }
        }
        private void HighlightLinearMoves(int startX, int startY)
        {

            HighlightDirection(startX, startY, 1, 0, imgstart);  // Down
            HighlightDirection(startX, startY, -1, 0, imgstart); // Up
            HighlightDirection(startX, startY, 0, 1, imgstart);  // Right
            HighlightDirection(startX, startY, 0, -1, imgstart); // Left
        }
        private void HighlightDiagonalMoves(int startX, int startY)
        {
            HighlightDirection(startX, startY, 1, 1, imgstart);   // Down-right
            HighlightDirection(startX, startY, 1, -1, imgstart);  // Down-left
            HighlightDirection(startX, startY, -1, 1, imgstart);  // Up-right
            HighlightDirection(startX, startY, -1, -1, imgstart); // Up-left
        }
        private void HighlightDirection(int startX, int startY, int dx, int dy, Image piece)
        {
            int x = startX + dx;
            int y = startY + dy;


            while (x >= 0 && x < 8 && y >= 0 && y < 8)
            {

                Image targetPiece = boardButtons[x, y].BackgroundImage;


                if (targetPiece == null)
                {
                    boardButtons[x, y].BackColor = Color.LightGreen;
                }
                else
                {

                    bool isSameColor = IsSameColor(piece, targetPiece);

                    if (isSameColor)
                    {

                        break;
                    }
                    else
                    {

                        boardButtons[x, y].BackColor = Color.Red;
                        break;
                    }
                }


                x += dx;
                y += dy;
            }
        }


      

        private void HighlightKnightMoves(int startX, int startY)
        {
            int[,] moves = new int[,]
            {
        { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 },
        { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 }
            };


            for (int i = 0; i < 8; i++)
            {
                int newX = startX + moves[i, 0];
                int newY = startY + moves[i, 1];


                if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8)
                {
                    Image targetPiece = boardButtons[newX, newY].BackgroundImage;


                    if (targetPiece == null)
                    {
                        boardButtons[newX, newY].BackColor = Color.LightGreen;
                    }
                    else
                    {

                        bool isSameColor = IsSameColor(boardButtons[startX, startY].BackgroundImage, targetPiece);

                        if (isSameColor)
                        {

                            boardButtons[newX, newY].BackColor = Color.Brown; // No highlight
                            
                        }
                        else
                        {

                            boardButtons[newX, newY].BackColor = Color.Red;
                            
                        }
                    }
                }
            }
        }
        private void HighlightKingMoves(int startX, int startY)
        {

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {

                    if (dx == 0 && dy == 0) continue;

                    int newX = startX + dx;
                    int newY = startY + dy;


                    if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8)
                    {
                        Image targetPiece = boardButtons[newX, newY].BackgroundImage;


                        if (targetPiece == null)
                        {
                            boardButtons[newX, newY].BackColor = Color.LightGreen;
                        }
                        else
                        {

                            bool isSameColor = IsSameColor(boardButtons[startX, startY].BackgroundImage, targetPiece);

                            if (isSameColor)
                            {

                                boardButtons[newX, newY].BackColor = Color.Brown; // No highlight
                            }
                            else
                            {

                                boardButtons[newX, newY].BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
        }
        // ฟังก์ชันตรวจสอบสถานะการเช็ค
        private void MoveKing(int startX, int startY, int endX, int endY)
        {
            if (checkpenB == true)
            {  // ตรวจสอบว่าเดินหนึ่งช่องในทุกทิศทาง
                if (Math.Abs(endX - startX) <= 1 && Math.Abs(endY - startY) <= 1)
                {
                    var targetPiece = boardButtons[endX, endY].BackgroundImage;

                    // ตรวจสอบว่าตำแหน่งปลายทางว่าง หรือมีหมากฝ่ายตรงข้าม
                    if (boardButtons[endX, endY].BackgroundImage == null ||
                        ((imgstart == kingB && IsEnemyPiece(kingB, endX, endY)) ||
                         (imgstart == kingW && IsEnemyPiece(kingW, endX, endY))))
                    {
                        boardButtons[endX, endY].BackgroundImage = imgstart;
                        boardButtons[startX, startY].BackgroundImage = null;

                        labolo();
                    }
                }
                else if (IsCastlingMove(startX, startY, endX, endY))
                {
                    PerformCastling(startX, startY, endX, endY);
                }
            }
            else
            {
                MessageBox.Show(checkpenB.ToString());
            }
            UpdatePieceStatus(startX, startY, endX, endY);
        }

        private void CheckKingCaptured()
        {
            // ตรวจสอบว่าคิงดำหรือคิงขาวถูกกิน
            bool isWhiteKingCaptured = true;
            bool isBlackKingCaptured = true;

            // วนลูปบนกระดานเพื่อค้นหาคิงขาวและดำ
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var piece = boardButtons[i, j].BackgroundImage;
                    if (piece == kingW) isWhiteKingCaptured = false;
                    if (piece == kingB) isBlackKingCaptured = false;
                }
            }

            // แสดงผลเมื่อคิงฝ่ายใดฝ่ายหนึ่งถูกกิน
            if (isWhiteKingCaptured)
            {
                button1.Enabled = false;
                MessageBox.Show("King ขาวถูกกิน! ฝ่ายดำชนะ!", "เกมจบ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ResetGame(); // รีเซ็ตเกมใหม่
            }
            else if (isBlackKingCaptured)
            {
                button1.Enabled = false;
                MessageBox.Show("King ดำถูกกิน! ฝ่ายขาวชนะ!", "เกมจบ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ResetGame(); // รีเซ็ตเกมใหม่
            }
        }
        private void ResetGame()
        {
            // รีเซ็ตตำแหน่งเริ่มต้นของหมากทั้งหมด
            ggg.Enabled = true;
            currentPlayer = "White"; // ตั้งค่าให้ผู้เล่นขาวเริ่มก่อน
            MessageBox.Show("เริ่มเกมใหม่!", "รีเซ็ตเกม", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetGamy();

        }
        bool checkpenB = true;
        private void CheckpenB(int endx, int endy, string currentPlayer)
        {


            if (endx + 1 < 8 && endy + 1 < 8)
            {
                if (boardButtons[endx + 1, endy + 1].BackgroundImage == kingW)
                {
                    MessageBox.Show("KING ฝั่ง " + currentPlayer + " ถุกเช็ค", "เตือนภัย", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkpenB = false;
                }
                else
                {
                    checkpenB = true;
                }


            }
            if (endx + 1 < 8 && endy - 1 >= 0)
            {
                if (boardButtons[endx + 1, endy - 1].BackgroundImage == kingW)
                {
                    MessageBox.Show("KING ฝั่ง " + currentPlayer + " ถุกเช็ค", "เตือนภัย", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkpenB = false;
                }
                else
                {
                    checkpenB = true;
                }

            }
        }
        bool checkpenW = true;
        private void CheckpenW(int endx, int endy, string currentPlayer)
        {

            if (endx - 1 >= 0 && endy + 1 < 8)
            {
                if (boardButtons[endx - 1, endy + 1].BackgroundImage == kingB)
                {
                    MessageBox.Show("KING ฝั่ง " + currentPlayer + " ถุกเช็ค", "เตือนภัย", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkpenW = false;
                }
                else
                {
                    checkpenW = true;
                }

            }
            if (endx - 1 >= 0 && endy - 1 >= 0)
            {
                if (boardButtons[endx - 1, endy - 1].BackgroundImage == kingB)
                {
                    MessageBox.Show("KING ฝั่ง " + currentPlayer + " ถุกเช็ค", "เตือนภัย", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkpenW = false;
                }
                else
                {
                    checkpenW = true;
                }
            }
        }

        private void LinearMoves(int endx, int endy, Image piece)
        {
            Direction(endx, endy, 1, 0, piece);  // Down
            Direction(endx, endy, -1, 0, piece); // Up
            Direction(endx, endy, 0, 1, piece);  // Right
            Direction(endx, endy, 0, -1, piece); // Left
        }

        private void DiagonalMoves(int endx, int endy, Image piece)
        {
            Direction(endx, endy, 1, 1, piece);   // Down-right
            Direction(endx, endy, 1, -1, piece);  // Down-left
            Direction(endx, endy, -1, 1, piece);  // Up-right
            Direction(endx, endy, -1, -1, piece); // Up-left
        }

        private void Direction(int endx, int endy, int dx, int dy, Image piece)
        {
            int x = endx + dx;
            int y = endy + dy;

            while (x >= 0 && x < 8 && y >= 0 && y < 8)
            {
                Image targetPiece = boardButtons[x, y].BackgroundImage;

                if (targetPiece != null)
                {
                    // หากเป็นหมากฝั่งเดียวกัน ให้หยุดการตรวจสอบ
                    if (IsSameColorBW(piece, targetPiece))
                    {
                        break;
                    }

                    // หากเจอคิงฝั่งตรงข้าม
                    if (targetPiece == kingB || targetPiece == kingW)
                    {
                        // ตรวจสอบว่าไม่มีหมากใดขวางระหว่างตัวตรวจสอบกับคิง
                        
                        MessageBox.Show($"KING ฝั่ง {currentPlayer} ถูกรุก", "เตือนภัย", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                    // หากเจอหมากอื่นขวางทาง
                    break;
                }

                // เดินไปยังช่องถัดไปในทิศทางที่กำหนด
                x += dx;
                y += dy;
            }
        }

        private bool IsSameColorBW(Image piece1, Image piece2)
        {
            if (piece1 == null || piece2 == null) return false;

            bool isWhitePiece1 = piece1 == queenW || piece1 == rookW || piece1 == bishopW ||
                                 piece1 == knightW || piece1 == pawnW || piece1 == kingW;

            bool isWhitePiece2 = piece2 == queenW || piece2 == rookW || piece2 == bishopW ||
                                 piece2 == knightW || piece2 == pawnW || piece2 == kingW;

            return isWhitePiece1 == isWhitePiece2;
        }


        private void checkKnightMoves(int endx, int endy , Image piece)
        {
            int[,] moves = new int[,]
            {
        { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 },
        { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 }
            };


            for (int i = 0; i < 8; i++)
            {
                int newX = endx + moves[i, 0];
                int newY = endy + moves[i, 1];


                if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8)
                {
                    Image targetPiece = boardButtons[newX, newY].BackgroundImage;

                    if (targetPiece != null)
                    {
                        // Check if the piece is the opposite King's color
                        if (IsSameColorBW(piece, targetPiece))
                        {
                            break;
                        }
                        else
                        {
                            if (targetPiece == kingW || targetPiece == kingB)
                            {

                                MessageBox.Show("KING ฝั่ง " + currentPlayer + " ถูกรุก", "เตือนภัย", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                break;

                            }
                        }
                        
                    }
                    }
                }
            }

        private bool IsSameColor(Image piece1, Image piece2)
        {

            if ((piece1 == queenW || piece1 == rookW || piece1 == bishopW || piece1 == knightW || piece1 == pawnW || piece1 == kingW) &&
                (piece2 == queenW || piece2 == rookW || piece2 == bishopW || piece2 == knightW || piece2 == pawnW || piece2 == kingW))
            {
                return true;
            }
            if ((piece1 == queenB || piece1 == rookB || piece1 == bishopB || piece1 == knightB || piece1 == pawnB || piece1 == kingB) &&
                (piece2 == queenB || piece2 == rookB || piece2 == bishopB || piece2 == knightB || piece2 == pawnB || piece2 == kingB))
            {
                return true;
            }

            return false;
        }


    }

    }





