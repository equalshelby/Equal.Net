using System;
using System.Drawing;
using System.Windows.Forms;

namespace Equal.Custom.Controls
{
    public partial class ComCheckBoxList : UserControl
    {
        private TextBox textValue; //显示的文本
        private ComCheckBoxListButton comDropdownButtom;//下拉按钮
        private ComCheckBoxListLable comGripLable;//此LABEL用于设置可以拖动下拉窗体变化
        private CheckedListBox checkedListBox;//复选框

        private Label lblSelectedAll;//全选
        private Label lblSelectedCancel;//取消

        private Form frmCheckList;

        private Panel pnlBack;
        private Panel pnlCheckedItems;

        private System.Drawing.Point DragOffset; //用于记录窗体大小变化的位置

        //单击列表项状态更改事件
        public delegate void CheckBoxListItemClick(object sender, ItemCheckEventArgs e);
        public event CheckBoxListItemClick ItemClick;

        public ComCheckBoxList()
        {
            InitializeComponent();
            this.Name = "comBoxCheckBoxList";
            this.Layout += new LayoutEventHandler(ComCheckBoxList_Layout);

            #region TextBox设置
            textValue = new TextBox();
            textValue.ReadOnly = true;
            textValue.BorderStyle = BorderStyle.None;
            textValue.Multiline = true;
            #endregion

            #region 下拉按钮设置
            this.comDropdownButtom = new ComCheckBoxListButton();
            comDropdownButtom.FlatStyle = FlatStyle.Flat;
            comDropdownButtom.Click += new EventHandler(comDropdownButtom_Click);
            #endregion

            #region 可拖动窗体大小变化的LABEL
            comGripLable = new ComCheckBoxListLable();
            comGripLable.Size = new Size(9, 18);
            comGripLable.BackColor = Color.Transparent;
            comGripLable.Cursor = Cursors.SizeNWSE;
            comGripLable.MouseDown += new MouseEventHandler(comGripLable_MouseDown);
            comGripLable.MouseMove += new MouseEventHandler(comGripLable_MouseMove);
            #endregion

            #region 生成checkboxlist
            this.checkedListBox = new CheckedListBox();
            checkedListBox.BorderStyle = BorderStyle.None;
            checkedListBox.Location = new Point(0, 0);
            checkedListBox.CheckOnClick = true;
            checkedListBox.ScrollAlwaysVisible = true;
            checkedListBox.LostFocus += new EventHandler(checkedListBox_LostFocus);
            checkedListBox.ItemCheck += new ItemCheckEventHandler(checkedListBox_ItemCheck);
            #endregion

            #region 全选
            this.lblSelectedAll = new Label();
            lblSelectedAll.BackColor = Color.Transparent;
            lblSelectedAll.Text = "全选";
            lblSelectedAll.Size = new Size(40, 20);
            lblSelectedAll.ForeColor = Color.Blue;
            lblSelectedAll.Cursor = Cursors.Hand;
            lblSelectedAll.TextAlign = ContentAlignment.MiddleCenter;
            lblSelectedAll.Click += new EventHandler(lblSelectedAll_Click);
            #endregion

            #region 取消
            lblSelectedCancel = new Label();
            lblSelectedCancel.BackColor = Color.Transparent;
            lblSelectedCancel.Text = "取消";
            lblSelectedCancel.Size = new Size(40, 20);
            lblSelectedCancel.ForeColor = Color.Blue;
            lblSelectedCancel.Cursor = Cursors.Hand;
            lblSelectedCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblSelectedCancel.Click += new EventHandler(lblSelectedCancel_Click);
            #endregion

            #region 窗体
            frmCheckList = new Form();
            frmCheckList.FormBorderStyle = FormBorderStyle.None;
            frmCheckList.StartPosition = FormStartPosition.Manual;
            frmCheckList.BackColor = SystemColors.Control;
            frmCheckList.ShowInTaskbar = false;
            #endregion

            #region panel
            pnlBack = new Panel();
            pnlBack.BorderStyle = BorderStyle.Fixed3D;
            pnlBack.BackColor = Color.White;
            pnlBack.AutoScroll = false;

            pnlCheckedItems = new Panel();
            pnlCheckedItems.BorderStyle = BorderStyle.FixedSingle;
            pnlCheckedItems.BackColor = Color.White; ;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            pnlBack.Controls.Add(textValue);
            pnlBack.Controls.Add(comDropdownButtom);

            this.Controls.Add(pnlBack);

            pnlCheckedItems.Controls.Add(checkedListBox);
            pnlCheckedItems.Controls.Add(lblSelectedAll);
            pnlCheckedItems.Controls.Add(lblSelectedCancel);
            pnlCheckedItems.Controls.Add(comGripLable);
            this.frmCheckList.Controls.Add(pnlCheckedItems);
            #endregion

        }

        /// <summary>
        /// 布局设置
        /// </summary>
        private void ReloationGrip()
        {
            comGripLable.Top = this.frmCheckList.Height - comGripLable.Height - 1;
            comGripLable.Left = this.frmCheckList.Width - comGripLable.Width - 1;

            lblSelectedAll.Left = 5;
            lblSelectedAll.Top = frmCheckList.Height - lblSelectedAll.Height;

            lblSelectedCancel.Left = 50;
            lblSelectedCancel.Top = frmCheckList.Height - lblSelectedCancel.Height;
        }

        #region 事件

