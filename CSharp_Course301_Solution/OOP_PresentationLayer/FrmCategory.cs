using OOP_BusinessLayer.Abstract;
using OOP_BusinessLayer.Concrete;
using OOP_DataAccessLayer.EntityFramework;
using OOP_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_PresentationLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;
        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Kategori Eklendi!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var deletedValues = _categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Kategori Silindi!");
        }

        private void btnGetById_Click(object sender, EventArgs e)//
        {
            int id = int.Parse(txtCategoryId.Text);
            var values = _categoryService.TGetById(id);
            dataGridView1.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updatedId = int.Parse(txtCategoryId.Text);
            var updatedValues = _categoryService.TGetById(updatedId);
            updatedValues.CategoryName = txtCategoryName.Text;
            updatedValues.CategoryStatus = true;
            _categoryService.TUpdate(updatedValues);
        }
    }
}
