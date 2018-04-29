using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Create
{
	/// <summary>
	/// </summary>
	public partial class MainForm : Form
		
	{	
		TextBox ToEncrypt = new TextBox();
		TextBox Encrypted = new TextBox();
		TextBox Passphrase = new TextBox();
		Button Encrypt = new Button();
		Button Decrypt = new Button();
		Button Clear1 = new Button();
		Button Clear2 = new Button();
		Button ClearAll = new Button();
		Label lblPassphrase = new Label();
		Label lblToEncrypt = new Label();
		Label lblEncrypted = new Label();
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			ToEncrypt.Multiline = true;
			ToEncrypt.Width = 550;
			ToEncrypt.Height = 50;
			ToEncrypt.KeyDown += toEncrypt_KeyDown;
			ToEncrypt.WordWrap = true;
			ToEncrypt.Location = new Point((this.Width-ToEncrypt.Width)/2,50);
			Encrypted.KeyDown += Encrypted_KeyDown;
			Encrypted.Multiline = true;
			Encrypted.Width = 550;
			Encrypted.Height = 50;
			Encrypted.WordWrap = true;
			Encrypted.Location = new Point((this.Width-Encrypted.Width)/2,this.Height-150);
			Passphrase.Width = 100;
			Passphrase.Location = new Point(25,25);
			Encrypt.Text = "Encrypt";
			Encrypt.Click += btnEncrypt_Click;
			Encrypt.Location = new Point(ToEncrypt.Location.X+ToEncrypt.Width,ToEncrypt.Location.Y+25);
			Decrypt.Text = "Decrypt";
			Decrypt.Click += btnDecrypt_Click;
			Decrypt.Location = new Point(Encrypted.Location.X+Encrypted.Width,Encrypted.Location.Y+25);
			Clear1.Text = "Clear";
			Clear1.Click += btnClear1_Click;
			Clear1.Location = new Point(ToEncrypt.Location.X+ToEncrypt.Width,ToEncrypt.Location.Y);
			Clear2.Text = "Clear";
			Clear2.Click += btnClear2_Click;
			Clear2.Location = new Point(Encrypted.Location.X+Encrypted.Width,Encrypted.Location.Y);
			ClearAll.Text = "Clear All";
			ClearAll.Click += btnClearAll_Click;
			ClearAll.Location = new Point((this.Width-Encrypt.Width)/2,200);
			lblPassphrase.Text = "Enter a passprhase for your message";
			lblPassphrase.Location = new Point(Passphrase.Location.X-20,Passphrase.Location.Y-23);
			lblPassphrase.Width = 200;
			lblToEncrypt.Text = "Enter text to Encrypt";
			lblToEncrypt.Width = 200;
			lblToEncrypt.Location = new Point(ToEncrypt.Location.X,ToEncrypt.Location.Y-23);
			lblEncrypted.Text = "Enter text to Decrypt";
			lblEncrypted.Width = 200;
			lblEncrypted.Location = new Point(Encrypted.Location.X,Encrypted.Location.Y-23);
			Controls.Add(lblEncrypted);
			Controls.Add(lblToEncrypt);
			Controls.Add(lblPassphrase);
			Controls.Add(ClearAll);
			Controls.Add(Clear2);
			Controls.Add(Clear1);
			Controls.Add(Decrypt);
			Controls.Add(Encrypt);
			Controls.Add(Passphrase);
			Controls.Add(ToEncrypt);
			Controls.Add(Encrypted);
		}
			private void toEncrypt_KeyDown(object sender, KeyEventArgs e)
			{
    			if (e.Control && e.KeyCode == Keys.A)
    			{
        			if (sender != null)
            		((TextBox)sender).SelectAll();
    			}
    			
			}
			private void Encrypted_KeyDown(object sender, KeyEventArgs e)
			{
    			if (e.Control && e.KeyCode == Keys.A)
    			{
        			if (sender != null)
            		((TextBox)sender).SelectAll();
    			}
    			
			}
			private void btnEncrypt_Click(object sender, EventArgs e)
			{	
				if(ToEncrypt.Text != ""){
				Encrypted.Text = Encryption.EncryptString(Passphrase.Text,ToEncrypt.Text);
				}
			}
			private void btnClear1_Click(object sender, EventArgs e)
			{
				ToEncrypt.Text = "";
			}
			private void btnClear2_Click(object sender, EventArgs e)
			{
				Encrypted.Text = "";
			}
			private void btnClearAll_Click(object sender, EventArgs e)
			{
				ToEncrypt.Text = "";
				Encrypted.Text = "";
			}
			private void btnDecrypt_Click(object sender, EventArgs e)
			{
				try{
					ToEncrypt.Text = Encryption.DecryptString(Passphrase.Text,Encrypted.Text);
				}catch(CryptographicException e1){
					MessageBox.Show("Wrong Passphrase!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
				}catch(FormatException e2){
					MessageBox.Show("Not a valid encrypted string!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

	}
}