        //布局
        private void ComCheckBoxList_Layout(object sender, LayoutEventArgs e)
        {
            this.Height = textValue.Height + 6;
            this.pnlBack.Size = new Size(this.Width, this.Height - 2);

            //设置按钮的位置
            this.comDropdownButtom.Size = new Size(16, this.Height - 6);
            comDropdownButtom.Location = new Point(this.Width - this.comDropdownButtom.Width - 4, 0);

            this.textValue.Location = new Point(2, 2);
            this.textValue.Width = this.Width - comDropdownButtom.Width - 4;

            checkedListBox.Height = 150;

            //设置窗体
            this.frmCheckList.Size = new Size(this.Width, this.checkedListBox.Height);
            this.pnlCheckedItems.Size = frmCheckList.Size;


            this.checkedListBox.Width = this.frmCheckList.Width;
            this.checkedListBox.Height = this.frmCheckList.Height - lblSelectedCancel.Height;

            ReloationGrip();
        }

        /// <summary>
        /// 单击下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void comDropdownButtom_Click(object sender, EventArgs e)
        {
            if (this.frmCheckList.Visible == false)
            {
                Rectangle rec = this.RectangleToScreen(this.ClientRectangle);
                this.frmCheckList.Location = new Point(rec.X, rec.Y + this.pnlBack.Height);
                this.frmCheckList.Show();
                this.frmCheckList.BringToFront();

                ReloationGrip();
            }
            else
                this.frmCheckList.Hide();
        }

        //全选事件
        private void lblSelectedAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
            }
            textValue.Text = "已选择" + checkedListBox.Items.Count.ToString() + "项";
        }
        //取消
        private void lblSelectedCancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, false);
            }
            textValue.Text = "没有选择!";
        }

        private void checkedListBox_LostFocus(object sender, EventArgs e)
        {
            //如果鼠标位置在下拉框按钮的以为地方，则隐藏下拉框
            if (!this.comDropdownButtom.RectangleToScreen(this.comDropdownButtom.ClientRectangle).Contains(Cursor.Position))
            {
                frmCheckList.Hide();
            }
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (ItemClick != null)
            {
                ItemClick(sender, e);
            }
            //获取选中的数量
            int nCount = this.checkedListBox.CheckedItems.Count;
            if (this.checkedListBox.CheckedItems.Contains(this.checkedListBox.Items[e.Index]))
            {

                if (e.NewValue != CheckState.Checked)
                {
                    nCount--;
                }
            }
            else
            {
                if (e.NewValue == CheckState.Checked)
                {
                    nCount++;
                }
            }
            textValue.Text = "已选择" + nCount.ToString() + "项";

        }

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comGripLable_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int offsetX = System.Math.Abs(Cursor.Position.X - frmCheckList.RectangleToScreen(this.frmCheckList.ClientRectangle).Right);
                int offsetY = System.Math.Abs(Cursor.Position.Y - frmCheckList.RectangleToScreen(this.frmCheckList.ClientRectangle).Bottom);
                this.DragOffset = new Point(offsetX, offsetY);
            }
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comGripLable_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //获取拉伸长度
                int curWidth = Cursor.Position.X - frmCheckList.Location.X;
                int curHeight = Cursor.Position.Y - frmCheckList.Location.Y;
                if (curWidth < this.Width)
                {
                    curWidth = this.Width;
                }

                if (curHeight < checkedListBox.Height)
                {
                    curHeight = checkedListBox.Height;
                }

                this.frmCheckList.Size = new Size(this.Width, curHeight);
                this.pnlCheckedItems.Size = frmCheckList.Size;
                this.checkedListBox.Height = (this.frmCheckList.Height - comGripLable.Height) < 50 ? 50 : this.frmCheckList.Height - comGripLable.Height;

                ReloationGrip();
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.ResizeRedraw, true);
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);



            }
        }

        #endregion

        /// <summary>
        /// 数据源
        /// </summary>
        public object DataSource
        {
            set
            {
                this.checkedListBox.DataSource = value;
            }
            get
            {
                return checkedListBox.DataSource;
            }
        }

        /// <summary>
        /// 复选框Item值
        /// </summary>
        public string ValueMember
        {
            set
            {
                checkedListBox.ValueMember = value;
            }
        }

        /// <summary>
        /// 复选框Item显示文本
        /// </summary>
        public string DisplayMember
        {
            set
            {
                checkedListBox.DisplayMember = value;
            }
        }

        /// <summary>
        /// 添加项（返回子项的数量）
        /// </summary>
        public int AddItem(object value)
        {
            checkedListBox.Items.Add(value);
            return checkedListBox.Items.Count;
        }

        /// <summary>
        /// 选项集合
        /// </summary>
        public CheckedListBox.ObjectCollection Items
        {
            get
            {
                return checkedListBox.Items;
            }
        }

        /// <summary>
        /// 获取选中的项
        /// </summary>
        /// <returns></returns>
        public ListBox.SelectedObjectCollection GetSelectedItems()
        {
            return checkedListBox.SelectedItems;
        }
    }

    /// <summary>
    /// 重写LABEL
    /// </summary>
    public class ComCheckBoxListLable : Label
    {
        public ComCheckBoxListLable()
        {
            //控件绘制的时候减少闪烁
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            System.Windows.Forms.ControlPaint.DrawSizeGrip(e.Graphics, Color.Black, 1, 0, this.Size.Width, this.Size.Height);
        }
    }

    /// <summary>
    /// 重写BUTTON
    /// </summary>
    public class ComCheckBoxListButton : Button
    {
        public ComCheckBoxListButton()
        {
            //防止重绘控件出现闪烁
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        ButtonState state;

        //当按钮被按下
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            state = ButtonState.Pushed;
            base.OnMouseDown(mevent);
        }

        //当按钮被释放
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            state = ButtonState.Normal;
            base.OnMouseUp(mevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            System.Windows.Forms.ControlPaint.DrawComboButton(pevent.Graphics, 0, 0, this.Width, this.Height, state);
        }
    }
}
