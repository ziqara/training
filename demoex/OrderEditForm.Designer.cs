namespace demoex
{
    partial class OrderEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.Label lblPickUpPoint;
        private System.Windows.Forms.ComboBox cmbPickUpPoint;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.GroupBox grpProducts;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.lblPickUpPoint = new System.Windows.Forms.Label();
            this.cmbPickUpPoint = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.grpProducts = new System.Windows.Forms.GroupBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(17, 17);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(83, 13);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Номер заказа:";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(111, 15);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.ReadOnly = true;
            this.txtOrderNumber.Size = new System.Drawing.Size(86, 20);
            this.txtOrderNumber.TabIndex = 1;
            this.txtOrderNumber.Text = "(новый)";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(214, 17);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(75, 13);
            this.lblOrderDate.TabIndex = 2;
            this.lblOrderDate.Text = "Дата заказа:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(283, 14);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(121, 20);
            this.dtpOrderDate.TabIndex = 3;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Location = new System.Drawing.Point(420, 17);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(86, 13);
            this.lblDeliveryDate.TabIndex = 4;
            this.lblDeliveryDate.Text = "Дата доставки:";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Location = new System.Drawing.Point(497, 14);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(121, 20);
            this.dtpDeliveryDate.TabIndex = 5;
            // 
            // lblPickUpPoint
            // 
            this.lblPickUpPoint.AutoSize = true;
            this.lblPickUpPoint.Location = new System.Drawing.Point(17, 52);
            this.lblPickUpPoint.Name = "lblPickUpPoint";
            this.lblPickUpPoint.Size = new System.Drawing.Size(80, 13);
            this.lblPickUpPoint.TabIndex = 6;
            this.lblPickUpPoint.Text = "Пункт выдачи:";
            // 
            // cmbPickUpPoint
            // 
            this.cmbPickUpPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPickUpPoint.FormattingEnabled = true;
            this.cmbPickUpPoint.Location = new System.Drawing.Point(111, 49);
            this.cmbPickUpPoint.Name = "cmbPickUpPoint";
            this.cmbPickUpPoint.Size = new System.Drawing.Size(215, 21);
            this.cmbPickUpPoint.TabIndex = 7;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(343, 52);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(83, 13);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "Пользователь:";
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(423, 49);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(195, 21);
            this.cmbUser.TabIndex = 9;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(17, 87);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(84, 13);
            this.lblCode.TabIndex = 10;
            this.lblCode.Text = "Код получения:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(111, 84);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(69, 20);
            this.txtCode.TabIndex = 11;
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Location = new System.Drawing.Point(189, 83);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(86, 22);
            this.btnGenerateCode.TabIndex = 12;
            this.btnGenerateCode.Text = "Сгенерировать";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(291, 87);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 13);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Статус:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(334, 84);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(129, 22);
            this.cmbStatus.TabIndex = 14;
            // 
            // grpProducts
            // 
            this.grpProducts.Controls.Add(this.btnAddItem);
            this.grpProducts.Controls.Add(this.txtQuantity);
            this.grpProducts.Controls.Add(this.lblQuantity);
            this.grpProducts.Controls.Add(this.cmbProduct);
            this.grpProducts.Controls.Add(this.lblProduct);
            this.grpProducts.Location = new System.Drawing.Point(17, 121);
            this.grpProducts.Name = "grpProducts";
            this.grpProducts.Size = new System.Drawing.Size(600, 61);
            this.grpProducts.TabIndex = 15;
            this.grpProducts.TabStop = false;
            this.grpProducts.Text = "Добавление товара";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(471, 23);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(111, 22);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Добавить товар";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(386, 23);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(69, 20);
            this.txtQuantity.TabIndex = 3;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(317, 26);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(69, 13);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Количество:";
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(51, 23);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(258, 21);
            this.cmbProduct.TabIndex = 1;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(9, 26);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(41, 13);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "Товар:";
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.AllowUserToDeleteRows = false;
            this.dataGridViewItems.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(17, 191);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.RowHeadersVisible = false;
            this.dataGridViewItems.RowTemplate.Height = 25;
            this.dataGridViewItems.Size = new System.Drawing.Size(600, 173);
            this.dataGridViewItems.TabIndex = 16;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(17, 373);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(88, 21);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "Итого: 0 ₽";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(394, 407);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 30);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(514, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 30);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OrderEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 452);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dataGridViewItems);
            this.Controls.Add(this.grpProducts);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnGenerateCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.cmbPickUpPoint);
            this.Controls.Add(this.lblPickUpPoint);
            this.Controls.Add(this.dtpDeliveryDate);
            this.Controls.Add(this.lblDeliveryDate);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.lblOrderNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование заказа";
            this.grpProducts.ResumeLayout(false);
            this.grpProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}