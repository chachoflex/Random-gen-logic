using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Generator
{
    public partial class Form1 : Form
    {
        int currentPasswordLength = 0;
        Random character = new Random();
        
        private void passwordGenerator(int passwordLength) 
        {
            string allCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz!@#$%^&*_=+-?><~`";
            string randomPassword = "";

            for (int i = 0; i < passwordLength; i++ )
            {
             int randomNum = character.Next(0, allCharacters.Length);
                randomPassword += allCharacters[randomNum]; 
            }
            PasswordLabel.Text = randomPassword; 

        }

        public Form1()
        {
            InitializeComponent();
            PasswordLabelSlider.Minimum = 5;
            PasswordLabelSlider.Maximum = 20;
            passwordGenerator(5);
        }

        private void CopyPasswordButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(PasswordLabel.Text);
        }

        private void PasswordLabelSlider_Scroll(object sender, EventArgs e)
        {
            PasswordLengthLabel.Text = "Password Length: " + PasswordLabelSlider.Value;
            currentPasswordLength = PasswordLabelSlider.Value;
            passwordGenerator(currentPasswordLength);
        }
    }
}
