namespace Topmost
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.windowFinder1 = new RyuaNerin.WindowFinder();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(50, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 32);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "TopMost";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // windowFinder1
            // 
            this.windowFinder1.Location = new System.Drawing.Point(12, 12);
            this.windowFinder1.Name = "windowFinder1";
            this.windowFinder1.Size = new System.Drawing.Size(32, 32);
            this.windowFinder1.TabIndex = 0;
            this.windowFinder1.Text = "windowFinder1";
            this.windowFinder1.SelectedWindow += new System.EventHandler<RyuaNerin.WindowFinderArgs>(this.windowFinder1_SelectedWindow);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(140, 56);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.windowFinder1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Topmost";
            this.ResumeLayout(false);

        }

        #endregion

        private RyuaNerin.WindowFinder windowFinder1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

