namespace demoex
{
    partial class CardOfOrder
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblArticul = new System.Windows.Forms.Label();
            this.lblPickUpPoint = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDateOfOrder = new System.Windows.Forms.Label();
            this.lblDateOfDelivery = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblArticul
            // 
            this.lblArticul.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblArticul.Location = new System.Drawing.Point(230, 53);
            this.lblArticul.Name = "lblArticul";
            this.lblArticul.Size = new System.Drawing.Size(162, 21);
            this.lblArticul.TabIndex = 0;
            this.lblArticul.Text = "Артикул:";
            this.lblArticul.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPickUpPoint
            // 
            this.lblPickUpPoint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPickUpPoint.Location = new System.Drawing.Point(230, 96);
            this.lblPickUpPoint.Name = "lblPickUpPoint";
            this.lblPickUpPoint.Size = new System.Drawing.Size(162, 21);
            this.lblPickUpPoint.TabIndex = 1;
            this.lblPickUpPoint.Text = "Адрес пункта выдачи:";
            this.lblPickUpPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(230, 74);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(162, 21);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Статус заказа:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDateOfOrder
            // 
            this.lblDateOfOrder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDateOfOrder.Location = new System.Drawing.Point(230, 117);
            this.lblDateOfOrder.Name = "lblDateOfOrder";
            this.lblDateOfOrder.Size = new System.Drawing.Size(162, 21);
            this.lblDateOfOrder.TabIndex = 3;
            this.lblDateOfOrder.Text = "Дата заказа:";
            this.lblDateOfOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDateOfDelivery
            // 
            this.lblDateOfDelivery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateOfDelivery.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDateOfDelivery.Location = new System.Drawing.Point(480, 0);
            this.lblDateOfDelivery.Name = "lblDateOfDelivery";
            this.lblDateOfDelivery.Size = new System.Drawing.Size(197, 197);
            this.lblDateOfDelivery.TabIndex = 4;
            this.lblDateOfDelivery.Text = "Дата доставки";
            this.lblDateOfDelivery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(124, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Дата заказа:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(113, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Статус заказа:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(64, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Адрес пункта выдачи:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(124, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Артикул:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CardOfOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDateOfDelivery);
            this.Controls.Add(this.lblDateOfOrder);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPickUpPoint);
            this.Controls.Add(this.lblArticul);
            this.Name = "CardOfOrder";
            this.Size = new System.Drawing.Size(676, 197);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblArticul;
        private System.Windows.Forms.Label lblPickUpPoint;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDateOfOrder;
        private System.Windows.Forms.Label lblDateOfDelivery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
