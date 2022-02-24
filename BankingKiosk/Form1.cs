using BankingDomain;

namespace BankingKiosk
{
    public partial class Form1 : Form
    {
        private readonly BankAccount _account;
        public Form1(BankAccount account)
        {
            InitializeComponent();
            _account = account;
            Text = _account.GetBalance().ToString("c");
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Deposit);
        }
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Withdraw);
        }

        private void DoTransaction(Action<decimal> op)
        {
            try
            {
                op(decimal.Parse(txtAmount.Text));
                Text = _account.GetBalance().ToString("c");
            }
            catch (FormatException)
            {
                ShowErrorMessage("Enter a number, Einstein!");

            }
            catch (OverdraftException)
            {
                ShowErrorMessage("You don't have that much money! GET A JOB!");
            }
            catch(NoNegativeTransactionAmountsException)
            {
                ShowErrorMessage("Type in a positive number, you 1337 Haxx0r!!");
            }
            finally
            {
                // select all the text in the textbox, and put the cursor there
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
        }

        // "Never type 'private', always refactor to it.
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}