namespace nikeproject.UserControls
{
    partial class ReportesControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesControl));
            pbReportes = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbReportes).BeginInit();
            SuspendLayout();
            // 
            // pbReportes
            // 
            pbReportes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
       
            pbReportes.InitialImage = (Image)resources.GetObject("pbReportes.InitialImage");
            pbReportes.Location = new Point(0, 0);
            pbReportes.Name = "pbReportes";
            pbReportes.Size = new Size(872, 702);
            pbReportes.SizeMode = PictureBoxSizeMode.StretchImage;
            pbReportes.TabIndex = 6;
            pbReportes.TabStop = false;
            // 
            // ReportesControl
            // 
            Controls.Add(pbReportes);
            Name = "ReportesControl";
            Size = new Size(875, 702);
            ((System.ComponentModel.ISupportInitialize)pbReportes).EndInit();
            ResumeLayout(false);
        }
        private PictureBox pbReportes;
    }
}
