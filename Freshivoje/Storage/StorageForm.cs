﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Freshivoje.Storage
{
    public partial class StorageForm : Form
    {
        string _fillTextBox = "SELECT `articles`.`article_name`, `articles`.`sort`, `articles`.`organic`, SUM(`items_receipt`.`quantity`) as quantityArts, DATE_FORMAT(`date`, ' % d.% m.% Y. ') as date FROM `receipts` JOIN `items_receipt` ON `items_receipt`.`fk_receipt_id` = `receipts`.`id_receipt` JOIN `articles` ON `articles`.`id_article` = `items_receipt`.`fk_article_id` WHERE `date` >= CURDATE() GROUP BY `articles`.`id_article`";
        public StorageForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            DbConnection.fillBtnText(a1Btn, "storage", "A1", "id_storage", "storage_position", "article_quantity",  "package_quantity", "status");
            DbConnection.fillBtnText(a2Btn, "storage", "A2", "id_storage", "storage_position", "article_quantity", "package_quantity", "status");
            DbConnection.fillBtnText(b1Btn, "storage", "B1", "id_storage", "storage_position", "article_quantity", "package_quantity", "status");
            DbConnection.fillBtnText(b2Btn, "storage", "B2", "id_storage", "storage_position", "article_quantity", "package_quantity", "status");
            DbConnection.tunnel(tunnelLbl, _fillTextBox,  "article_name", "sort", "organic", "quantityArts");

        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void b1Btn_Click(object sender, EventArgs e)
        {
            ButtonsStorageOnClick(sender);
        }

        private void ButtonsStorageOnClick(object sender)
        {
            Button btn = sender as Button;
            int storage_id = Convert.ToInt32(btn.Tag.ToString());
            ChooseStorageMethodForm chooseStorageMethodForm = new ChooseStorageMethodForm(storage_id);
            chooseStorageMethodForm.ShowDialog(this);
            Show();
        }

        private void a1Btn_Click(object sender, EventArgs e)
        {
            ButtonsStorageOnClick(sender);
        }

        private void a2Btn_Click(object sender, EventArgs e)
        {
            ButtonsStorageOnClick(sender);
        }

        private void b2Btn_Click(object sender, EventArgs e)
        {
            ButtonsStorageOnClick(sender);
        }
    }
}
