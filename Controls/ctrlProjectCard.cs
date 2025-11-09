using System;
using System.Windows.Forms;

namespace CivilEngineeringManager.Controls
{
    public partial class ctrlProjectCard : UserControl
    {
        public ctrlProjectCard()
        {
            InitializeComponent();
        }

        public int ProjectId {get ; set; }
        
        public string ProjectName
        {
            get { return lblProjectName.Text; }
            set { lblProjectName.Text = value; }
        }

        public int ProjectProgress
        {
            get { return pbProjectProgress.Value; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    pbProjectProgress.Value = value;
                }
            }
        }

        // You might want an event for when the card is clicked
        public event EventHandler CardClick;

        private void ProjectCardControl_Click(object sender, EventArgs e)
        {
            CardClick?.Invoke(this, EventArgs.Empty);
        }

        // Also handle clicks on child controls to ensure the parent click event fires
        private void ChildControl_Click(object sender, EventArgs e)
        {
            //ProjectCardControl_Click(sender, e);
        }

        private void ctrlProjectCard_Load(object sender, EventArgs e)
        {

        }

        private void ctrlProjectCard_MouseClick(object sender, MouseEventArgs e)
        {
            ProjectCardControl_Click(sender, e);
        }

        // In your designer for ProjectCardControl, select all child controls (labels, progress bar)
        // and in their properties window, set their Click event to point to ChildControl_Click
        // and the parent control's (ProjectCardControl itself) Click event to ProjectCardControl_Click.
    }
}
