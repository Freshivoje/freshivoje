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
    public partial class Classification : Form
    {
        readonly string query1 = "SELECT * FROM pallete;";
        readonly string query = "SELECT receipts.fk_client_id, clients.first_name, clients.last_name, items_receipt.fk_receipt_id, items_receipt.fk_article_id, items_receipt.id_items_receipt, items_receipt.quantity, items_receipt.status, articles.article_name, articles.sort, articles.organic, articles.category, item_pallete.fk_id_pallete, item_pallete.fk_id_item_recepit, pallete.pallet_number  FROM receipts INNER JOIN clients ON receipts.fk_client_id = clients.id_client INNER JOIN items_receipt ON items_receipt.fk_receipt_id = receipts.id_receipt INNER JOIN articles ON articles.id_article = items_receipt.fk_article_id INNER JOIN item_pallete ON items_receipt.id_items_receipt=item_pallete.fk_id_item_recepit INNER JOIN pallete on pallete.id_pallete = item_pallete.fk_id_pallete";
        public Classification()
        {
            DbConnection.FillCmbBoxQuery(palletnumberCmbBox, query1, "id_pallete", "pallet_number", "classification");
            InitializeComponent();
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

        private void Classification_Load(object sender, EventArgs e)
        {

        }

        private void insertFormTblLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void palletnumberCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
