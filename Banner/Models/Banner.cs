using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Models
{
    public class Banner : ABanner, IBannerOperations
    {
        public void Clear()
        {
            for (int i = 0; i < RowNum; i++)
            {
                for (int j = 0; j < ColumnNum; j++)
                {
                    this[i, j] = Color.Black;
                }
            }
        }

        public void DrawLine(int rowIndex, Color drawingColor)
        {
            if (rowIndex < 0 || rowIndex >= RowNum)
                throw new ArgumentOutOfRangeException("A megadott sorindex kívül esik az érvényes tartományon.");

            for (int j = 0; j < ColumnNum; j++)
            {
                this[rowIndex, j] = drawingColor;
            }
        }

        public void RotateToLeft()
        {
            for (int i = 0; i < RowNum; i++)
            {
                Color firstPixel = this[i, 0];
                for (int j = 0; j < ColumnNum - 1; j++)
                {
                    this[i, j] = this[i, j + 1];
                }
                this[i, ColumnNum - 1] = firstPixel;
            }
        }

        public void RotateToRight()
        {
            for (int i = 0; i < RowNum; i++)
            {
                Color lastPixel = this[i, ColumnNum - 1];
                for (int j = ColumnNum - 1; j > 0; j--)
                {
                    this[i, j] = this[i, j - 1];
                }
                this[i, 0] = lastPixel;
            }
        }

        public void ShiftToLeft(Color fillColor)
        {
            
        }

        public void ShiftToRight(Color fillColor)
        {
            for (int i = 0; i < RowNum; i++)
            {
                for (int j = ColumnNum - 1; j > 0; j--)
                {
                    this[i, j] = this[i, j - 1];
                }
                this[i, 0] = fillColor;
            }
        }
    }
}
