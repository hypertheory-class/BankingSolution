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

                MessageBox.Show("Enter a number, Einstein!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch(OverdraftException)
            {
                MessageBox.Show("You don't have that much money! GET A JOB!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // select all the text in the textbox, and put the cursor there
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
        }



    }
}