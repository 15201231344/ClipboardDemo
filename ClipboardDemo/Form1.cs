using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardDemo
{
    public partial class Form1 : Form
    {
        private static string CopyData = "拷贝的字符串";
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 拷贝按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            //拷贝数据到粘贴板，仅限于当前程序，关闭程序后粘贴板内容清空
            //Clipboard.SetDataObject(CopyData);

            //拷贝数据到粘贴板，整个系统内，关闭程序后也可在任何地方粘贴
            //只有true才可，false相当于上面方法
            Clipboard.SetDataObject(CopyData,true);

            //拷贝数据到粘贴板，整个系统内，关闭程序后也可在任何地方粘贴
            //拷贝三次，每次间隔200ms,在使用拷贝数据的接口时，可能粘贴板正在被占用，这时会导致设置数据失败
            //所以使用该方法，多次设置
            //Clipboard.SetDataObject(CopyData, true,3,200);
        }

        /// <summary>
        /// 粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPaste_Click(object sender, EventArgs e)
        {
            string data;

            //这四种方式是等效的，都是获取文本数据

            //获取粘贴板的对象，没有数据将返回null
            if (Clipboard.ContainsData(DataFormats.Text))
            {
                IDataObject dataObject = Clipboard.GetDataObject();

                //将粘贴的数据转换成string
                data = dataObject.GetData(DataFormats.Text)?.ToString();
            }
           
            //直接通过GetData获取数据
            //object objData = Clipboard.GetData(DataFormats.Text);

            //if(objData!= null)
            //{
            //    data = objData.ToString();
            //}

            //也可以使用下面方法获取string
            //data = Clipboard.GetText();

            //也可以使用下面方法获取string
            //data = Clipboard.GetText(TextDataFormat.Text);

            MessageBox.Show("粘贴的文本未：" + data);
        }

        /// <summary>
        /// 清空粘贴板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
        }

        /// <summary>
        /// 拷贝图片到粘贴板
        /// </summary>
        /// <param name="image"></param>
        private void CopyImage(Image image)
        {
            Clipboard.SetImage(image);
        }
        /// <summary>
        /// 粘贴图片
        /// </summary>
        /// <returns></returns>
        public Image PasteImage()
        {
            Image image = null;
            if (Clipboard.ContainsImage())
            {
                image = Clipboard.GetImage();
            }
            return image;
        }
    }
}
