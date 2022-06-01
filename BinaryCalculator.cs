using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryCalculator
{
    public class Calculator
    {
        private bool IsLocked = true;
        private bool IsRepeat = false;
        private const int SIZEOFARRAY = 50;
        private int currentValue = 0;
        private readonly string[] elemenOfFormula = new string[SIZEOFARRAY];
        private int lastPosition = 0;
        private string lastOperator = null;
        private string binaryString = null;

        public string AddOne()
        {
            if (!IsLocked)
            {
                binaryString += "1";
                currentValue = (currentValue * 2) + 1;
            }
            return binaryString;
        }

        public string AddZero()
        {
            if (!IsLocked)
            {
                binaryString += "0";
                currentValue *= 2;
            }
            return binaryString;
        }

        public void OnOff(bool IsLocked)
        {
            this.IsLocked = IsLocked;
            if (!IsLocked)
            {
                currentValue = 0;
                IsRepeat = false;
                binaryString = null;
                _ = !IsLocked;
            }
            else
            {
                binaryString = null;
                _ = !IsLocked;
            }
        }

        public string[] AddBinary()
        {
            if (!IsLocked)
            {
                if ((SIZEOFARRAY > lastPosition) && (currentValue > 0))
                {
                    elemenOfFormula[lastPosition] = currentValue.ToString();
                    lastPosition++;
                    elemenOfFormula[lastPosition] = "+";
                    lastPosition++;
                    lastOperator = "+";
                    currentValue = 0;
                    binaryString = null;
                }
                else if ((currentValue == 0) && (lastPosition > 2))
                {
                    elemenOfFormula[lastPosition - 1] = "+";
                    IsRepeat = false;                   
                }
            }
            return elemenOfFormula;
        }

        public string[] ClearEntry()
        {
            if (!IsLocked)
            {
                if (lastPosition >= 4)
                {
                    lastPosition--;
                    elemenOfFormula[lastPosition] = "";
                    lastPosition--;
                    elemenOfFormula[lastPosition] = "";
                    lastOperator = elemenOfFormula[lastPosition];
                }
            }
            return elemenOfFormula;
        }

        public string[] DeductBinary()
        {
            if (!IsLocked)
            {
                if ((SIZEOFARRAY > lastPosition) && (currentValue > 0))
                {
                    elemenOfFormula[lastPosition] = currentValue.ToString();
                    lastPosition++;
                    elemenOfFormula[lastPosition] = "-";
                    lastPosition++;
                    lastOperator = "-";
                    currentValue = 0;
                    binaryString = null;
                }
                else if ((currentValue == 0) && (lastPosition > 0))
                {
                    elemenOfFormula[lastPosition - 1] = "-";
                }
            }
            return elemenOfFormula;
        }

        public string[] CalculateAnswer()
        {
            if ((lastPosition > 0) && (!IsLocked))
            {
                if (IsRepeat == false)
                {
                    if (currentValue > 0)
                    {
                        elemenOfFormula[lastPosition] = currentValue.ToString();
                        lastPosition++;
                        IsRepeat = true;
                    }
                }
                else
                {
                    elemenOfFormula[lastPosition] = elemenOfFormula[lastPosition - 2];
                    lastPosition++;
                    elemenOfFormula[lastPosition] = elemenOfFormula[lastPosition - 2];
                    lastPosition++;
                }
            }
            return elemenOfFormula;
        }

        public int CalculateTotal(string[] arrayOfFormula)
        {
            /// Calculating total of the stored formula from 0 to lastposition of the array
            /// Input = Array of formula.
            /// Output = Total
            /// Odd positions are values and even positions are operators of the formula.
            int Total = 0;
            int currentCellValue;
            for (int index = 0; index < lastPosition; index++)
            {
                if (index == 0)
                {
                    Total = Convert.ToInt32(arrayOfFormula[0]);
                }
                else if (index % 2 == 0)
                {
                    currentCellValue = Convert.ToInt32(arrayOfFormula[index]);
                    if (arrayOfFormula[index - 1].ToString() == "+")
                    {
                        Total += currentCellValue;
                    }
                    else if (arrayOfFormula[index - 1].ToString() == "-")
                    {
                        Total -= currentCellValue;
                    }
                }
            }
            return Total;
        }

        public void ClearAll()
        {
            IsLocked = false;
            currentValue = 0;
            binaryString = null;
            Array.Clear(elemenOfFormula, 0, SIZEOFARRAY);
            lastPosition = 0;
            IsRepeat = false;
        }
    }
}
