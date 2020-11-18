using System;
using System.Windows.Forms;
// ReSharper disable LocalizableElement

namespace ThreadSafety
{
    public partial class View : Form, IView
    {
        public event Action Start;

        public View()
        {
            InitializeComponent();
        }

        public void OnWrite(string message)
        {
            richTextBoxWriter.Text = $"{message}\n{richTextBoxWriter.Text}";
        }

        public void OnRead(string message)
        {
            richTextBoxReader.Text = $"{message}\n{richTextBoxReader.Text}";
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            Start?.Invoke();
        }
    }
}
