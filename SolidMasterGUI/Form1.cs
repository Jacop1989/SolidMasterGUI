using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace SolidMasterGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // เพิ่ม RichTextBox ลงในฟอร์ม
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Dock = DockStyle.Fill;  // ให้ RichTextBox ขยายเต็มพื้นที่
            richTextBox.ReadOnly = true;  // ป้องกันการแก้ไขข้อมูลใน RichTextBox
            richTextBox.WordWrap = false; // ปิดการตัดคำเพื่อให้แสดงผลในบรรทัดเดียวกัน
            this.Controls.Add(richTextBox);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SolidWorks Files (*.SLDPRT)|*.SLDPRT";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                byte[] fileBytes = File.ReadAllBytes(filePath);

                // แสดงข้อมูลใน TextBox (txtOutput)
                txtOutput.Text = BitConverter.ToString(fileBytes).Replace("-", " ");

                // คุณสามารถแยกข้อมูลเพิ่มเติมได้ที่นี่
                // เช่น parseHeader(fileBytes);
                // และแสดงผลใน txtOutput
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, txtOutput.Text);
            }
        }
    }
}
