using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CivilEngineeringManager.TestProjects
{
    public partial class TestProject : Form
    {
        public class ParentObject
        {
            public string Name { get; set; }
            public int Value { get; set; }
            public List<ChildObject> Children { get; set; } = new List<ChildObject>();
        }

        public class ChildObject
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }

            // Reference to parent (optional but useful)
            public ParentObject Parent { get; set; }
        }

        
        private List<ParentObject> data = new List<ParentObject>();
        private Button btnAddParent;
        private Button btnAddChild;
    
        public TestProject()
        {
            InitializeComponent();
            SetupControls();
            SetupTreeListView();
        }
        private void SetupTreeListView()
        {
            //Configure columns
            treeListView2.Columns.Add(new OLVColumn
            {
                Text = "Name",
                AspectName = "Name",
                Width = 150
            });

            treeListView2.Columns.Add(new OLVColumn
            {
                Text = "Description",
                AspectName = "Description",
                Width = 200
            });

            treeListView2.Columns.Add(new OLVColumn
            {
                Text = "Price",
                AspectName = "Price",
                Width = 80,
                AspectToStringFormat = "{0:C3}"
            });

            // Set the tree view
            treeListView2.CanExpandGetter = delegate (object x) {
                return x is ParentObject;
            };

            treeListView2.ChildrenGetter = delegate (object x) {
                if (x is ParentObject parent)
                    return parent.Children;
                return null;
            };

            // Enable cell editing
            //treeListView2.CellEditActivation = TreeListView.CellEditActivateMode.DoubleClick;
        }

        private void AddChildToSelectedParent()
        {
            var selectedParent = treeListView2.SelectedObject as ParentObject;
            if (selectedParent == null)
            {
                MessageBox.Show("Please select a parent node first.");
                return;
            }
            // Create new child object
            var newChild = new ChildObject
            {
                Name = "New Child",
                Description = "Enter description",
                Price = 10.0m,
                Parent = selectedParent
            };

            // Add to parent's children collection
            selectedParent.Children.Add(newChild);

            // Refresh the tree view
            treeListView2.RefreshObject(selectedParent);

            // Optionally: Start editing the new row
            //treeListView2.EditModel(treeListView2.GetModelObject(newChild));

            //treeListView2.EditModel(treeListView2.GetModelObject(treeListView2.SelectedIndex+1));
            //treeListView2.ExpandAll();
        }

        // Method to handle cell edit finishing
        //private void TreeListView_CellEditFinished(object sender, CellEditEventArgs e)
        //{
        //    //if (e.RowObject is ChildObject child)
        //    //{
        //    //    // Update the child object with edited values
        //    //    switch (e.Column.AspectName)
        //    //    {
        //    //        case "Name":
        //    //            child.Name = e.NewValue?.ToString() ?? "";
        //    //            break;
        //    //        case "Description":
        //    //            child.Description = e.NewValue?.ToString() ?? "";
        //    //            break;
        //    //        case "Price":
        //    //            if (decimal.TryParse(e.NewValue?.ToString(), out decimal price))
        //    //                child.Price = price;
        //    //            break;
        //    //    }

        //    //    // Optional: Save changes or update database
        //    //    SaveChildObject(child);
        //    //}

        //}

        private void SaveChildObject(ChildObject child)
        {
            // Save to database or perform other operations
            Console.WriteLine($"Saved child: {child.Name}, {child.Description}, {child.Price:C}");
        }

        private void SetupControls()
        {
            // Create buttons
            btnAddParent = new Button { Text = "Add Parent", Location = new Point(10, 10) };
            btnAddChild = new Button { Text = "Add Child", Location = new Point(100, 10) };

            btnAddParent.Click += BtnAddParent_Click;
            btnAddChild.Click += BtnAddChild_Click;

            this.Controls.Add(btnAddParent);
            this.Controls.Add(btnAddChild);
        }

        private void BtnAddParent_Click(object sender, EventArgs e)
        {
            var parent = new ParentObject
            {
                Name = $"Parent {data.Count + 1}",
                Value = data.Count + 1
            };
            data.Add(parent);
            treeListView2.SetObjects(data);
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            AddChildToSelectedParent();
        }

        // Method to create object from row data
        //public ChildObject CreateChildFromRowData(ParentObject parent, string name, string description, decimal price)
        //{
        //    return new ChildObject
        //    {
        //        Name = name,
        //        Description = description,
        //        Price = price,
        //        Parent = parent
        //    };
        //}

        // Method to extract data from cells and create object
        //private void CreateObjectFromCurrentRow()
        //{
        //    var selected = treeListView2.SelectedObject;
        //    if (selected is ChildObject child)
        //    {
        //        // Object already exists, you can use its properties
        //        Console.WriteLine($"Child Object: {child.Name}, {child.Description}, {child.Price}");
        //    }
        //    else if (selected is ParentObject parent)
        //    {
        //        // If you need to create from cell values directly
        //        // This is useful when working with uncommitted edits
        //        var model = treeListView2.GetItem(treeListView2.SelectedIndex).RowObject;
        //        // Process the model as needed
        //    }
        //}

        //public void AddChildWithData(ParentObject parent, string name, string description, decimal price)
        //{
        //    // Create child object from the provided data
        //    var child = CreateChildFromRowData(parent, name, description, price);

        //    // Add to parent
        //    parent.Children.Add(child);

        //    // Refresh the tree
        //    treeListView2.RefreshObject(parent);

        //    // Select the new child
        //    treeListView2.SelectedObject = child;
        //    treeListView2.EnsureModelVisible(child);
        //}

        // Usage example:
        //private void AddSampleChild()
        //{
        //    var selectedParent = treeListView2.SelectedObject as ParentObject;
        //    if (selectedParent != null)
        //    {
        //        AddChildWithData(selectedParent, "New Product", "Product description", 29.99m);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            var root = treeListView2.Roots.Cast<ParentObject>();
            MessageBox.Show(root.ElementAt(0).Children.ElementAt(0).Description.ToString());
            root.ElementAt(0).Children.Add(new ChildObject { Name = root.ElementAt(0).Children.ElementAt(0).Name });
            treeListView2.SetObjects(data);
        }
    }
}
