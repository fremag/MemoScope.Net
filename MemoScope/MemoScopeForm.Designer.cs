using System.Windows.Forms;

namespace MemoScope
{
    partial class MemoScopeForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoScopeForm));
            this.SuspendLayout();
            // 
            // MemoScopeForm
            // 
            this.AllowDrop = true;
            this.ClientSize = new System.Drawing.Size(925, 744);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.AutoScaleMode = AutoScaleMode.Inherit;
            this.Name = "MemoScopeForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MemoScope_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MemoScopeForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MemoScopeForm_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

