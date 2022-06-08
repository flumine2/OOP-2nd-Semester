using Lab_4.ua.cdu.edu.model;

using System;
using System.Windows.Controls;

namespace Lab_4.ua.cdu.edu.view
{
    public class BetView : View<Bet, int>
    {
        private ComboBox horseSelectionBox;
        private TextBox betAmountBox;
        private TextBlock balanceField;

        public BetView(ComboBox horseSelectionBox, TextBox betAmountBox, TextBlock balanceField)
        {
            this.horseSelectionBox = horseSelectionBox;
            this.betAmountBox = betAmountBox;
            this.balanceField = balanceField;
        }

        public Bet Bind()
        {
            Bet bet = new Bet();
            bet.HorseIndex = Math.Max(horseSelectionBox.SelectedIndex, 0);
            bet.Amount = Math.Abs(int.Parse(betAmountBox.Text));

            return bet;
        }

        public void Render(int item)
        {
            balanceField.Text = item.ToString();
        }
    }
}
