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
            _account.Deposit(decimal.Parse(txtAmount.Text));
            Text = _account.GetBalance().ToString("c");
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            _account.Withdraw(decimal.Parse(txtAmount.Text));
            Text = _account.GetBalance().ToString("c");
        }
    }
}