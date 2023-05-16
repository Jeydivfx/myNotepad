using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myNotepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }



        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Choose a text file";
            open.Filter = "text files(*.txt)| *.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(open.FileName, RichTextBoxStreamType.PlainText);
                this.Text = open.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Save the file";
            save.Filter = "text files(*.txt)| *.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
                this.Text = save.FileName;
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog ft = new FontDialog();
            if (ft.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = ft.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = cd.Color;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = richTextBox1.SelectionLength;
            richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.SelectionStart, a);
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currentSize;
            currentSize = richTextBox1.Font.Size;
            currentSize += 2.0f;
            richTextBox1.Font = new Font(richTextBox1.Font.Name, currentSize, richTextBox1.Font.Style, richTextBox1.Font.Unit);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currentSize;
            currentSize = richTextBox1.Font.Size;
            currentSize -= 2.0f;
            richTextBox1.Font = new Font(richTextBox1.Font.Name, currentSize, richTextBox1.Font.Style, richTextBox1.Font.Unit);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // implementing key shortcuts for the notepad

            // New file Ctrl+N
            if (e.Control && e.KeyCode.ToString() == "N")
            {
                newToolStripMenuItem_Click(sender, e);
            }

            // Open a new file Ctrl+O
            if (e.Control && e.KeyCode.ToString() == "O")
            {
                openToolStripMenuItem_Click(sender, e);
            }

            // Save a new file Ctrl+S
            if (e.Control && e.KeyCode.ToString() == "S")
            {
                saveToolStripMenuItem_Click(sender, e);
            }

            // Exiting the program
            if (e.Control && e.KeyCode.ToString() == "E")
            {
                exitToolStripMenuItem_Click(sender, e);
            }

            // Undo a text
            if (e.Control && e.KeyCode.ToString() == "Z")
            {
                undoToolStripMenuItem_Click(sender, e);
            }

            // Redo a text
            if (e.Control && e.KeyCode.ToString() == "Y")
            {
                redoToolStripMenuItem_Click(sender, e);
            }

            // Cut a text
            if (e.Control && e.KeyCode.ToString() == "X")
            {
                cutToolStripMenuItem_Click(sender, e);
            }

            // Copy a text
            if (e.Control && e.KeyCode.ToString() == "C")
            {
                copyToolStripMenuItem_Click(sender, e);
            }

            // Paste a text
            if (e.Control && e.KeyCode.ToString() == "V")
            {
                pasteToolStripMenuItem_Click(sender, e);
            }

            // Delete a part of the text
            if (e.KeyCode.ToString() == "Del")
            {
                deleteToolStripMenuItem_Click(sender, e);
            }

            // Zoom in
            if (e.Control && e.KeyCode == Keys.Oemplus)
            {
                zoomInToolStripMenuItem_Click(sender, e);
            }

            // Zoom out
            if (e.Control && e.KeyCode == Keys.OemMinus)
            {
                zoomOutToolStripMenuItem_Click(sender, e);

            }



        }

        private void notepadProToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notepad pro v1.1");
        }

        private void colorScheme(string key)
        {
            if (key == "dark")
            {
                menuStrip1.BackColor = Color.FromArgb(127, 143, 166);
                richTextBox1.BackColor = Color.FromArgb(47, 54, 64);
                richTextBox1.ForeColor = Color.FromArgb(245, 246, 250);
            }

            else
            {
                menuStrip1.BackColor = Color.FromArgb(245, 246, 250);
                richTextBox1.BackColor = Color.FromArgb(245, 246, 250);
                richTextBox1.ForeColor = Color.FromArgb(47, 54, 64);
            }
        }

        private void blueThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorScheme("dark");
        }

        private void whiteThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorScheme("light");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            colorScheme("light");
            richTextBox1.SelectionFont = new Font("Tahoma", 14, FontStyle.Regular);
        }
    }
}
