using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCheckBoxDynamicArrangement
{
    /// <summary>
    /// 選択肢クラス
    /// </summary>
    class Option
    {
        /// <summary>
        /// チェックされているかどうか
        /// </summary>
        public Boolean IsChecked { set; get; }

        /// <summary>
        /// 表示テキスト
        /// </summary>
        public String Text { set; get; }

        /// <summary>
        /// 値
        /// </summary>
        public String Value { set; get; }

    }
}
