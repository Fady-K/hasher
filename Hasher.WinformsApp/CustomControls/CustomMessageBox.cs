using System.Windows.Forms;

namespace Hasher.WinformsApp.CustomControls
{
	internal partial class CustomMessageBoxForm : Form
	{
		/// /////////////////////////////////////////// Constructors ///////////////////////////////
		public CustomMessageBoxForm(string message, string title)
		{
			InitializeComponent();

			// Init rest of UI components
			this.txtboxMessage.Text = message;
			this.Text = title;

		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}

	public partial class CustomMessageBox
	{
		public static void Show(string message, string title)
		{
			using (var form = new CustomMessageBoxForm(message, title))
			{
				form.ShowDialog();
			}
		}
	}
}
