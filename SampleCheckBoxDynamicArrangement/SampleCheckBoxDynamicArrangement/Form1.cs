using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleCheckBoxDynamicArrangement
{
    public partial class Form1 : Form
    {
        private int toggleFlg = 0;

        /// <summary>
        /// 選択肢リスト
        /// </summary>
        private List<Option> options =new List<Option> {
            new Option{ IsChecked = false, Text = "チェック１", Value = "0"},
            new Option{ IsChecked = false, Text = "チェック２", Value = "1"},
            new Option{ IsChecked = false, Text = "チェック３", Value = "2"},
            new Option{ IsChecked = false, Text = "チェック４", Value = "3"},
            new Option{ IsChecked = false, Text = "チェック５", Value = "4"},
            new Option{ IsChecked = false, Text = "チェック６", Value = "5"},
            new Option{ IsChecked = false, Text = "チェック７", Value = "6"},
            new Option{ IsChecked = false, Text = "チェック８", Value = "7"},
            new Option{ IsChecked = false, Text = "チェック９", Value = "8"},
            new Option{ IsChecked = false, Text = "チェック１０", Value = "9"}
        };
        
        /// <summary>
        /// 初期表示時の処理
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            AddCheckboxHorizontally();
        }

        /// <summary>
        /// チェックボックスを横方向に配置していく
        /// </summary>
        private void AddCheckboxHorizontally()
        {
            foreach (Option o in options)
            {
                CheckBox cb = createCheckBox(o);
                // 特に指定しなければ横に追加していく
                tableLayoutPanel1.Controls.Add(cb);
            }
        }

        /// <summary>
        /// チェックボックスを縦方向に配置していく
        /// </summary>
        private void AddCheckboxVertically() {

            int col = 0;
            int row = 0;
            int maxRow = 4;
            for(int idx = 0; idx < options.Count; idx++)
            {
                CheckBox cb = createCheckBox(options[idx]);
                if (row == maxRow)
                {
                    row = 0;
                    col++;
                }

                // 特に指定しなければ横に追加していく
                tableLayoutPanel1.Controls.Add(cb, col, row++);

            }
        }

        /// <summary>
        /// チェックボックスを作成.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private CheckBox createCheckBox(Option o)
        {
            CheckBox cb = new CheckBox();
            cb.Checked = o.IsChecked;
            cb.Text = o.Text;
            cb.Name = "chk_" + o.Value;
            cb.CheckedChanged += new EventHandler(CheckBoxCheckedChangeHandler);
            return cb;
        }

        /// <summary>
        /// チェックボックス状態変更ハンドラー.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxCheckedChangeHandler(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            int index = int.Parse(cb.Name.Replace("chk_", ""));
            options[index].IsChecked = cb.Checked;
        }

        /// <summary>
        /// チェックボックスを削除する
        /// </summary>
        private void RemoveCheckBox()
        {
            for (int idx = tableLayoutPanel1.Controls.Count - 1; idx >= 0; idx--)
            {
                Control c = tableLayoutPanel1.Controls[idx];
                tableLayoutPanel1.Controls.Remove(c);
            }

        }

        /// <summary>
        /// 切替ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            RemoveCheckBox();
            if (toggleFlg == 0)
            {
                AddCheckboxVertically();
                toggleFlg = 1;
            } else
            {
                AddCheckboxHorizontally();
                toggleFlg = 0;
            }
        }

        /// <summary>
        /// 登録ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            foreach (Option o in options)
            {
                if (o.IsChecked)
                {
                    sb.Append(Environment.NewLine).Append(o.Text);
                    count++;
                }
            }
            sb.Insert(0, "チェックされたのは次の" + count + "件です。");

            if (count > 0)
            {
                MessageBox.Show(this, sb.ToString(), "チェック");
            }
            else
            {
                MessageBox.Show(this, "チェックされていません。", "チェック");
            }
            
        }
    }
}
